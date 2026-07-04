// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AccessRuleCodec :
    IAsduElementCodec<T::AccessRule>,
    IAsduConstructedCodec<T::AccessRule>
{
    public static T::AccessRule Decode(ref AsduReader reader)
    {
        return new T::AccessRule
        {
            TimeRangeSpecifier = AsduElement.Decode<AccessRuleTTimeRangeSpecifierCodec, T::AccessRule.TTimeRangeSpecifier>(ref reader, 0),
            TimeRange = AsduElement.DecodeOptional<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref reader, 1),
            LocationSpecifier = AsduElement.Decode<AccessRuleTLocationSpecifierCodec, T::AccessRule.TLocationSpecifier>(ref reader, 2),
            Location = AsduElement.DecodeOptional<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref reader, 3),
            Enable = AsduElement.Decode<BooleanCodec, bool>(ref reader, 4)
        };
    }

    public static T::AccessRule Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AccessRuleCodec, T::AccessRule>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::AccessRule value)
    {
        AsduElement.Encode<AccessRuleTTimeRangeSpecifierCodec, T::AccessRule.TTimeRangeSpecifier>(ref writer, 0, value.TimeRangeSpecifier);
        AsduElement.EncodeOptional<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(ref writer, 1, value.TimeRange);
        AsduElement.Encode<AccessRuleTLocationSpecifierCodec, T::AccessRule.TLocationSpecifier>(ref writer, 2, value.LocationSpecifier);
        AsduElement.EncodeOptional<DeviceObjectReferenceCodec, T::DeviceObjectReference>(ref writer, 3, value.Location);
        AsduElement.Encode<BooleanCodec, bool>(ref writer, 4, value.Enable);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::AccessRule value)
        => AsduConstructed.Encode<AccessRuleCodec, T::AccessRule>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::AccessRule value)
    {
        var length = 0;
        length += AsduElement.GetEncodedLength<AccessRuleTTimeRangeSpecifierCodec, T::AccessRule.TTimeRangeSpecifier>(0, value.TimeRangeSpecifier);
        length += AsduElement.GetOptionalEncodedLength<DeviceObjectPropertyReferenceCodec, T::DeviceObjectPropertyReference>(1, value.TimeRange);
        length += AsduElement.GetEncodedLength<AccessRuleTLocationSpecifierCodec, T::AccessRule.TLocationSpecifier>(2, value.LocationSpecifier);
        length += AsduElement.GetOptionalEncodedLength<DeviceObjectReferenceCodec, T::DeviceObjectReference>(3, value.Location);
        length += AsduElement.GetEncodedLength<BooleanCodec, bool>(4, value.Enable);
        return length;
    }

    public static int GetEncodedLength(in T::AccessRule value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<AccessRuleCodec, T::AccessRule>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
