// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public sealed record class ComplexAckPdu
{
    public Pdu.Option Type => Pdu.Option.ComplexAckPdu;

    public bool IsSegmentedResponse { get; init; }

    public bool MoreSegmentsFollow { get; init; }

    public byte OriginalInvokeId { get; init; }

    public byte SequenceNumber { get; init; }

    public byte ProposedWindowSize { get; init; }

    public ConfirmedServiceChoice ServiceAckChoice { get; init; }
}
