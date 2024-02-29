using KellermanSoftware.CompareNetObjects;
using Xunit.Sdk;

namespace CookBook.Common.Tests;

public static class DeepAssert
{
    public static void Equal<T>(T? expected, T? actual, params string[] propertiesToIgnore)
    {
        CompareLogic compareLogic = new()
        {
            Config =
            {
                MembersToIgnore = propertiesToIgnore.ToList(),
                IgnoreCollectionOrder = true,
                IgnoreObjectTypes = true,
                CompareStaticProperties = false,
                CompareStaticFields = false
            }
        };

        ComparisonResult comparisonResult = compareLogic.Compare(expected!, actual!);
        if (!comparisonResult.AreEqual)
        {
            EqualException.ForMismatchedValues(expected, actual, comparisonResult.DifferencesString);
        }
    }

    public static void Contains<T>(T? expected, IEnumerable<T>? collection, params string[] propertiesToIgnore)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            CompareLogic compareLogic = new()
            {
                Config =
                {
                    MembersToIgnore = propertiesToIgnore.ToList(),
                    IgnoreCollectionOrder = true,
                    IgnoreObjectTypes = true,
                    CompareStaticProperties = false,
                    CompareStaticFields = false
                }
            };

            if (!collection.Any(item => compareLogic.Compare(expected!, item).AreEqual))
            {
                ContainsException.ForCollectionItemNotFound(expected.ToString(), nameof(collection));
            }
        }
}
