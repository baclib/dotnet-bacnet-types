// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetVTSession as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VtSession
{
    /// <summary>
    /// The identifier for the local VT session.
    /// </summary>
    public required Unsigned8 LocalVtSessionId { get; init; }
    
    /// <summary>
    /// The identifier for the remote VT session.
    /// </summary>
    public required Unsigned8 RemoteVtSessionId { get; init; }
    
    /// <summary>
    /// The address of the remote VT session.
    /// </summary>
    public required Address RemoteVtAddress { get; init; }
    }
