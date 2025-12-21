// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents a BACnet device object reference that identifies an object,
/// optionally qualified by the device that contains it.
/// </summary>
/// <param name="DeviceIdentifier">
/// The optional identifier of the device containing the object.
/// When <c>null</c>, the object is assumed to be in the local device or context.
/// </param>
/// <param name="ObjectIdentifier">
/// The identifier of the referenced object.
/// </param>
public readonly record struct DeviceObjectReference(
    ObjectIdentifier? DeviceIdentifier,
    ObjectIdentifier ObjectIdentifier)
{
}