// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetHealth as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Health
{
    /// <summary>
    /// The date and time when the health status was determined.
    /// </summary>
    public required DateTime Timestamp { get; init; }

    /// <summary>
    /// The error information indicating the health status or any problems detected.
    /// </summary>
    public required Error Result { get; init; }

    /// <summary>
    /// Optional property identifier related to the health status.
    /// </summary>
    public Optional<PropertyIdentifier> Property { get; init; }

    /// <summary>
    /// Optional additional details describing the health status or issue.
    /// </summary>
    public Optional<CharacterString> Details { get; init; }
}
