// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: BSD-2-Clause

global using Date = Baclib.Bacnet.Types.DatePattern;
global using Time = Baclib.Bacnet.Types.TimePattern;

using Baclib.Bacnet.Types;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;

namespace Baclib.Bacnet.Serialization.Asn1;

/// <summary>
/// Provides methods for writing BACnet ASDU (Application Service Data Unit) encoded data to a byte buffer.
/// </summary>
/// <remarks>
/// This class implements serialization according to ANSI/ASHRAE 135-2024 Clause 20.2 (ASN.1 Encoding Rules).
/// It supports all BACnet primitive types, constructed types, and context-specific encoding.
/// The writer maintains an internal position index that advances as data is written.
/// </remarks>
public ref struct AsduEncoder
{
    private readonly byte[] _buffer;

    /// <summary>
    /// Gets the underlying byte buffer containing the encoded ASDU data.
    /// </summary>
    public byte[] Buffer => _buffer[.._index];

    int _index = 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsduWriter"/> class with the specified buffer size.
    /// </summary>
    /// <param name="size">The size of the buffer to allocate.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when size is negative.</exception>
    public AsduEncoder(int size)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size), "Size must be non-negative.");
        }
        _buffer = new byte[size];
    }

    /// <summary>
    /// Creates an <see cref="AsduWriter"/> with appropriately sized buffer and serializes the construct.
    /// </summary>
    /// <typeparam name="T">The construct type.</typeparam>
    /// <param name="construct">The construct to serialize.</param>
    /// <returns>An <see cref="AsduWriter"/> containing the serialized data.</returns>
    public static AsduEncoder Create<T>(T construct) where T : IAsduConstruct<T>
    {
        int size = construct.GetAsduSize();
        var writer = new AsduEncoder(size);
        construct.Serialize(ref writer);
        return writer;
    }



    public void WriteByte(byte value)
    {
        _buffer[_index++] = value;
    }






    #region Null

    /// <summary>Writes a Null value with the application Null tag.</summary>
    public void WriteNull() => _buffer[_index++] = 0;

    /// <summary>Writes a Null value with a specific context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    public void WriteNull(int number) => WriteTag(number, 0);

    #endregion

    #region Boolean

    /// <summary>Writes a Boolean value with the application Boolean tag.</summary>
    /// <param name="value">The Boolean value.</param>
    public void WriteBoolean(bool value) => _buffer[_index++] = value ? (byte)0x11 : (byte)0x10;

    /// <summary>Writes a Boolean value with a specific context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    /// <param name="value">The Boolean value.</param>
    public void WriteBoolean(int number, bool value)
    {
        WriteTag(number, 1);
        _buffer[_index++] = (byte)(value ? 1 : 0);
    }

    #endregion

    #region Unsigned8

    private void WriteUnsigned8(AsduTagNumberOld number, byte value)
    {
        WriteTag(number, AsduLength.Unsigned8);
        _buffer[_index++] = value;
    }

    /// <summary>Writes an unsigned 8-bit integer with the application Unsigned tag.</summary>
    /// <param name="value">The unsigned 8-bit integer value.</param>
    public void WriteUnsigned8(byte value) => WriteUnsigned8(AsduTagNumberOld.Unsigned, value);

    /// <summary>Writes an unsigned 8-bit integer with a specific context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    /// <param name="value">The unsigned 8-bit integer value.</param>
    public void WriteUnsigned8(int number, byte value) => WriteUnsigned8(new AsduTagNumberOld(number), value);

    #endregion

    #region Unsigned16

    private void WriteUnsigned16(AsduTagNumberOld number, ushort value)
    {
        var length = AsduLength.FromUnsigned16(value);
        WriteTag(number, length);
        switch (length)
        {
            case 1:
                _buffer[_index++] = (byte)value;
                break;
            case 2:
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 16-bit integer.");
        }
    }

    /// <summary>Writes an unsigned 16-bit integer with the application Unsigned tag.</summary>
    /// <param name="value">The unsigned 16-bit integer value.</param>
    public void WriteUnsigned16(ushort value) => WriteUnsigned16(AsduTagNumberOld.Unsigned, value);

    /// <summary>Writes a signed 16-bit integer (treated as unsigned) with the application Unsigned tag.</summary>
    /// <param name="value">The signed 16-bit integer value.</param>
    public void WriteUnsigned16(short value) => WriteUnsigned16(AsduTagNumberOld.Unsigned, (ushort)value);

    /// <summary>Writes an unsigned 16-bit integer with a specific context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    /// <param name="value">The unsigned 16-bit integer value.</param>
    public void WriteUnsigned16(int number, ushort value) => WriteUnsigned16(new AsduTagNumberOld(number), value);

    /// <summary>Writes a signed 16-bit integer (treated as unsigned) with a specific context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    /// <param name="value">The signed 16-bit integer value.</param>
    public void WriteUnsigned16(int number, short value) => WriteUnsigned16(new AsduTagNumberOld(number), (ushort)value);

    #endregion

    #region Unsigned32








    private void WriteUnsigned32(AsduTagNumberOld number, uint value)
    {
        var length = AsduLength.FromUnsigned32(value);
        WriteTag(number, length);
        switch (length)
        {
            case 1:
                _buffer[_index++] = (byte)value;
                break;
            case 2:
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 3:
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 4:
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 32-bit integer.");
        }
    }

    /// <summary>Writes an unsigned 32-bit integer with the application Unsigned tag.</summary>
    public void WriteUnsigned32(uint value) => WriteUnsigned32(AsduTagNumberOld.Unsigned, value);

    /// <summary>Writes a signed 32-bit integer (treated as unsigned) with the application Unsigned tag.</summary>
    public void WriteUnsigned32(int value) => WriteUnsigned32(AsduTagNumberOld.Unsigned, (uint)value);

    /// <summary>Writes an unsigned 32-bit integer with a specific context tag number.</summary>
    public void WriteUnsigned32(int number, uint value) => WriteUnsigned32(new AsduTagNumberOld(number), value);

    /// <summary>Writes a signed 32-bit integer (treated as unsigned) with a specific context tag number.</summary>
    public void WriteUnsigned32(int number, int value) => WriteUnsigned32(new AsduTagNumberOld(number), (uint)value);

    #endregion

    #region Unsigned64

    private void WriteUnsigned64(AsduTagNumberOld number, ulong value)
    {
        var length = AsduLength.FromUnsigned64(value);
        WriteTag(number, length);
        switch (length)
        {
            case 1:
                _buffer[_index++] = (byte)value;
                break;
            case 2:
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 3:
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 4:
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 5:
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 6:
                _buffer[_index++] = (byte)(value >> 40);
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 7:
                _buffer[_index++] = (byte)(value >> 48);
                _buffer[_index++] = (byte)(value >> 40);
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 8:
                _buffer[_index++] = (byte)(value >> 56);
                _buffer[_index++] = (byte)(value >> 48);
                _buffer[_index++] = (byte)(value >> 40);
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for unsigned 64-bit integer.");
        }
    }

    /// <summary>Writes an unsigned 64-bit integer with the application Unsigned tag.</summary>
    public void WriteUnsigned64(ulong value) => WriteUnsigned64(AsduTagNumberOld.Unsigned, value);

    /// <summary>Writes a signed 64-bit integer (treated as unsigned) with the application Unsigned tag.</summary>
    public void WriteUnsigned64(long value) => WriteUnsigned64(AsduTagNumberOld.Unsigned, (ulong)value);

    /// <summary>Writes an unsigned 64-bit integer with a specific context tag number.</summary>
    public void WriteUnsigned64(int number, ulong value) => WriteUnsigned64(new AsduTagNumberOld(number), value);

    /// <summary>Writes a signed 64-bit integer (treated as unsigned) with a specific context tag number.</summary>
    public void WriteUnsigned64(int number, long value) => WriteUnsigned64(new AsduTagNumberOld(number), (ulong)value);

    #endregion

    #region Integer8

    private void WriteInteger8(AsduTagNumberOld number, sbyte value)
    {
        WriteTag(number, AsduLength.Integer8);
        _buffer[_index++] = (byte)value;
    }

    /// <summary>Writes a signed 8-bit integer with the application Signed tag.</summary>
    public void WriteInteger8(sbyte value) => WriteInteger8(AsduTagNumberOld.Signed, value);

    /// <summary>Writes an unsigned 8-bit integer (treated as signed) with the application Signed tag.</summary>
    public void WriteInteger8(byte value) => WriteInteger8(AsduTagNumberOld.Signed, (sbyte)value);

    /// <summary>Writes a signed 8-bit integer with a specific context tag number.</summary>
    public void WriteInteger8(int number, sbyte value) => WriteInteger8(new AsduTagNumberOld(number), value);

    /// <summary>Writes an unsigned 8-bit integer (treated as signed) with a specific context tag number.</summary>
    public void WriteInteger8(int number, byte value) => WriteInteger8(new AsduTagNumberOld(number), (sbyte)value);

    #endregion

    #region Integer16

    private void WriteInteger16(AsduTagNumberOld number, short value)
    {
        var length = AsduLength.FromInteger16(value);
        WriteTag(number, length);
        switch (length)
        {
            case 1:
                _buffer[_index++] = (byte)value;
                break;
            case 2:
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 16-bit integer.");
        }
    }

    /// <summary>Writes a signed 16-bit integer with the application Signed tag.</summary>
    public void WriteInteger16(short value) => WriteInteger16(AsduTagNumberOld.Signed, value);

    /// <summary>Writes a signed 16-bit integer with a specific context tag number.</summary>
    public void WriteInteger16(int number, short value) => WriteInteger16(new AsduTagNumberOld(number), value);

    #endregion

    #region Integer32

    private void WriteInteger32(AsduTagNumberOld number, int value)
    {
        var length = AsduLength.FromInteger32(value);
        WriteTag(number, length);
        switch (length)
        {
            case 1:
                _buffer[_index++] = (byte)value;
                break;
            case 2:
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 3:
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 4:
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 32-bit integer.");
        }
    }

    /// <summary>Writes a signed 32-bit integer with the application Signed tag.</summary>
    public void WriteInteger32(int value) => WriteInteger32(AsduTagNumberOld.Signed, value);

    /// <summary>Writes a signed 32-bit integer with a specific context tag number.</summary>
    public void WriteInteger32(int number, int value) => WriteInteger32(new AsduTagNumberOld(number), value);

    #endregion

    #region Integer64

    private void WriteInteger64(AsduTagNumberOld number, long value)
    {
        var length = AsduLength.FromInteger64(value);
        WriteTag(number, length);
        switch (length)
        {
            case 1:
                _buffer[_index++] = (byte)value;
                break;
            case 2:
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 3:
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 4:
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 5:
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 6:
                _buffer[_index++] = (byte)(value >> 40);
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 7:
                _buffer[_index++] = (byte)(value >> 48);
                _buffer[_index++] = (byte)(value >> 40);
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            case 8:
                _buffer[_index++] = (byte)(value >> 56);
                _buffer[_index++] = (byte)(value >> 48);
                _buffer[_index++] = (byte)(value >> 40);
                _buffer[_index++] = (byte)(value >> 32);
                _buffer[_index++] = (byte)(value >> 24);
                _buffer[_index++] = (byte)(value >> 16);
                _buffer[_index++] = (byte)(value >> 8);
                _buffer[_index++] = (byte)value;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), "Invalid length for signed 64-bit integer.");
        }
    }

    /// <summary>Writes a signed 64-bit integer with the application Signed tag.</summary>
    public void WriteInteger64(long value) => WriteInteger64(AsduTagNumberOld.Signed, value);

    /// <summary>Writes a signed 64-bit integer with a specific context tag number.</summary>
    public void WriteInteger64(int number, long value) => WriteInteger64(new AsduTagNumberOld(number), value);

    #endregion

    #region Real

    private void WriteRealData(AsduTagNumberOld number, float value)
    {
        WriteTag(number, AsduLength.Real);
        BinaryPrimitives.WriteSingleBigEndian(_buffer.AsSpan(_index, AsduLength.Real), value);
        _index += AsduLength.Real;
    }

    /// <summary>Writes a 32-bit floating-point number with the application Real tag.</summary>
    public void WriteReal(float value) => WriteRealData(AsduTagNumberOld.Real, value);

    /// <summary>Writes a 32-bit floating-point number with a specific context tag number.</summary>
    public void WriteReal(int number, float value) => WriteRealData(new AsduTagNumberOld(number), value);

    #endregion

    #region Double

    private void WriteDoubleData(AsduTagNumberOld number, double value)
    {
        WriteTag(number, AsduLength.Double);
        BinaryPrimitives.WriteDoubleBigEndian(_buffer.AsSpan(_index, AsduLength.Double), value);
        _index += AsduLength.Double;
    }

    /// <summary>Writes a 64-bit floating-point number with the application Double tag.</summary>
    public void WriteDouble(double value) => WriteDoubleData(AsduTagNumberOld.Double, value);

    /// <summary>Writes a 64-bit floating-point number with a specific context tag number.</summary>
    public void WriteDouble(int number, double value) => WriteDoubleData(new AsduTagNumberOld(number), value);

    #endregion

    #region OctetString

    /// <summary>Writes an octet string with a specific tag number.</summary>
    /// <param name="number">The tag number to use.</param>
    /// <param name="value">The octet string value to write.</param>
    public void WriteOctetString(AsduTagNumberOld number, OctetString value)
    {
        WriteTag(number, value.Length);
        value.AsSpan().CopyTo(_buffer.AsSpan(_index));
        _index += value.Length;
    }

    /// <summary>Writes an octet string with the application OctetString tag.</summary>
    public void WriteOctetString(OctetString value) => WriteOctetString(AsduTagNumberOld.OctetString, value);

    /// <summary>Writes an octet string with a specific context tag number.</summary>
    public void WriteOctetString(int number, OctetString value) => WriteOctetString(new AsduTagNumberOld(number), value);

    #endregion

    #region CharacterString

    /// <summary>Writes a BACnet character string with a specific tag number.</summary>
    /// <param name="number">The tag number to use.</param>
    /// <param name="value">The character string value to write.</param>
    public void WriteCharacterString(AsduTagNumberOld number, CharacterString value)
    {
        var encoded = value.ToBytes();
        WriteTag(number, encoded.Length);
        encoded.CopyTo(_buffer.AsSpan(_index));
        _index += encoded.Length;
    }

    /// <summary>Writes a BACnet character string with the application CharacterString tag.</summary>
    public void WriteCharacterString(CharacterString value) => WriteCharacterString(AsduTagNumberOld.CharacterString, value);

    /// <summary>Writes a BACnet character string with a specific context tag number.</summary>
    public void WriteCharacterString(int number, CharacterString value) => WriteCharacterString(new AsduTagNumberOld(number), value);

    #endregion

    #region BitString

    /// <summary>Writes a BACnet bit string with a specific tag number.</summary>
    /// <param name="number">The tag number to use.</param>
    /// <param name="value">The bit string value to write.</param>
    public void WriteBitString(AsduTagNumberOld number, BitString value)
    {
        //TODO: var encoded = value.Encode();
        //WriteTag(number, encoded.Length);
        //encoded.CopyTo(_buffer.AsSpan(_index));
        //_index += encoded.Length;
    }

    /// <summary>Writes a BACnet bit string with the application BitString tag.</summary>
    public void WriteBitString(BitString value) => WriteBitString(AsduTagNumberOld.BitString, value);

    /// <summary>Writes a BACnet bit string with a specific context tag number.</summary>
    public void WriteBitString(int number, BitString value) => WriteBitString(new AsduTagNumberOld(number), value);

    #endregion

    #region Enumerated

    private void WriteEnumerated(AsduTagNumberOld number, Enumerated value) => WriteUnsigned32(number, value);

    /// <summary>Writes a BACnet enumerated value with the application Enumerated tag.</summary>
    public void WriteEnumerated(Enumerated value) => WriteEnumerated(AsduTagNumberOld.Enumerated, value);

    /// <summary>Writes a BACnet enumerated value with a specific context tag number.</summary>
    public void WriteEnumerated(int number, Enumerated value) => WriteEnumerated(new AsduTagNumberOld(number), value);

    #endregion

    #region Date

    private void WriteDate(AsduTagNumberOld number, Date value)
    {
        WriteTag(number, 4);
        _buffer[_index++] = value.Year;
        _buffer[_index++] = value.Month;
        _buffer[_index++] = value.Day;
        _buffer[_index++] = value.DayOfWeek;
    }

    /// <summary>Writes a BACnet date with the application Date tag.</summary>
    public void WriteDate(Date value) => WriteDate(AsduTagNumberOld.Date, value);

    /// <summary>Writes a BACnet date with a specific context tag number.</summary>
    public void WriteDate(int number, Date value) => WriteDate(new AsduTagNumberOld(number), value);

    #endregion

    #region Time

    private void WriteTime(AsduTagNumberOld number, Time value)
    {
        WriteTag(number, 4);
        _buffer[_index++] = value.Hour;
        _buffer[_index++] = value.Minute;
        _buffer[_index++] = value.Second;
        _buffer[_index++] = value.Hundredths;
    }

    /// <summary>Writes a BACnet time with the application Time tag.</summary>
    public void WriteTime(Time value) => WriteTime(AsduTagNumberOld.Time, value);

    /// <summary>Writes a BACnet time with a specific context tag number.</summary>
    public void WriteTime(int number, Time value) => WriteTime(new AsduTagNumberOld(number), value);

    #endregion

    #region ObjectIdentifier

    private void WriteObjectIdentifier(AsduTagNumberOld number, ObjectIdentifier value)
    {
        WriteTag(number, 4);
        BinaryPrimitives.WriteUInt32BigEndian(_buffer.AsSpan(_index, 4), value.Value);
        _index += 4;
    }

    /// <summary>Writes a BACnet object identifier with the application ObjectIdentifier tag.</summary>
    public void WriteObjectIdentifier(ObjectIdentifier value) => WriteObjectIdentifier(AsduTagNumberOld.ObjectIdentifier, value);

    /// <summary>Writes a BACnet object identifier with a specific context tag number.</summary>
    public void WriteObjectIdentifier(int number, ObjectIdentifier value) => WriteObjectIdentifier(new AsduTagNumberOld(number), value);

    #endregion

    #region Construct

    /// <summary>Writes a BACnet construct that implements <see cref="IAsduConstruct{T}"/>.</summary>
    /// <typeparam name="T">The construct type.</typeparam>
    /// <param name="value">The construct to write.</param>
    public void Write<T>(T value) where T : IAsduConstruct<T>
    {
        value.Serialize(ref this);
    }

    /// <summary>Writes a BACnet construct enclosed in opening/closing tags.</summary>
    /// <typeparam name="T">The construct type.</typeparam>
    /// <param name="number">The context tag number for the enclosing tags.</param>
    /// <param name="value">The construct to write.</param>
    public void Write<T>(int number, T value) where T : IAsduConstruct<T>
    {
        WriteOpeningTag(number);
        value.Serialize(ref this);
        WriteClosingTag(number);
    }

    #endregion

    #region Series

    /// <summary>Writes a series of BACnet constructs.</summary>
    /// <typeparam name="T">The construct type.</typeparam>
    /// <param name="series">The series of constructs to write.</param>
    public void WriteSeries<T>(IEnumerable<T> series) where T : IAsduConstruct<T>
    {
        foreach (var item in series)
        {
            Write(item);
        }
    }

    /// <summary>Writes a series of BACnet constructs enclosed in opening/closing tags.</summary>
    /// <typeparam name="T">The construct type.</typeparam>
    /// <param name="number">The context tag number for the enclosing tags.</param>
    /// <param name="series">The series of constructs to write.</param>
    public void WriteSeries<T>(int number, IEnumerable<T> series) where T : IAsduConstruct<T>
    {
        WriteOpeningTag(number);
        WriteSeries(series);
        WriteClosingTag(number);
    }

    #endregion

    #region Tag handling


    public void WriteApplicationTag(ApplicationTagNumber number, int lengthValue)
    {
        throw new NotImplementedException();
    }

    public void WriteContextTag(int number, int length)
    {
        throw new NotImplementedException();
    }


    private void WriteTag(AsduTagNumberOld number, int length)
    {
        ref byte initialOctet = ref _buffer[_index++];
        if (number.Value < 15)
        {
            initialOctet = (byte)(number.Value << 4);
        }
        else
        {
            initialOctet = 0xF0;
            _buffer[_index++] = (byte)number.Value;
        }
        if (number.IsContextClass)
        {
            initialOctet |= 0x08;
        }
        if (length < 5)
        {
            initialOctet |= (byte)length;
        }
        else
        {
            initialOctet |= 0x05;
            if (length < 0xFE)
            {
                _buffer[_index++] = (byte)length;
            }
            else if (length < 0x10000)
            {
                _buffer[_index++] = 254;
                _buffer[_index++] = (byte)(length >> 8);
                _buffer[_index++] = (byte)length;
            }
            else
            {
                _buffer[_index++] = 255;
                _buffer[_index++] = (byte)(length >> 24);
                _buffer[_index++] = (byte)(length >> 16);
                _buffer[_index++] = (byte)(length >> 8);
                _buffer[_index++] = (byte)length;
            }
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void WriteEnclosingTag(int number, AsduTagKind kind)
    {
        if (number < 0 || number > 254)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Number must be between 0 and 254.");
        }

        var mask = (int)kind >> 8;
        if (number < 15)
        {
            _buffer[_index++] = (byte)(number << 4 | mask);
        }
        else
        {
            mask |= 0xF0;
            _buffer[_index++] = (byte)mask;
            _buffer[_index++] = (byte)number;
        }
    }

    /// <summary>Writes an opening tag with the specified context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    public void WriteOpeningTag(int number) => WriteEnclosingTag(number, AsduTagKind.Opening);

    /// <summary>Writes a closing tag with the specified context tag number.</summary>
    /// <param name="number">The context tag number.</param>
    public void WriteClosingTag(int number) => WriteEnclosingTag(number, AsduTagKind.Closing);

    #endregion





    public Span<byte> Encode(byte tagNumber, AsduTagClass tagClass, int lengthValue)
    {
        throw new NotImplementedException();
    }

    public Span<byte> Encode(ApplicationTagNumber tagNumber, int lengthValue)
    {
        throw new NotImplementedException();
    }


    public Span<byte> Encode(byte tagNumber, int lengthValue)
    {
        throw new NotImplementedException();
    }












    /// <summary>
    /// Writes a BACnet Boolean Value.
    /// </summary>
    /// <param name="bytes">A span with at least 1 byte capacity.</param>
    /// <param name="value">The boolean to write.</param>
    public static void WriteBoolean(Span<byte> bytes, bool value)
    {
        bytes[0] = value ? (byte)1 : (byte)0;
    }

    /// <summary>
    /// Writes a BACnet Object Identifier Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The Object Identifier Value to write.</param>
    public static void WriteObjectIdentifier(Span<byte> bytes, ObjectIdentifier value)
    {
        BinaryPrimitives.WriteUInt32BigEndian(bytes, value.Value);
    }

    /// <summary>
    /// Writes a BACnet Date Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The Date Value to write (year, month, day, dayOfWeek).</param>
    public static void WriteDate(Span<byte> bytes, Date value)
    {
        bytes[0] = value.Year;
        bytes[1] = value.Month;
        bytes[2] = value.Day;
        bytes[3] = value.DayOfWeek;
    }

    /// <summary>
    /// Writes a BACnet Time Value.
    /// </summary>
    /// <param name="bytes">A span with at least 4 bytes capacity.</param>
    /// <param name="value">The Time Value to write (hour, minute, second, hundredths).</param>
    public static void WriteTime(Span<byte> bytes, Time value)
    {
        bytes[0] = value.Hour;
        bytes[1] = value.Minute;
        bytes[2] = value.Second;
        bytes[3] = value.Hundredths;
    }
}