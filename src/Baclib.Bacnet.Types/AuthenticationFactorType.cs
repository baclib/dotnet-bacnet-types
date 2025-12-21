// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAuthenticationFactorType as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AuthenticationFactorType : byte
{
    /// <summary>
    /// Undefined authentication factor type.
    /// </summary>
    Undefined = 0,

    /// <summary>
    /// Error in authentication factor type.
    /// </summary>
    Error = 1,

    /// <summary>
    /// Custom authentication factor type.
    /// </summary>
    Custom = 2,

    /// <summary>
    /// Simple number (16-bit) authentication factor.
    /// </summary>
    SimpleNumber16 = 3,

    /// <summary>
    /// Simple number (32-bit) authentication factor.
    /// </summary>
    SimpleNumber32 = 4,

    /// <summary>
    /// Simple number (56-bit) authentication factor.
    /// </summary>
    SimpleNumber56 = 5,

    /// <summary>
    /// Simple alphanumeric authentication factor.
    /// </summary>
    SimpleAlphaNumeric = 6,

    /// <summary>
    /// ABA Track 2 authentication factor.
    /// </summary>
    AbaTrack2 = 7,

    /// <summary>
    /// Wiegand 26 authentication factor.
    /// </summary>
    Wiegand26 = 8,

    /// <summary>
    /// Wiegand 37 authentication factor.
    /// </summary>
    Wiegand37 = 9,

    /// <summary>
    /// Wiegand 37 facility authentication factor.
    /// </summary>
    Wiegand37Facility = 10,

    /// <summary>
    /// Facility 16 card 32 authentication factor.
    /// </summary>
    Facility16Card32 = 11,

    /// <summary>
    /// Facility 32 card 32 authentication factor.
    /// </summary>
    Facility32Card32 = 12,

    /// <summary>
    /// FASC-N authentication factor.
    /// </summary>
    FascN = 13,

    /// <summary>
    /// FASC-N BCD authentication factor.
    /// </summary>
    FascNBcd = 14,

    /// <summary>
    /// FASC-N large authentication factor.
    /// </summary>
    FascNLarge = 15,

    /// <summary>
    /// FASC-N large BCD authentication factor.
    /// </summary>
    FascNLargeBcd = 16,

    /// <summary>
    /// GSA 75 authentication factor.
    /// </summary>
    Gsa75 = 17,

    /// <summary>
    /// CHUID authentication factor.
    /// </summary>
    Chuid = 18,

    /// <summary>
    /// Full CHUID authentication factor.
    /// </summary>
    ChuidFull = 19,

    /// <summary>
    /// GUID authentication factor.
    /// </summary>
    Guid = 20,

    /// <summary>
    /// CBEFF-A authentication factor.
    /// </summary>
    CbeffA = 21,

    /// <summary>
    /// CBEFF-B authentication factor.
    /// </summary>
    CbeffB = 22,

    /// <summary>
    /// CBEFF-C authentication factor.
    /// </summary>
    CbeffC = 23,

    /// <summary>
    /// User password authentication factor.
    /// </summary>
    UserPassword = 24
}
