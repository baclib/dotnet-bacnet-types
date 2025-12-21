// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetFileAccessMethod as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum FileAccessMethod : byte
{
    /// <summary>
    /// File access by record.
    /// </summary>
    RecordAccess = 0,

    /// <summary>
    /// File access by stream.
    /// </summary>
    StreamAccess = 1
}
