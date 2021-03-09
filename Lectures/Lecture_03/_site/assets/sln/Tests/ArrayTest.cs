using System;
using Xunit;

namespace Tests
{
    public class ArrayTest
    {
        [Fact]
        public void Test()
        {
            string[] dinosaurs =
            {
                "Pachycephalosaurus",
                "Amargasaurus",
                "Tyrannosaurus",
                "Mamenchisaurus",
                "Deinonychus",
                "Edmontosaurus"
            };

            Array.Sort(dinosaurs);
            var index = Array.BinarySearch(dinosaurs, "Amargasaurus");
            
            Assert.Equal(0, index);
        }
    }
}