// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetPrescale as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Prescale
{
    /// <summary>
    /// The multiplier value for prescaling.
    /// </summary>
    public required Unsigned Multiplier { get; init; }
    
    /// <summary>
    /// The modulo divide value for prescaling.
    /// </summary>
    public required Unsigned ModuloDivide { get; init; }
    }
