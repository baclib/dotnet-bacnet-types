// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence WriteGroup-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class WriteGroupRequest
{
    /// <summary>
    /// The group number identifying the set of channels to write.
    /// </summary>
    public required Unsigned32 GroupNumber { get; init; }
    
    /// <summary>
    /// The priority to use for the write operation.
    /// </summary>
    public required TWritePriority WritePriority { get; init; }
    
    /// <summary>
    /// A list of values to be written to the group channels.
    /// </summary>
    public required TChangeList ChangeList { get; init; }
    
    /// <summary>
    /// If true, delays the write operation. Optional.
    /// </summary>
    public Optional<Boolean> InhibitDelay { get; init; }
}
