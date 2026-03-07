// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetSetpointReference as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class SetpointReference
{
    /// <summary>
    /// An optional reference to the setpoint property of an object.
    /// </summary>
    public ObjectPropertyReference? Reference { get; init; }
}
