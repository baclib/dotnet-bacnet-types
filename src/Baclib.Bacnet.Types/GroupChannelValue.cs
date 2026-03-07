// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetGroupChannelValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class GroupChannelValue
{
    /// <summary>
    /// The channel number being controlled.
    /// </summary>
    public required Unsigned16 Channel { get; init; }
    
    /// <summary>
    /// The value to be written to the channel.
    /// </summary>
    public required ChannelValue Value { get; init; }
    
    /// <summary>
    /// Optional priority level for the channel value (1-16, where 1 is highest priority).
    /// </summary>
    public TOverridingPriority? OverridingPriority { get; init; }
}
