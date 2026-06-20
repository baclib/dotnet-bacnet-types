// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetLifeSafetyOperationInfo as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LifeSafetyOperationInfo
{
    /// <summary>
    /// The identifier of the process that requested the life safety operation.
    /// </summary>
    public required Unsigned32 RequestingProcessIdentifier { get; init; }
    
    /// <summary>
    /// The life safety operation that was requested.
    /// </summary>
    public required LifeSafetyOperation Request { get; init; }
    }
