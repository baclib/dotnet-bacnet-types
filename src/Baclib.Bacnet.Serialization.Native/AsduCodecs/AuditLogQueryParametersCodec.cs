// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryParametersCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _byTarget = Asdu.DecodeConstructed<AuditLogQueryParametersTByTargetCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.FromByTarget(_byTarget);
            case 1:
                var _bySource = Asdu.DecodeConstructed<AuditLogQueryParametersTBySourceCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.FromBySource(_bySource);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.ByTarget:
                Asdu.EncodeConstructed<AuditLogQueryParametersTByTargetCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget>(ref writer, 0, value.ByTarget);
                return;
            case global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.BySource:
                Asdu.EncodeConstructed<AuditLogQueryParametersTBySourceCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource>(ref writer, 1, value.BySource);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.ByTarget:
                return Asdu.GetConstructedLength<AuditLogQueryParametersTByTargetCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TByTarget>(0, value.ByTarget);
            case global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.BySource:
                return Asdu.GetConstructedLength<AuditLogQueryParametersTBySourceCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.TBySource>(1, value.BySource);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}