using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Linq.Modern
{
    public class LinqModernOperatorsTest
    {
        [Fact]
        public void MinByAndMaxBy_SelectByKey()
        {
            var players = new[]
            {
                new Player("Anna", 12),
                new Player("Bob", 7),
                new Player("Clara", 15)
            };

            var min = players.MinBy(p => p.Score);
            var max = players.MaxBy(p => p.Score);

            Assert.Equal("Bob", min.Name);
            Assert.Equal("Clara", max.Name);
        }

        [Fact]
        public void ByOperators_WorkWithKeys()
        {
            var students = new[]
            {
                new Student(1, "Alice"),
                new Student(1, "ALICE duplicate"),
                new Student(2, "Bob"),
                new Student(3, "Cecil")
            };

            var distinctById = students.DistinctBy(s => s.Id).ToList();
            var exceptById = students.ExceptBy(new[] { 2 }, s => s.Id).Select(s => s.Name).ToList();
            var intersectById = students.IntersectBy(new[] { 1, 3 }, s => s.Id).Select(s => s.Name).ToList();
            var unionById = students.Take(2).UnionBy(students.Skip(2), s => s.Id).ToList();

            Assert.Equal(3, distinctById.Count);
            Assert.DoesNotContain(exceptById, n => n == "Bob");
            Assert.Contains("Alice", intersectById);
            Assert.Contains("Cecil", intersectById);
            Assert.Equal(3, unionById.Count);
        }

        [Fact]
        public void ChunkAndZip_ShapeSequences()
        {
            var chunks = Enumerable.Range(1, 7).Chunk(3).Select(c => string.Join(",", c)).ToArray();
            var labels = new[] { "A", "B", "C" };
            var points = new[] { 10, 20 };
            var zipped = labels.Zip(points, (label, point) => $"{label}:{point}").ToArray();

            Assert.Equal(new[] { "1,2,3", "4,5,6", "7" }, chunks);
            Assert.Equal(new[] { "A:10", "B:20" }, zipped);
        }

        [Fact]
        public void PrependAppendAndTailOperators_KeepQueryReadable()
        {
            var sequence = new[] { 2, 3 }.Prepend(1).Append(4);

            Assert.Equal(new[] { 1, 2, 3, 4 }, sequence);
            Assert.Equal(new[] { 3, 4 }, sequence.TakeLast(2));
            Assert.Equal(new[] { 1, 2 }, sequence.SkipLast(2));
        }

        [Fact]
        public void ToHashSetAndTryGetNonEnumeratedCount_AreUsefulUtilities()
        {
            var tags = new[] { "linq", "LINQ", "Linq" };
            // ToHashSet materializes immediately and removes duplicates.
            // The comparer defines what "equal" means (here: case-insensitive).
            var set = tags.ToHashSet(StringComparer.OrdinalIgnoreCase);

            Assert.Single(set);

            var list = new List<int> { 1, 2, 3, 4 };
            // TryGetNonEnumeratedCount returns Count in O(1) when the source knows its size
            // (e.g., List, Array, ICollection) without forcing enumeration.
            Assert.True(list.TryGetNonEnumeratedCount(out var count));
            Assert.Equal(4, count);

            IEnumerable<int> iterator = YieldNumbers();
            // For iterator pipelines, the size is often unknown up front.
            // The method returns false, so you can avoid accidental full enumeration.
            Assert.False(iterator.TryGetNonEnumeratedCount(out _));
        }

        private static IEnumerable<int> YieldNumbers()
        {
            yield return 1;
            yield return 2;
        }

        private sealed record Player(string Name, int Score);
        private sealed record Student(int Id, string Name);
    }
}
