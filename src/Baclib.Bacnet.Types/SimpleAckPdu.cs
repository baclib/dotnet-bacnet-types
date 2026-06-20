// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public sealed record class SimpleAckPdu
{
    public Pdu.Option Type => Pdu.Option.SimpleAckPdu;

    public byte OriginalInvokeId { get; init; }

    public ConfirmedServiceChoice ServiceAckChoice { get; init; }
}
