// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ClientCovCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ClientCov>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ClientCov>
{
    public static bool Matches(ref NativeReader reader)
    {
        var applicationTagNumber = reader.PeekApplicationTagNumber();
        switch (applicationTagNumber)
        {
            case ApplicationTagNumber.Real:
            case ApplicationTagNumber.Null:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.ClientCov Decode(ref NativeReader reader)
    {
        // info
        if (reader.PeekTag(RealCodec.TagNumber))
        {
            //var _realIncrement = Asdu.Decode<RealCodec, float>(ref reader);
            var _realIncrement = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ClientCov.FromRealIncrement(_realIncrement);
        }
        // info
        if (reader.PeekTag(NullCodec.TagNumber))
        {
            //var _defaultIncrement = Asdu.Decode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref reader);
            var _defaultIncrement = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ClientCov.FromDefaultIncrement(_defaultIncrement);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ClientCov Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.ClientCov value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ClientCov.Option.RealIncrement:
                //Asdu.Encode<RealCodec, float>(ref writer, value.RealIncrement);
                RealCodec.Encode(ref writer, value.RealIncrement);
                return;
            case global::Baclib.Bacnet.Types.Application.ClientCov.Option.DefaultIncrement:
                //Asdu.Encode<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(ref writer, value.DefaultIncrement);
                NullCodec.Encode(ref writer, value.DefaultIncrement);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ClientCov value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ClientCov value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ClientCov.Option.RealIncrement:
                return Asdu.GetEncodedLength<RealCodec, float>(value.RealIncrement);
            case global::Baclib.Bacnet.Types.Application.ClientCov.Option.DefaultIncrement:
                return Asdu.GetEncodedLength<NullCodec, global::Baclib.Bacnet.Types.Application.Null>(value.DefaultIncrement);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.ClientCov value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}