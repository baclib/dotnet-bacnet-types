// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.Codecs;

public sealed class NullCodec : INativeCodec<Null>
{
    private NullCodec()
    {
    }

    public static NullCodec Instance { get; } = new();

    public int GetEncodedSize(in Null value) => AsduLength.Sum(ApplicationTagNumber.Null, AsduLength.Null);

    public int GetEncodedSize(byte tagNumber, in Null value) => AsduLength.Sum(tagNumber, AsduLength.Null);

    public void Encode(ref AsduEncoder encoder, in Null _) => encoder.Encode(ApplicationTagNumber.Null, AsduLength.Null);

    public void Encode(ref AsduEncoder encoder, byte tagNumber, in Null _) => encoder.Encode(tagNumber, AsduLength.Null);

    public Null Decode(ref NativeReader decoder)
    {
        decoder.Decode(ApplicationTagNumber.Null, AsduLength.Null);
        return Null.Value;
    }

    public Null Decode(ref NativeReader decoder, byte tagNumber)
    {
        decoder.Decode(tagNumber, AsduLength.Null);
        return Null.Value;
    }

    public Optional<Null> DecodeOptional(ref NativeReader decoder)
    {
        return decoder.DecodeOptional(ApplicationTagNumber.Null, out _) ? Null.Value : Optional<Null>.None;
    }

    public Optional<Null> DecodeOptional(ref NativeReader decoder, byte tagNumber)
    {
        return decoder.DecodeOptional(tagNumber, out _) ? Null.Value : Optional<Null>.None;
    }
}

