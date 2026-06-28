// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetActionList as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ActionList
{
    /// <summary>
    /// A list of action commands.
    /// </summary>
    public required SequenceOf<ActionCommand> Action { get; init; }
}
