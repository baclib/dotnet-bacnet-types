// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetProgramRequest as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum ProgramRequest : byte
{
    /// <summary>
    /// Program is ready.
    /// </summary>
    Ready = 0,

    /// <summary>
    /// Load program request.
    /// </summary>
    Load = 1,

    /// <summary>
    /// Run program request.
    /// </summary>
    Run = 2,

    /// <summary>
    /// Halt program request.
    /// </summary>
    Halt = 3,

    /// <summary>
    /// Restart program request.
    /// </summary>
    Restart = 4,

    /// <summary>
    /// Unload program request.
    /// </summary>
    Unload = 5
}
