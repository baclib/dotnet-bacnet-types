// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public sealed record class UnconfirmedRequestPdu
{
    public Pdu.Option Type => Pdu.Option.UnconfirmedRequestPdu;

    public UnconfirmedServiceChoice ServiceChoice { get; init; }

    public ReadOnlyMemory<byte> ServiceRequest { get; init; } = ReadOnlyMemory<byte>.Empty;
}
