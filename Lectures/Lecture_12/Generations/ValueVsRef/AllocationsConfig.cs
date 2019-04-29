using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Jobs;

namespace ValueVsRef
{
    public class AllocationsConfig : ManualConfig
    {
        public AllocationsConfig()
        {
            var gcSettings = new GcMode
            {
                Force = false // tell BenchmarkDotNet not to force GC collections after every iteration
            };

            const int invocationCount = 1 << 20; // let's run it very fast, we are here only for the GC stats

            Add(Job
                .RyuJitX64 // 64 bit
                .WithInvocationCount(invocationCount)
                .With(gcSettings.UnfreezeCopy()));
            Add(Job
                .LegacyJitX86 // 32 bit
                .WithInvocationCount(invocationCount)
                .With(gcSettings.UnfreezeCopy()));

            Add(MemoryDiagnoser.Default);
        }
    }
}