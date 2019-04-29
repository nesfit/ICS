using BenchmarkDotNet.Running;

namespace ValueVsRef
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DataLocality>();
            BenchmarkRunner.Run<NoGC>();
            BenchmarkRunner.Run<ValueTypeInvokingInterfaceMethod>();
            BenchmarkRunner.Run<ValueTypeInvokingInterfaceMethodSmart>();
            BenchmarkRunner.Run<CopyingValueTypes>();
        }
    }
}