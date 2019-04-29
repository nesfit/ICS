using BenchmarkDotNet.Attributes;

namespace ValueVsRef
{
    [MemoryDiagnoser]
    [RyuJitX64Job, LegacyJitX86Job]
    public class ValueTypeInvokingInterfaceMethod
    {
        interface IInterface
        {
            void DoNothing();
        }

        class ReferenceTypeImplementingInterface : IInterface
        {
            public void DoNothing() { }
        }

        struct ValueTypeImplementingInterface : IInterface
        {
            public void DoNothing() { }
        }

        private ReferenceTypeImplementingInterface reference = new ReferenceTypeImplementingInterface();
        private ValueTypeImplementingInterface value = new ValueTypeImplementingInterface();

        [Benchmark(Baseline = true)]
        public void ValueType() => AcceptingInterface(value);

        [Benchmark]
        public void ReferenceType() => AcceptingInterface(reference);

        void AcceptingInterface(IInterface instance) => instance.DoNothing();
    }
}