// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetAssignedAccessRights as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AssignedAccessRights
{
    /// <summary>
    /// Reference to the access rights object.
    /// </summary>
    public required DeviceObjectReference Reference { get; init; }

    /// <summary>
    /// Indicates whether these access rights are enabled.
    /// </summary>
    public required Boolean Enable { get; init; }
}
