// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence VT-Open-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class VtOpenRequest
{
    /// <summary>
    /// The class of the virtual terminal to be opened.
    /// </summary>
    public required VtClass VtClass { get; init; }
    
    /// <summary>
    /// The identifier assigned to the local VT session.
    /// </summary>
    public required Unsigned8 LocalVtSessionIdentifier { get; init; }
    }
