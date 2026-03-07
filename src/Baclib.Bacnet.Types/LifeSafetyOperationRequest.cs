// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence LifeSafetyOperation-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LifeSafetyOperationRequest
{
    /// <summary>
    /// The identifier of the process making the life safety operation request.
    /// </summary>
    public required Unsigned32 RequestingProcessIdentifier { get; init; }
    
    /// <summary>
    /// A character string identifying the source of the request.
    /// </summary>
    public required CharacterString RequestingSource { get; init; }
    
    /// <summary>
    /// The life safety operation being requested.
    /// </summary>
    public required LifeSafetyOperation Request { get; init; }
    
    /// <summary>
    /// Optional identifier of the target BACnet object for the operation.
    /// </summary>
    public ObjectIdentifier? ObjectIdentifier { get; init; }
}
