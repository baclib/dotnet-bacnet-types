// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence AtomicReadFile-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AtomicReadFileRequest
{
    /// <summary>
    /// The object identifier of the file to read from.
    /// </summary>
    public required ObjectIdentifier FileIdentifier { get; init; }
    
    /// <summary>
    /// The access method specifying what data to read.
    /// </summary>
    public required TAccessMethod AccessMethod { get; init; }
    }
