// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence WritePropertyMultiple-Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WritePropertyMultipleError
{
    /// <summary>
    /// The type of error that occurred.
    /// </summary>
    public required Error ErrorType { get; init; }
    
    /// <summary>
    /// Reference to the first property that failed to be written.
    /// </summary>
    public required ObjectPropertyReference FirstFailedWriteAttempt { get; init; }
    }
