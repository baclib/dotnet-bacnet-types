// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetRejectReason as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum RejectReason : byte
{
    /// <summary>
    /// Other reject reason.
    /// </summary>
    Other = 0,

    /// <summary>
    /// Buffer overflow.
    /// </summary>
    BufferOverflow = 1,

    /// <summary>
    /// Inconsistent parameters.
    /// </summary>
    InconsistentParameters = 2,

    /// <summary>
    /// Invalid parameter data type.
    /// </summary>
    InvalidParameterDataType = 3,

    /// <summary>
    /// Invalid tag.
    /// </summary>
    InvalidTag = 4,

    /// <summary>
    /// Missing required parameter.
    /// </summary>
    MissingRequiredParameter = 5,

    /// <summary>
    /// Parameter out of range.
    /// </summary>
    ParameterOutOfRange = 6,

    /// <summary>
    /// Too many arguments.
    /// </summary>
    TooManyArguments = 7,

    /// <summary>
    /// Undefined enumeration.
    /// </summary>
    UndefinedEnumeration = 8,

    /// <summary>
    /// Unrecognized service.
    /// </summary>
    UnrecognizedService = 9,

    /// <summary>
    /// Invalid data encoding.
    /// </summary>
    InvalidDataEncoding = 10
}
