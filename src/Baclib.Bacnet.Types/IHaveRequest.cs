// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence I-Have-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class IHaveRequest
{
    /// <summary>
    /// The object identifier of the device that contains the object.
    /// </summary>
    public required ObjectIdentifier DeviceIdentifier { get; init; }
    
    /// <summary>
    /// The object identifier of the object being announced.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    
    /// <summary>
    /// The name of the object being announced.
    /// </summary>
    public required CharacterString ObjectName { get; init; }
    }
