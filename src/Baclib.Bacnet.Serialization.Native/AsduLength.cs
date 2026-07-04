// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Reflection;

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides constants and static methods for calculating the minimum number of bytes required
/// to encode BACnet primitive types according to ANSI/ASHRAE 135-2024 ASDU encoding rules.
/// </summary>
/// <remarks>
/// This class supports both fixed-size and variable-size BACnet types. For variable-size integer types,
/// the returned length is the minimum number of bytes required to encode the value.
/// </remarks>
public abstract class AsduLength
{

    public const int Null = 0;
    public const int Boolean = 1;

    public const int WeekNDay = 3;

    /// <summary>
    /// The number of bytes required to encode an unsigned 8-bit integer (always 1 byte).
    /// </summary>
    public const int Unsigned8 = 1;

    /// <summary>
    /// Returns the number of bytes required to encode an unsigned 8-bit integer.
    /// </summary>
    /// <param name="_">The unsigned 8-bit integer value (not used, always 1 byte).</param>
    /// <returns>Always returns 1.</returns>
    public static int FromUnsigned8(byte _) => Unsigned8;

    /// <summary>
    /// The maximum number of bytes required to encode an unsigned 16-bit integer (2 bytes).
    /// </summary>
    public const int Unsigned16 = 2;

    public const int Unsigned24 = 3;

    public const int Unsigned40 = 5;

    public const int Unsigned48 = 6;

    public const int Unsigned56 = 7;

    /// <summary>
    /// Returns the minimum number of bytes required to encode an unsigned 16-bit integer.
    /// Returns 1 if the value fits in 1 byte, otherwise 2.
    /// </summary>
    /// <param name="value">The unsigned 16-bit integer value.</param>
    /// <returns>1 or 2 bytes, depending on the value.</returns>
    public static int FromUnsigned16(ushort value) => value switch
    {
        < 0x100 => 1,
        _ => Unsigned16
    };

    /// <summary>
    /// Returns the minimum number of bytes required to encode a signed 16-bit integer, treated as unsigned.
    /// Negative values are interpreted as large unsigned values.
    /// </summary>
    /// <param name="value">The signed 16-bit integer value.</param>
    /// <returns>1 or 2 bytes, depending on the value.</returns>
    public static int FromUnsigned16(short value) => FromUnsigned16((ushort)value);

    /// <summary>
    /// The maximum number of bytes required to encode an unsigned 32-bit integer (4 bytes).
    /// </summary>
    public const int Unsigned32 = 4;

    /// <summary>
    /// Returns the minimum number of bytes required to encode an unsigned 32-bit integer.
    /// Returns 1, 2, 3, or 4 depending on the value.
    /// </summary>
    /// <param name="value">The unsigned 32-bit integer value.</param>
    /// <returns>1 to 4 bytes, depending on the value.</returns>
    public static int FromUnsigned32(uint value) => value switch
    {
        < 0x100 => 1,
        < 0x10000 => 2,
        < 0x1000000 => 3,
        _ => Unsigned32
    };

    /// <summary>
    /// Returns the minimum number of bytes required to encode a signed 32-bit integer, treated as unsigned.
    /// Negative values are interpreted as large unsigned values.
    /// </summary>
    /// <param name="value">The signed 32-bit integer value.</param>
    /// <returns>1 to 4 bytes, depending on the value.</returns>
    public static int FromUnsigned32(int value) => FromUnsigned32((uint)value);

    /// <summary>
    /// The maximum number of bytes required to encode an unsigned 64-bit integer (8 bytes).
    /// </summary>
    public const int Unsigned64 = 8;

    /// <summary>
    /// Returns the minimum number of bytes required to encode an unsigned 64-bit integer.
    /// Returns 1 to 8 depending on the value.
    /// </summary>
    /// <param name="value">The unsigned 64-bit integer value.</param>
    /// <returns>1 to 8 bytes, depending on the value.</returns>
    public static int FromUnsigned64(ulong value) => value switch
    {
        < 0x100 => 1,
        < 0x10000 => 2,
        < 0x1000000 => 3,
        < 0x100000000 => 4,
        < 0x10000000000 => 5,
        < 0x1000000000000 => 6,
        < 0x100000000000000 => 7,
        _ => Unsigned64
    };

    /// <summary>
    /// Returns the minimum number of bytes required to encode a signed 64-bit integer, treated as unsigned.
    /// Negative values are interpreted as large unsigned values.
    /// </summary>
    /// <param name="value">The signed 64-bit integer value.</param>
    /// <returns>1 to 8 bytes, depending on the value.</returns>
    public static int FromUnsigned64(long value) => FromUnsigned64((ulong)value);

    /// <summary>
    /// The number of bytes required to encode a signed 8-bit integer (always 1 byte).
    /// </summary>
    public const int Integer8 = 1;

    public const int Signed8 = 1;
    public const int Signed16 = 2;
    public const int Signed24 = 3;
    public const int Signed32 = 4;
    public const int Signed40 = 5;
    public const int Signed48 = 6;
    public const int Signed56 = 7;
    public const int Signed64 = 8;



    /// <summary>
    /// Returns the number of bytes required to encode a signed 8-bit integer.
    /// </summary>
    /// <param name="_">The signed 8-bit integer value (not used, always 1 byte).</param>
    /// <returns>Always returns 1.</returns>
    public static int FromInteger8(sbyte _) => Integer8;

    /// <summary>
    /// Returns the number of bytes required to encode an unsigned 8-bit integer, treated as signed.
    /// </summary>
    /// <param name="_">The unsigned 8-bit integer value (not used, always 1 byte).</param>
    /// <returns>Always returns 1.</returns>
    public static int FromInteger8(byte _) => Integer8;

    /// <summary>
    /// The maximum number of bytes required to encode a signed 16-bit integer (2 bytes).
    /// </summary>
    public const int Integer16 = 2;

    /// <summary>
    /// Returns the minimum number of bytes required to encode a signed 16-bit integer.
    /// Returns 1 if the value fits in 1 byte, otherwise 2.
    /// </summary>
    /// <param name="value">The signed 16-bit integer value.</param>
    /// <returns>1 or 2 bytes, depending on the value.</returns>
    public static int FromInteger16(short value) => value switch
    {
        >= -0x80 and <= 0x7F => 1,
        _ => Integer16
    };

    /// <summary>
    /// The maximum number of bytes required to encode a signed 32-bit integer (4 bytes).
    /// </summary>
    public const int Integer32 = 4;

    /// <summary>
    /// Returns the minimum number of bytes required to encode a signed 32-bit integer.
    /// Returns 1, 2, 3, or 4 depending on the value.
    /// </summary>
    /// <param name="value">The signed 32-bit integer value.</param>
    /// <returns>1, 2, 3, or 4 bytes, depending on the value.</returns>
    public static int FromInteger32(int value) => value switch
    {
        >= -0x80 and <= 0x7F => 1,
        >= -0x8000 and <= 0x7FFF => 2,
        >= -0x800000 and <= 0x7FFFFF => 3,
        _ => Integer32
    };

    /// <summary>
    /// The maximum number of bytes required to encode a signed 64-bit integer (8 bytes).
    /// </summary>
    public const int Integer64 = 8;

    /// <summary>
    /// Returns the minimum number of bytes required to encode a signed 64-bit integer.
    /// Returns 1 to 8 depending on the value.
    /// </summary>
    /// <param name="value">The signed 64-bit integer value.</param>
    /// <returns>1 to 8 bytes, depending on the value.</returns>
    public static int FromInteger64(long value) => value switch
    {
        >= -0x80 and <= 0x7F => 1,
        >= -0x8000 and <= 0x7FFF => 2,
        >= -0x800000 and <= 0x7FFFFF => 3,
        >= -0x80000000 and <= 0x7FFFFFFF => 4,
        >= -0x8000000000 and <= 0x7FFFFFFFFF => 5,
        >= -0x800000000000 and <= 0x7FFFFFFFFFFF => 6,
        >= -0x80000000000000 and <= 0x7FFFFFFFFFFFFF => 7,
        _ => Integer64
    };

    /// <summary>
    /// The number of bytes required to encode a BACnet Real (32-bit floating point) value.
    /// </summary>
    public const int Real = 4;

    /// <summary>
    /// The number of bytes required to encode a BACnet Double (64-bit floating point) value.
    /// </summary>
    public const int Double = 8;


    public const int BitString8 = 1 + 1;

    public const int BitString16 = 1 + 2;

    public const int BitString24 = 1 + 3;

    public const int BitString32 = 1 + 4;

    public const int BitString40 = 1 + 5;

    public const int BitString48 = 1 + 6;

    public const int BitString56 = 1 + 7;

    public const int BitString64 = 1 + 8;




    public const int Enumerated8 = 1;
    public const int Enumerated16 = 2;
    public const int Enumerated24 = 3;
    public const int Enumerated32 = 4;
    public const int Enumerated40 = 5;
    public const int Enumerated48 = 6;
    public const int Enumerated56 = 7;
    public const int Enumerated64 = 8;




    public static int FromEnumerated<T>(T value) where T : unmanaged, Enum => value switch
    {
        < 0x100 => 1,
        < 0x10000 => 2,
        < 0x1000000 => 3,
        _ => Unsigned32
    };


    /// <summary>
    /// The number of bytes required to encode a BACnet Date value.
    /// </summary>
    public const int Date = 4;

    /// <summary>
    /// The number of bytes required to encode a BACnet Time value.
    /// </summary>
    public const int Time = 4;

    /// <summary>
    /// The number of bytes required to encode a BACnet ObjectIdentifier value.
    /// </summary>
    public const int ObjectIdentifier = 4;

    /// <summary>
    /// Returns the number of bytes required to encode a BACnet tag number.
    /// Returns 1 if the tag number is less than 15, otherwise 2.
    /// </summary>
    /// <param name="number">The tag number (must be between 0 and 254 inclusive).</param>
    /// <returns>1 byte if number is less than 15, otherwise 2 bytes.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="number"/> is less than 0 or greater than 254.
    /// </exception>
    public static int FromTagNumber(byte tagNumber)
    {
        return tagNumber < 15 ? 1 : 2;
    }

    public static int FromTagNumber(ApplicationTagNumber tagNumber)
    {
        return (byte)tagNumber < 15 ? 1 : 2;
    }




    public static int GetEncodedLength<TCodec, T>(in T value)
        where TCodec : IAsduPrimitiveCodec<T>
    {
        return ((byte)TCodec.TagNumber < 15 ? 1 : 2) + TCodec.GetEncodedValueLength(value);
    }




    public static int Sum(ApplicationTagNumber tagNumber, int dataLength) => Sum((byte)tagNumber, dataLength);

    public static int Sum(byte tagNumber, int dataLength)
    {
        int result = tagNumber < 15 ? 1 : 2;
        if (dataLength >= 0)
        {
            if (dataLength <= 4)
            {
                return result + dataLength;
            }
            if (dataLength <= 253)
            {
                return result + 1 + dataLength;
            }
            if (dataLength <= 65535)
            {
                return result + 3 + dataLength;
            }
        }
        return result + 5 + dataLength;
    }


}

