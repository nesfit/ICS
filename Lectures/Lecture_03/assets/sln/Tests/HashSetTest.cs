using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class HashSetTest
    {
        [Fact]
        public void Test()
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 3, 4, 5 };
            int[] array3 = { 9, 10, 11 };

            var set = new HashSet<int>(array1);
            Assert.True(set.Overlaps(array2));
            Assert.False(set.Overlaps(array3));
        }
    }
}