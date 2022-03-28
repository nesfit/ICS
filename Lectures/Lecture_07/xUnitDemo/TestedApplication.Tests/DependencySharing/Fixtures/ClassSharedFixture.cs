using System;
using System.Diagnostics;

namespace TestedApplication.Tests.DependencySharing.Fixtures
{
    public class ClassSharedFixture : IDisposable
    {
        public ClassSharedFixture()
        {
            Debug.WriteLine("Class shared fixture created.");
        }

        public void Dispose()
        {
            Debug.WriteLine("Class shared fixture destroyed.");
        }
    }
}