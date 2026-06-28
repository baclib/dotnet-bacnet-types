// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetNameValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class NameValue
{
    /// <summary>
    /// The name associated with the value.
    /// </summary>
    public required CharacterString Name { get; init; }

    /// <summary>
    /// The value associated with the name. Optional.
    /// </summary>
    public Optional<Any> Value { get; init; }
}
