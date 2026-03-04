using System.Collections;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xunit.Sdk;

namespace CookBook.Common.Tests;

public static class DeepAssert
{
    public static void Equal<T>(T? expected, T? actual, params string[] propertiesToIgnore)
    {
        if (!AreEquivalent(expected, actual, propertiesToIgnore, out var difference))
        {
            throw EqualException.ForMismatchedValues(expected, actual, difference);
        }
    }

    public static void Contains<T>(T? expected, IEnumerable<T>? collection, params string[] propertiesToIgnore)
    {
        if (collection is null)
            throw new ArgumentNullException(nameof(collection));

        if (!collection.Any(item => AreEquivalent(expected, item, propertiesToIgnore, out _)))
        {
            throw ContainsException.ForCollectionItemNotFound(expected!.ToString()!, nameof(collection));
        }
    }

    private static bool AreEquivalent(
        object? expected,
        object? actual,
        IEnumerable<string> propertiesToIgnore,
        out string difference)
    {
        var ignored = propertiesToIgnore.ToHashSet(StringComparer.Ordinal);
        var visited = new HashSet<ReferencePair>(ReferencePairComparer.Instance);
        return AreEquivalent(expected, actual, ignored, visited, "$", out difference);
    }

    private static bool AreEquivalent(
        object? expected,
        object? actual,
        ISet<string> ignoredProperties,
        ISet<ReferencePair> visited,
        string path,
        out string difference)
    {
        if (expected is null || actual is null)
        {
            if (expected is null && actual is null)
            {
                difference = string.Empty;
                return true;
            }

            difference = $"{path}: expected '{expected ?? "null"}' but was '{actual ?? "null"}'";
            return false;
        }

        var expectedType = expected.GetType();
        var actualType = actual.GetType();

        if (IsSimple(expectedType) && IsSimple(actualType))
        {
            if (Equals(expected, actual))
            {
                difference = string.Empty;
                return true;
            }

            difference = $"{path}: expected '{expected}' but was '{actual}'";
            return false;
        }

        if (expected is IEnumerable expectedEnumerable && actual is IEnumerable actualEnumerable
            && expected is not string && actual is not string)
        {
            return CollectionsAreEquivalent(expectedEnumerable, actualEnumerable, ignoredProperties, visited, path, out difference);
        }

        if (!expectedType.IsValueType && !actualType.IsValueType)
        {
            var pair = new ReferencePair(expected, actual);
            if (!visited.Add(pair))
            {
                difference = string.Empty;
                return true;
            }
        }

        var expectedProperties = expectedType
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0 && !ignoredProperties.Contains(p.Name));
        var actualProperties = actualType
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0)
            .ToDictionary(p => p.Name, p => p, StringComparer.Ordinal);

        foreach (var expectedProperty in expectedProperties)
        {
            if (!actualProperties.TryGetValue(expectedProperty.Name, out var actualProperty))
            {
                difference = $"{path}.{expectedProperty.Name}: property missing on actual object";
                return false;
            }

            var expectedValue = expectedProperty.GetValue(expected);
            var actualValue = actualProperty.GetValue(actual);
            if (!AreEquivalent(expectedValue, actualValue, ignoredProperties, visited, $"{path}.{expectedProperty.Name}", out difference))
            {
                return false;
            }
        }

        difference = string.Empty;
        return true;
    }

    private static bool CollectionsAreEquivalent(
        IEnumerable expectedEnumerable,
        IEnumerable actualEnumerable,
        ISet<string> ignoredProperties,
        ISet<ReferencePair> visited,
        string path,
        out string difference)
    {
        var expectedList = expectedEnumerable.Cast<object?>().ToList();
        var actualList = actualEnumerable.Cast<object?>().ToList();

        if (expectedList.Count != actualList.Count)
        {
            difference = $"{path}: expected collection count {expectedList.Count} but was {actualList.Count}";
            return false;
        }

        var matchedActualIndexes = new HashSet<int>();
        for (var i = 0; i < expectedList.Count; i++)
        {
            var matched = false;
            for (var j = 0; j < actualList.Count; j++)
            {
                if (matchedActualIndexes.Contains(j))
                {
                    continue;
                }

                if (AreEquivalent(expectedList[i], actualList[j], ignoredProperties, visited, $"{path}[{i}]", out _))
                {
                    matchedActualIndexes.Add(j);
                    matched = true;
                    break;
                }
            }

            if (!matched)
            {
                difference = $"{path}[{i}]: no equivalent item found";
                return false;
            }
        }

        difference = string.Empty;
        return true;
    }

    private static bool IsSimple(Type type)
    {
        return type.IsPrimitive
               || type.IsEnum
               || type == typeof(string)
               || type == typeof(decimal)
               || type == typeof(Guid)
               || type == typeof(DateTime)
               || type == typeof(DateTimeOffset)
               || type == typeof(TimeSpan);
    }

    private readonly record struct ReferencePair(object Left, object Right);

    private sealed class ReferencePairComparer : IEqualityComparer<ReferencePair>
    {
        public static ReferencePairComparer Instance { get; } = new();

        public bool Equals(ReferencePair x, ReferencePair y)
            => ReferenceEquals(x.Left, y.Left) && ReferenceEquals(x.Right, y.Right);

        public int GetHashCode(ReferencePair obj)
            => HashCode.Combine(
                RuntimeHelpers.GetHashCode(obj.Left),
                RuntimeHelpers.GetHashCode(obj.Right));
    }
}
