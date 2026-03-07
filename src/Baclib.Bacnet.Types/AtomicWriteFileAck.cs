// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

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

    private object _choiceValue
    {
        get;
    }

    private AtomicWriteFileAck(Option choice, object value)
    {
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FileStartPosition)} hat das Template erstellt");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The starting byte position where data was written (for stream access).
    /// </summary>
    public static AtomicWriteFileAck NewFileStartPosition(int value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FileStartRecord)} hat das Template erstellt");
            }
            return (int)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The starting record number where data was written (for record access).
    /// </summary>
    public static AtomicWriteFileAck NewFileStartRecord(int value)
    {
        return new AtomicWriteFileAck(Option.FileStartRecord, value);
    }
}
