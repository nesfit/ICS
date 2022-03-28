using System;
using System.Diagnostics;

namespace TestedApplication.Tests.DependencySharing.Fixtures
{
    public class NonSharedFixture : IDisposable
    {
        public NonSharedFixture()
        {
            Debug.WriteLine("Non shared fixture created.");
        }

        public void Dispose()
        {
            Debug.WriteLine("Non shared fixture destroyed.");
        }
    }
}