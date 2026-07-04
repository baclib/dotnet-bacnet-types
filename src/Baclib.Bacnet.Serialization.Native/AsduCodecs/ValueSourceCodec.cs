// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class ValueSourceCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.ValueSource>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.ValueSource>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 or
            2 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.ValueSource Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @none = NullCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.ValueSource.FromNone(@none);
            case 1:
                var @object = DeviceObjectReferenceCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.ValueSource.FromObject(@object);
            case 2:
                var @address = AddressCodec.Decode(ref reader, 2);
                return global::Baclib.Bacnet.Types.Application.ValueSource.FromAddress(@address);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.ValueSource Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<ValueSourceCodec, global::Baclib.Bacnet.Types.Application.ValueSource>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.ValueSource value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.None:
                NullCodec.Encode(ref writer, 0, value.None);
                return;
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.Object:
                DeviceObjectReferenceCodec.Encode(ref writer, 1, value.Object);
                return;
            case global::Baclib.Bacnet.Types.Application.ValueSource.Option.Address:
                AddressCodec.Encode(ref writer, 2, value.Address);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.ValueSource value)
        => AsduConstructed.Encode<ValueSourceCodec, global::Baclib.Bacnet.Types.Application.ValueSource>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ValueSource value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.ValueSource.Option.None
                => NullCodec.GetEncodedLength(value.None, 0),
            global::Baclib.Bacnet.Types.Application.ValueSource.Option.Object
                => DeviceObjectReferenceCodec.GetEncodedLength(value.Object, 1),
            global::Baclib.Bacnet.Types.Application.ValueSource.Option.Address
                => AddressCodec.GetEncodedLength(value.Address, 2),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.ValueSource value, byte tagNumber)
        => AsduElement.GetEncodedLength<ValueSourceCodec, global::Baclib.Bacnet.Types.Application.ValueSource>(tagNumber, value);
}
