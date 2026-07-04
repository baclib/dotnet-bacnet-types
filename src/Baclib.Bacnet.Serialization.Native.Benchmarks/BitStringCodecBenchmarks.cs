using BenchmarkDotNet.Attributes;

namespace Baclib.Bacnet.Serialization.Native.Benchmarks;

[MemoryDiagnoser]
public class BitStringCodecBenchmarks
{
    private const int OperationsPerInvoke = 1024;

    private static readonly byte[] Encoded8 = [0x82, 0x00, 0xF0];
    private static readonly byte[] Encoded16 = [0x83, 0x00, 0xF0, 0x0F];
    private static readonly byte[] Encoded32 = [0x85, 0x05, 0x00, 0x1E, 0x6A, 0x2C, 0x48];
    private static readonly byte[] Encoded64 = [0x85, 0x09, 0x00, 0x0F, 0x7B, 0x3D, 0x59, 0x1E, 0x6A, 0x2C, 0x48];

    private static readonly BitString8 Value8 = new(0xF0, count: 8);
    private static readonly BitString16 Value16 = new(0x0FF0, count: 16);
    private static readonly BitString32 Value32 = new(0x12345678, count: 32);
    private static readonly BitString64 Value64 = new(0x123456789ABCDEF0, count: 64);

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int DecodeBitString8()
    {
        int sum = 0;
        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            var reader = new AsduReader(Encoded8);
            sum += BitString8Codec.Decode(ref reader).Length;
        }

        return sum;
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int DecodeBitString16()
    {
        int sum = 0;
        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            var reader = new AsduReader(Encoded16);
            sum += BitString16Codec.Decode(ref reader).Length;
        }

        return sum;
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int DecodeBitString32()
    {
        int sum = 0;
        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            var reader = new AsduReader(Encoded32);
            sum += BitString32Codec.Decode(ref reader).Length;
        }

        return sum;
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int DecodeBitString64()
    {
        int sum = 0;
        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            var reader = new AsduReader(Encoded64);
            sum += BitString64Codec.Decode(ref reader).Length;
        }

        return sum;
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int EncodeBitString8()
    {
        int sum = 0;
        var writer = new AsduWriter(BitString8Codec.GetEncodedLength(Value8));

        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            writer.Reset();
            BitString8Codec.Encode(ref writer, in Value8);
            sum += writer.WrittenLength;
        }

        return sum;
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int EncodeBitString16()
    {
        int sum = 0;
        var writer = new AsduWriter(BitString16Codec.GetEncodedLength(Value16));

        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            writer.Reset();
            BitString16Codec.Encode(ref writer, in Value16);
            sum += writer.WrittenLength;
        }

        return sum;
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int EncodeBitString32()
    {
        int sum = 0;
        var writer = new AsduWriter(BitString32Codec.GetEncodedLength(Value32));

        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            writer.Reset();
            BitString32Codec.Encode(ref writer, in Value32);
            sum += writer.WrittenLength;
        }

        return sum;
    }

    [Benchmark(OperationsPerInvoke = OperationsPerInvoke)]
    public int EncodeBitString64()
    {
        int sum = 0;
        var writer = new AsduWriter(BitString64Codec.GetEncodedLength(Value64));

        for (int i = 0; i < OperationsPerInvoke; i++)
        {
            writer.Reset();
            BitString64Codec.Encode(ref writer, in Value64);
            sum += writer.WrittenLength;
        }

        return sum;
    }
}
