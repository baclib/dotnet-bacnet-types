using Baclib.Bacnet.Types;

namespace Baclib.Bacnet.Serialization.Asn1;

public abstract class Asn1Codec
{
    public abstract Type Type { get; }
}

public abstract class Asn1Codec<T> : Asn1Codec, IAsn1Codec<T>
{
    public sealed override Type Type => typeof(T);

    public abstract int GetEncodedSize(in T value);

    public abstract int GetEncodedSize(byte tagNumber, in T value);

    public abstract void Encode(ref AsduEncoder encoder, in T value);

    public abstract void Encode(ref AsduEncoder encoder, byte tagNumber, in T value);

    public abstract T Decode(ref AsduDecoder decoder);

    public abstract T Decode(ref AsduDecoder decoder, byte tagNumber);

    public abstract Optional<T> DecodeOptional(ref AsduDecoder decoder);

    public abstract Optional<T> DecodeOptional(ref AsduDecoder decoder, byte tagNumber);
}
