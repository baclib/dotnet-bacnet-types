// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence AuthRequest-Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuthRequestError
{
    /// <summary>
    /// The error that occurred during the authentication request.
    /// </summary>
    public required Error ErrorType { get; init; }
    
    /// <summary>
    /// Additional details about the error.
    /// </summary>
    public Optional<CharacterString> ErrorDetails { get; init; }
}
