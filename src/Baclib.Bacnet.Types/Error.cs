// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Error
{
    /// <summary>
    /// The class or category of the error.
    /// </summary>
    public required TErrorClass ErrorClass { get; init; }
    
    /// <summary>
    /// The specific error code providing detailed information about the failure.
    /// </summary>
    public required TErrorCode ErrorCode { get; init; }
    }
