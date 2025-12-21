// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetEventType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum EventType : ushort
{
    /// <summary>
    /// Change of bitstring event.
    /// </summary>
    ChangeOfBitstring = 0,

    /// <summary>
    /// Change of state event.
    /// </summary>
    ChangeOfState = 1,

    /// <summary>
    /// Change of value event.
    /// </summary>
    ChangeOfValue = 2,

    /// <summary>
    /// Command failure event.
    /// </summary>
    CommandFailure = 3,

    /// <summary>
    /// Floating limit event.
    /// </summary>
    FloatingLimit = 4,

    /// <summary>
    /// Out of range event.
    /// </summary>
    OutOfRange = 5,

    /// <summary>
    /// Change of life safety event.
    /// </summary>
    ChangeOfLifeSafety = 8,

    /// <summary>
    /// Extended event type.
    /// </summary>
    Extended = 9,

    /// <summary>
    /// Buffer ready event.
    /// </summary>
    BufferReady = 10,

    /// <summary>
    /// Unsigned range event.
    /// </summary>
    UnsignedRange = 11,

    /// <summary>
    /// Access event.
    /// </summary>
    AccessEvent = 13,

    /// <summary>
    /// Double out of range event.
    /// </summary>
    DoubleOutOfRange = 14,

    /// <summary>
    /// Signed out of range event.
    /// </summary>
    SignedOutOfRange = 15,

    /// <summary>
    /// Unsigned out of range event.
    /// </summary>
    UnsignedOutOfRange = 16,

    /// <summary>
    /// Change of characterstring event.
    /// </summary>
    ChangeOfCharacterstring = 17,

    /// <summary>
    /// Change of status flags event.
    /// </summary>
    ChangeOfStatusFlags = 18,

    /// <summary>
    /// Change of reliability event.
    /// </summary>
    ChangeOfReliability = 19,

    /// <summary>
    /// No event type.
    /// </summary>
    None = 20,

    /// <summary>
    /// Change of discrete value event.
    /// </summary>
    ChangeOfDiscreteValue = 21,

    /// <summary>
    /// Change of timer event.
    /// </summary>
    ChangeOfTimer = 22
}
