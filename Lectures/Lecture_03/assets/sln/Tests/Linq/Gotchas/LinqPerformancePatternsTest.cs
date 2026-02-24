using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests.Linq
{
    public class LinqPerformancePatternsTest
    {
        [Fact]
        public void Any_ShortCircuits_WhileCountScansWholeSequence()
        {
            var inspectedByAny = 0;
            var anyResult = TraceRange(100, () => inspectedByAny++)
                .Any(n => n == 0);

            var inspectedByCount = 0;
            var countResult = TraceRange(100, () => inspectedByCount++)
                .Count(n => n == 0) > 0;

            Assert.True(anyResult);
            Assert.True(countResult);
            Assert.Equal(1, inspectedByAny);
            Assert.Equal(100, inspectedByCount);
        }

        private static IEnumerable<int> TraceRange(int count, Action onMoveNext)
        {
            for (var i = 0; i < count; i++)
            {
                onMoveNext();
                yield return i;
            }
        }
    }
}
