// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence VT-Open-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VtOpenAck
{
    /// <summary>
    /// The identifier assigned to the remote VT session.
    /// </summary>
    public required Unsigned8 RemoteVtSessionIdentifier { get; init; }
    }
