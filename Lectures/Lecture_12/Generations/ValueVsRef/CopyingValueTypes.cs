using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace ValueVsRef
{
    [RyuJitX64Job, LegacyJitX86Job]
    public class CopyingValueTypes
    {
        class ReferenceType1Field { int X; }
        class ReferenceType2Fields { int X, Y; }
        class ReferenceType3Fields { int X, Y, Z; }

        struct ValueType1Field { int X; }
        struct ValueType2Fields { int X, Y; }
        struct ValueType3Fields { int X, Y, Z; }

        ReferenceType1Field fieldReferenceType1Field = new ReferenceType1Field();
        ReferenceType2Fields fieldReferenceType2Fields = new ReferenceType2Fields();
        ReferenceType3Fields fieldReferenceType3Fields = new ReferenceType3Fields();

        ValueType1Field fieldValueType1Field = new ValueType1Field();
        ValueType2Fields fieldValueType2Fields = new ValueType2Fields();
        ValueType3Fields fieldValueType3Fields = new ValueType3Fields();

        [MethodImpl(MethodImplOptions.NoInlining)] ReferenceType1Field Return(ReferenceType1Field instance) => instance;
        [MethodImpl(MethodImplOptions.NoInlining)] ReferenceType2Fields Return(ReferenceType2Fields instance) => instance;
        [MethodImpl(MethodImplOptions.NoInlining)] ReferenceType3Fields Return(ReferenceType3Fields instance) => instance;

        [MethodImpl(MethodImplOptions.NoInlining)] ValueType1Field Return(ValueType1Field instance) => instance;
        [MethodImpl(MethodImplOptions.NoInlining)] ValueType2Fields Return(ValueType2Fields instance) => instance;
        [MethodImpl(MethodImplOptions.NoInlining)] ValueType3Fields Return(ValueType3Fields instance) => instance;

        [Benchmark(OperationsPerInvoke = 16)]
        public void TestReferenceType1Field()
        {
            var instance = fieldReferenceType1Field;
            instance = Return(instance); instance = Return(instance); instance = Return(instance); instance = Return(instance);
            instance = Return(instance); instance = Return(instance); instance = Return(instance); instance = Return(instance);
            instance = Return(instance); instance = Return(instance); instance = Return(instance); instance = Return(instance);
            instance = Return(instance); instance = Return(instance); instance = Return(instance); instance = Return(instance);
        }

        // removed
    }
}