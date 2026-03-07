// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetxyColor as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class XyColor
{
    /// <summary>
    /// The x chromaticity coordinate.
    /// </summary>
    public required float XCoordinate { get; init; }
    
    /// <summary>
    /// The y chromaticity coordinate.
    /// </summary>
    public required float YCoordinate { get; init; }
    }
