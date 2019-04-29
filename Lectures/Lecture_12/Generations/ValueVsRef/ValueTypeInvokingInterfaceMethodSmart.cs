using System;
using BenchmarkDotNet.Attributes;

namespace ValueVsRef
{
    [MemoryDiagnoser]
    [RyuJitX64Job]
    public class ValueTypeInvokingInterfaceMethodSmart
    {
        // IInterface, ReferenceTypeImplementingInterface, ValueTypeImplementingInterface and fields are declared in previous benchmark

        [Benchmark(Baseline = true, OperationsPerInvoke = 16)]
        public void ValueType()
        {
            IInterface value = new Value();
            AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value);
            AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value);
            AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value);
            AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value); AcceptingInterface(value);
        }

        [Benchmark(OperationsPerInvoke = 16)]
        public void ValueTypeSmart()
        {
            Value value = new Value();
            AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value);
            AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value);
            AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value);
            AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value);
            AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value); AcceptingSomethingThatImplementsInterface(value);
        }

        [Benchmark(OperationsPerInvoke = 16)]
        public void ReferenceType()
        {
            IInterface reference = new Reference();
            AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference);
            AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference);
            AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference);
            AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference); AcceptingInterface(reference);
        }

        void AcceptingInterface(IInterface instance) => instance.DoNothing();

        void AcceptingSomethingThatImplementsInterface<T>(T instance)
            where T : IInterface
        {
            instance.DoNothing();
        }


        interface IInterface
        {
            void DoNothing();
        }

        class Reference :IInterface{
            public void DoNothing()
            {
            }
        }

        struct Value : IInterface
        {
            public void DoNothing()
            {
            }
        }
    }
}