// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence VT-Data-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VtDataRequest
{
    /// <summary>
    /// The identifier of the VT session to which data is sent.
    /// </summary>
    public required Unsigned8 VtSessionIdentifier { get; init; }
    
    /// <summary>
    /// The new data to be sent to the VT session.
    /// </summary>
    public required OctetString VtNewData { get; init; }
    
    /// <summary>
    /// Flag indicating if this is the final block of data (1) or not (0).
    /// </summary>
    public required TVtDataFlag VtDataFlag { get; init; }
    }
