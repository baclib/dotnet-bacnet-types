// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using T = Baclib.Bacnet.Types.Application;

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class FaultParameterTFaultCharacterstringCodec :
    IAsduElementCodec<T::FaultParameter.TFaultCharacterstring>,
    IAsduConstructedCodec<T::FaultParameter.TFaultCharacterstring>
{
    public static T::FaultParameter.TFaultCharacterstring Decode(ref AsduReader reader)
    {
        return new T::FaultParameter.TFaultCharacterstring
        {
            ListOfFaultValues = AsduElement.DecodeSequenceOf<CharacterStringCodec, T::CharacterString>(ref reader, 0)
        };
    }

    public static T::FaultParameter.TFaultCharacterstring Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<FaultParameterTFaultCharacterstringCodec, T::FaultParameter.TFaultCharacterstring>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in T::FaultParameter.TFaultCharacterstring value)
    {
        AsduElement.EncodeSequenceOf<CharacterStringCodec, T::CharacterString>(ref writer, 0, value.ListOfFaultValues);
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in T::FaultParameter.TFaultCharacterstring value)
        => AsduConstructed.Encode<FaultParameterTFaultCharacterstringCodec, T::FaultParameter.TFaultCharacterstring>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in T::FaultParameter.TFaultCharacterstring value)
    {
        var length = 0;
        length += AsduElement.GetSequenceOfEncodedLength<CharacterStringCodec, T::CharacterString>(0, value.ListOfFaultValues);
        return length;
    }

    public static int GetEncodedLength(in T::FaultParameter.TFaultCharacterstring value, byte tagNumber)
        => AsduConstructed.GetEncodedLength<FaultParameterTFaultCharacterstringCodec, T::FaultParameter.TFaultCharacterstring>(tagNumber, value);

    public static bool Matches(ref AsduReader reader)
    {
        return reader.PeekContextTag(0);
    }
}
