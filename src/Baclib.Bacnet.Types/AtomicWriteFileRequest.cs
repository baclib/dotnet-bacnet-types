// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence AtomicWriteFile-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AtomicWriteFileRequest
{
    /// <summary>
    /// The object identifier of the file to write to.
    /// </summary>
    public required ObjectIdentifier FileIdentifier { get; init; }
    
    /// <summary>
    /// The access method and data to write.
    /// </summary>
    public required TAccessMethod AccessMethod { get; init; }
    }
