using System.Runtime.InteropServices;
using Stride.Rendering;
using VL.Core.CompilerServices;

[assembly: AssemblyInitializer(typeof(VLShaderStructInitializer.Initializer))]

namespace VLShaderStructInitializer
{
    public sealed class Initializer : AssemblyInitializer<Initializer>
    {
        protected override void RegisterServices(VL.Core.IVLFactory factory)
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(
                typeof(MyCustomShaderBaseKeys).TypeHandle
            );
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MyCustomShaderStruct
    {
        public float Test;

        public MyCustomShaderStruct(float test)
        {
            Test = test;
        }
    }

    public static class MyCustomShaderBaseKeys
    {
        public static readonly ValueParameterKey<MyCustomShaderStruct> MyStructInput =
            ParameterKeys.NewValue<MyCustomShaderStruct>(
                new MyCustomShaderStruct(),
                "MyCustomShaderBase.MyStructInput"
            );
    }
}
