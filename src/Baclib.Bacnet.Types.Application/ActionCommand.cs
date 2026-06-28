// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetActionCommand as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ActionCommand
{
    /// <summary>
    /// The optional device identifier (if different from the local device).
    /// </summary>
    public Optional<ObjectIdentifier> DeviceIdentifier { get; init; }

    /// <summary>
    /// The object identifier containing the property to write.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }

    /// <summary>
    /// The property identifier to write to.
    /// </summary>
    public required PropertyIdentifier PropertyIdentifier { get; init; }

    /// <summary>
    /// Optional array index if the property is an array.
    /// </summary>
    public Optional<Unsigned> PropertyArrayIndex { get; init; }

    /// <summary>
    /// The value to write to the property.
    /// </summary>
    public required Any PropertyValue { get; init; }

    /// <summary>
    /// Optional priority level for the write operation (1-16).
    /// </summary>
    public Optional<TPriority> Priority { get; init; }

    /// <summary>
    /// Optional delay in seconds after executing this command before the next.
    /// </summary>
    public Optional<Unsigned> PostDelay { get; init; }

    /// <summary>
    /// Indicates whether to stop executing subsequent commands if this one fails.
    /// </summary>
    public required Boolean QuitOnFailure { get; init; }

    /// <summary>
    /// Indicates whether the write operation was successful.
    /// </summary>
    public required Boolean WriteSuccessful { get; init; }
}
