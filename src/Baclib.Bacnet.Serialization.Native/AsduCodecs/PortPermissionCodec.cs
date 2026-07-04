// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class PortPermissionCodec :
    IAsduElementCodec<T::PortPermission>,
    IAsduConstructedCodec<T::PortPermission>
{
    public static T::PortPermission Decode(ref AsduReader reader)
    {
        return new T::PortPermission
        {
            PortId = AsduElement.Decode<Unsigned8Codec, byte>(ref reader, 0),
            Enabled = AsduElement.Decode<BooleanCodec, bool>(ref reader, 1)
        };
    }

    public static T::PortPermission Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<PortPermissionCodec, T::PortPermission>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::PortPermission value)
    {
        AsduElement.Encode<Unsigned8Codec, byte>(ref writer, 0, value.PortId);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 1, value.Enabled);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::PortPermission value)
        => AsduConstructed.Encode<PortPermissionCodec, T::PortPermission>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::PortPermission value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<Unsigned8Codec, byte>(0, value.PortId);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(1, value.Enabled);
        return length;
    }

    public static int GetEncodedLength(in T::PortPermission value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<PortPermissionCodec, T::PortPermission>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
