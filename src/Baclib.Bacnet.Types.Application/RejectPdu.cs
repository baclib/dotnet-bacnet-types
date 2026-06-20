// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public sealed record class RejectPdu
{
    public Pdu.Option Type => Pdu.Option.RejectPdu;

    public byte OriginalInvokeId { get; init; }

    public RejectReason RejectReason { get; init; }
}
