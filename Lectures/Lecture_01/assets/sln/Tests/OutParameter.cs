using Xunit;

namespace Tests
{
    public class OutParameter
    {
        private void Foo(string name, out string firstNames, out string lastName)
        {
            var i = name.LastIndexOf(' ');
            firstNames = name.Substring(0, i);
            lastName = name.Substring(i + 1);
        }

        [Fact]
        public void Test()
        {
            const string firstNames = "Stevie Ray";
            const string lastName = "Vaughan";

            Foo($"{firstNames} {lastName}", out var a, out var b);

            Assert.Equal("Stevie Ray", a);
            Assert.Equal("Vaughan", b);
        }
    }
}