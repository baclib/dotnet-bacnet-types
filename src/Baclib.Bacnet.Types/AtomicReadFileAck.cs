// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence AtomicReadFile-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AtomicReadFileAck
{
    /// <summary>
    /// Indicates whether the end of the file has been reached.
    /// </summary>
    public required Boolean EndOfFile { get; init; }
    
    /// <summary>
    /// The access method and data that was read.
    /// </summary>
    public required TAccessMethod AccessMethod { get; init; }
    }
