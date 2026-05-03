// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetDeviceObjectReference as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DeviceObjectReference
{
    /// <summary>
    /// The identifier of the BACnet device containing the object. Should be omitted if the object is local.
    /// </summary>
    public Optional<ObjectIdentifier> DeviceIdentifier { get; init; }

    /// <summary>
    /// The identifier of the BACnet object being referenced.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    }
