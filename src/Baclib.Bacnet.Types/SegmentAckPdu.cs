// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public sealed record class SegmentAckPdu
{
    public Pdu.Option Type => Pdu.Option.SegmentAckPdu;

    public bool IsNak { get; init; }

    public bool IsSentByServer { get; init; }

    public byte OriginalInvokeId { get; init; }

    public byte SequenceNumber { get; init; }

    public byte ActualWindowSize { get; init; }
}
