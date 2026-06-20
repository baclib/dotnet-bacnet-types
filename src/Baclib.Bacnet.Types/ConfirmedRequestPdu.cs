// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public sealed record class ConfirmedRequestPdu
{
    public Pdu.Option Type => Pdu.Option.ConfirmedRequestPdu;

    public enum TMaxSegmentsAccepted
    {
        Unspecified = 0,
        UpTo2 = 1,
        UpTo4 = 2,
        UpTo8 = 3,
        UpTo16 = 4,
        UpTo32 = 5,
        UpTo64 = 6,
        MoreThan64 = 7
    }

    public enum TMaxApduLengthAccepted
    {
        UpTo50 = 0,
        UpTo128 = 1,
        UpTo206 = 2,
        UpTo480 = 3,
        UpTo1024 = 4,
        UpTo1476 = 6
    }

    public bool IsSegmentedRequest { get; init; }

    public bool MoreSegmentsFollow { get; init; }

    public bool AcceptsSegmentedResponses { get; init; }

    public TMaxSegmentsAccepted MaxSegmentsAccepted { get; init; }

    public TMaxApduLengthAccepted MaxApduLengthAccepted { get; init; }

    public byte InvokeId { get; init; }

    public byte SequenceNumber { get; init; }

    public byte ProposedWindowSize { get; init; }

    public ConfirmedServiceChoice ServiceChoice { get; init; }
}
