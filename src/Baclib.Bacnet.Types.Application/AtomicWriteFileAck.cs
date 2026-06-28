// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice AtomicWriteFile-ACK as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AtomicWriteFileAck
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// The starting byte position where data was written (for stream access).
        /// </summary>
        FileStartPosition,

        /// <summary>
        /// The starting record number where data was written (for record access).
        /// </summary>
        FileStartRecord
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private readonly object _choiceValue;

    private AtomicWriteFileAck(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// The starting byte position where data was written (for stream access).
    /// </summary>
    public int FileStartPosition
    {
        get
        {
            if (Choice != Option.FileStartPosition)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FileStartPosition)}.");
            }
            return (int)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FileStartPosition"/>.
    /// </summary>
    public bool TryGetFileStartPosition(out int value)
    {
        if (Choice == Option.FileStartPosition)
        {
            value = (int)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FileStartPosition"/> option.
    /// </summary>
    public static AtomicWriteFileAck FromFileStartPosition(int value)
    {
        return new AtomicWriteFileAck(Option.FileStartPosition, value);
    }

    /// <summary>
    /// The starting record number where data was written (for record access).
    /// </summary>
    public int FileStartRecord
    {
        get
        {
            if (Choice != Option.FileStartRecord)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FileStartRecord)}.");
            }
            return (int)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.FileStartRecord"/>.
    /// </summary>
    public bool TryGetFileStartRecord(out int value)
    {
        if (Choice == Option.FileStartRecord)
        {
            value = (int)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.FileStartRecord"/> option.
    /// </summary>
    public static AtomicWriteFileAck FromFileStartRecord(int value)
    {
        return new AtomicWriteFileAck(Option.FileStartRecord, value);
    }
}
