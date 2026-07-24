// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class OptionalDoorValueCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.OptionalDoorValue>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.OptionalDoorValue>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekApplicationTag(out var applicationTagNumber))
        {
            return false;
        }
        return applicationTagNumber switch
        {
            ApplicationTagNumber.Null or
            ApplicationTagNumber.Enumerated => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDoorValue Decode(ref AsduReader reader)
    {
        if (NullCodec.Matches(ref reader))
        {
            var @null = NullCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalDoorValue.FromNull(@null);
        }
        if (DoorValueCodec.Matches(ref reader))
        {
            var @doorValue = DoorValueCodec.Decode(ref reader);
            return global::Baclib.Bacnet.Types.Application.OptionalDoorValue.FromDoorValue(@doorValue);
        }

        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.OptionalDoorValue Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<OptionalDoorValueCodec, global::Baclib.Bacnet.Types.Application.OptionalDoorValue>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.OptionalDoorValue value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.OptionalDoorValue.Option.Null:
                NullCodec.Encode(ref writer, value.Null);
                return;
            case global::Baclib.Bacnet.Types.Application.OptionalDoorValue.Option.DoorValue:
                DoorValueCodec.Encode(ref writer, value.DoorValue);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.OptionalDoorValue value)
        => AsduConstructed.Encode<OptionalDoorValueCodec, global::Baclib.Bacnet.Types.Application.OptionalDoorValue>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDoorValue value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.OptionalDoorValue.Option.Null
                => NullCodec.GetEncodedLength(value.Null),
            global::Baclib.Bacnet.Types.Application.OptionalDoorValue.Option.DoorValue
                => DoorValueCodec.GetEncodedLength(value.DoorValue),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.OptionalDoorValue value, byte tagNumber)
        => AsduElement.GetEncodedLength<OptionalDoorValueCodec, global::Baclib.Bacnet.Types.Application.OptionalDoorValue>(tagNumber, value);
}
