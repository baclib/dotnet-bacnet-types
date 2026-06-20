// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public sealed record class AbortPdu
{
    public Pdu.Option Type => Pdu.Option.AbortPdu;

    public bool IsSentByServer { get; init; }

    public byte OriginalInvokeId { get; init; }

    public AbortReason AbortReason { get; init; }
}
