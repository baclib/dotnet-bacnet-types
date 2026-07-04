// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ProcessIdSelectionCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ProcessIdSelection>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ProcessIdSelection>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        return applicationTagNumber switch
        {
            ApplicationTagNumber.Unsigned or
            ApplicationTagNumber.Null => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ProcessIdSelection Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @processIdentifier = Unsigned32Codec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ProcessIdSelection.FromProcessIdentifier(@processIdentifier);
        }
        if (NullCodec.Matches(ref reader))
        {
            var @nullValue = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.ProcessIdSelection.FromNullValue(@nullValue);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ProcessIdSelection Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ProcessIdSelectionCodec, global::Baclib.Bacnet.Types.Application.ProcessIdSelection>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.ProcessIdentifier:
                Unsigned32Codec.Encode(ref writer, value.ProcessIdentifier);
                return;
            case global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.NullValue:
                NullCodec.Encode(ref writer, value.NullValue);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value)
        => AsduConstructed.Encode<ProcessIdSelectionCodec, global::Baclib.Bacnet.Types.Application.ProcessIdSelection>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.ProcessIdentifier
                => Unsigned32Codec.GetEncodedLength(value.ProcessIdentifier),
            global::Baclib.Bacnet.Types.Application.ProcessIdSelection.Option.NullValue
                => NullCodec.GetEncodedLength(value.NullValue),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ProcessIdSelection value, byte tagNumber)
        => AsduElement.GetEncodedLength<ProcessIdSelectionCodec, global::Baclib.Bacnet.Types.Application.ProcessIdSelection>(tagNumber, value);
}
