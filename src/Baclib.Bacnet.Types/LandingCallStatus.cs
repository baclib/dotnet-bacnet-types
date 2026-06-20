// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetLandingCallStatus as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LandingCallStatus
{
    /// <summary>
    /// The floor number where the landing call was made.
    /// </summary>
    public required Unsigned8 FloorNumber { get; init; }
    
    /// <summary>
    /// The call command, either a direction or a specific destination floor.
    /// </summary>
    public required TCommand Command { get; init; }
    
    /// <summary>
    /// Optional text description of the floor.
    /// </summary>
    public Optional<CharacterString> FloorText { get; init; }
}
