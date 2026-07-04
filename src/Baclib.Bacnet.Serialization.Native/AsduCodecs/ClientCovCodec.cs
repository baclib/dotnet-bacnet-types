// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ClientCovCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ClientCov>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ClientCov>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        return applicationTagNumber switch
        {
            ApplicationTagNumber.Real or
            ApplicationTagNumber.Null => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ClientCov Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @realIncrement = RealCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ClientCov.FromRealIncrement(@realIncrement);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @defaultIncrement = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ClientCov.FromDefaultIncrement(@defaultIncrement);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ClientCov Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ClientCovCodec, global::Baclib.Bacnet.Types.Application.ClientCov>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ClientCov value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ClientCov.Option.RealIncrement:
                RealCodec.Encode(ref writer, value.RealIncrement);
                return;
            case global::Baclib.Bacnet.Types.Application.ClientCov.Option.DefaultIncrement:
                NullCodec.Encode(ref writer, value.DefaultIncrement);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ClientCov value)
        => AsduConstructed.Encode<ClientCovCodec, global::Baclib.Bacnet.Types.Application.ClientCov>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ClientCov value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ClientCov.Option.RealIncrement
                => RealCodec.GetEncodedLength(value.RealIncrement),
            global::Baclib.Bacnet.Types.Application.ClientCov.Option.DefaultIncrement
                => NullCodec.GetEncodedLength(value.DefaultIncrement),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ClientCov value, byte tagNumber)
        => AsduElement.GetEncodedLength<ClientCovCodec, global::Baclib.Bacnet.Types.Application.ClientCov>(tagNumber, value);
}
