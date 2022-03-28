using System;
using System.Diagnostics;
using Xunit;

namespace TestedApplication.Tests.DependencySharing.Fixtures
{
    public class GroupSharedFixture : IDisposable
    {
        public GroupSharedFixture()
        {
            Debug.WriteLine("Group shared fixture created.");
        }

        public void Dispose()
        {
            Debug.WriteLine("Group shared fixture destroyed.");
        }
    }

    [CollectionDefinition("GroupName")]
    public class TestGroupTestCollection : ICollectionFixture<GroupSharedFixture>
    {
    }
}