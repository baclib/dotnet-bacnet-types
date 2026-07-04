// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides methods for decoding and reading BACnet ASDU (Application Service Data Unit) encoded data from a byte buffer.
/// </summary>
/// <remarks>
/// This class implements deserialization according to ANSI/ASHRAE 135-2024 Clause 20.2 (ASN.1 Encoding Rules).
/// It supports all BACnet primitive types, constructed types, and context-specific encoding.
/// The decoder maintains an internal position index that advances as data is read.
/// </remarks>
/// <param name="asdu">The input ASDU bytes to decode.</param>
public ref struct AsduReader(ReadOnlySpan<byte> asdu)
{
    /// <summary>
    /// The full input ASDU span being decoded.
    /// </summary>
    private readonly ReadOnlySpan<byte> _asdu = asdu;

    /// <summary>
    /// Current read offset into <see cref="_asdu"/>.
    /// </summary>
    private int _index;

    /// <summary>
    /// Gets the current read position in bytes from the start of the ASDU.
    /// </summary>
    public readonly int Position => _index;

    /// <summary>
    /// Gets the number of unread bytes remaining in the ASDU.
    /// </summary>
    public readonly int RemainingLength => _asdu.Length - _index;

    /// <summary>
    /// Gets a value indicating whether the decoder has consumed the full input.
    /// </summary>
    public readonly bool End => _index >= _asdu.Length;


    // ----------------------------------------------------------------


    public readonly bool PeekApplicationTag(ApplicationTagNumber tagNumber)
        => Asdu.PeekApplicationTag(_asdu[_index..], tagNumber);

    public readonly bool PeekApplicationTag(out ApplicationTagNumber tagNumber)
        => Asdu.PeekApplicationTag(_asdu[_index..], out tagNumber);

    public readonly bool PeekContextTag(byte tagNumber)
        => Asdu.PeekContextTag(_asdu[_index..], tagNumber);

    public readonly bool PeekContextTag(out byte tagNumber)
        => Asdu.PeekContextTag(_asdu[_index..], out tagNumber);

    public readonly bool PeekOpeningTag(byte tagNumber)
        => Asdu.PeekOpeningTag(_asdu[_index..], tagNumber);

    public readonly bool PeekClosingTag(byte tagNumber)
        => Asdu.PeekClosingTag(_asdu[_index..], tagNumber);

    // ----------------------------------------------------------------

    public readonly bool PeekPrimitiveTag(byte tagNumber)
        => Asdu.PeekPrimitiveTag(_asdu[_index..], tagNumber);

    // ----------------------------------------------------------------









    public byte ReadContextTagNumber()
    { 
        throw new NotImplementedException();
    }

    public void ReadOpeningTag(byte tagNumber)
        => _index += Asdu.ReadOpeningTag(_asdu[_index..], tagNumber);

    public void ReadClosingTag(byte tagNumber)
        => _index += Asdu.ReadClosingTag(_asdu[_index..], tagNumber);


    // ----------------------------------------------------------------


    public byte ReadByte()
    {
        return _asdu[_index++];
    }

    public ReadOnlySpan<byte> ReadApplicationPrimitive(ApplicationTagNumber tagNumber)
    {
        var length = Asdu.PeekApplicationTag(_asdu[_index..], tagNumber, out var dataLength);
        if (length == 0)
        {
            throw new AsduException();
        }
        _index += length;
        var data = _asdu.Slice(_index, dataLength);
        _index += dataLength;
        return data;
    }

    public ReadOnlySpan<byte> ReadContextPrimitive(byte tagNumber)
    {
        var length = Asdu.PeekContextPrimitive(_asdu[_index..], tagNumber, out var dataLength);
        if (length == 0)
        {
            throw new AsduException();
        }
        _index += length;
        var data = _asdu.Slice(_index, dataLength);
        _index += dataLength;
        return data;
    }
}
