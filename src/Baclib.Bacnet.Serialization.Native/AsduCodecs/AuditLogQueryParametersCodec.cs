// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class AuditLogQueryParametersCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>
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
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @byTarget = AuditLogQueryParametersTByTargetCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.FromByTarget(@byTarget);
            case 1:
                var @bySource = AuditLogQueryParametersTBySourceCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.FromBySource(@bySource);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<AuditLogQueryParametersCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.ByTarget:
                AuditLogQueryParametersTByTargetCodec.Encode(ref writer, 0, value.ByTarget);
                return;
            case global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.BySource:
                AuditLogQueryParametersTBySourceCodec.Encode(ref writer, 1, value.BySource);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value)
        => AsduConstructed.Encode<AuditLogQueryParametersCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.ByTarget
                => AuditLogQueryParametersTByTargetCodec.GetEncodedLength(value.ByTarget, 0),
            global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters.Option.BySource
                => AuditLogQueryParametersTBySourceCodec.GetEncodedLength(value.BySource, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters value, byte tagNumber)
        => AsduElement.GetEncodedLength<AuditLogQueryParametersCodec, global::Baclib.Bacnet.Types.Application.AuditLogQueryParameters>(tagNumber, value);
}
