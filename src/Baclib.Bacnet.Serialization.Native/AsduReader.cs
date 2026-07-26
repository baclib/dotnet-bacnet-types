// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Provides methods for decoding and reading BACnet ASDU (Application Service Data Unit)
/// encoded data from a byte buffer.
/// </summary>
/// <remarks>
/// This class implements deserialization according to ANSI/ASHRAE 135-2024 Clause 20.2
/// (ASN.1 Encoding Rules). It supports primitive and constructed elements and context-tagged
/// navigation. The decoder maintains an internal position index that advances as data is read.
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

    #region State

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

    #endregion

    #region Peek Helpers

    /// <summary>
    /// Checks whether the next element is the specified application tag.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <returns><see langword="true"/> when a matching application tag is present.</returns>
    public readonly bool PeekApplicationTag(ApplicationTagNumber tagNumber)
        => Asdu.PeekApplicationTag(_asdu[_index..], tagNumber);

    /// <summary>
    /// Checks whether the next element is application-tagged and returns its tag number.
    /// </summary>
    /// <param name="tagNumber">When this method returns <see langword="true"/>, contains the
    /// detected application tag number.</param>
    /// <returns><see langword="true"/> when an application tag is present.</returns>
    public readonly bool PeekApplicationTag(out ApplicationTagNumber tagNumber)
        => Asdu.PeekApplicationTag(_asdu[_index..], out tagNumber);

    /// <summary>
    /// Checks whether the next element is the specified context tag.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when a matching context tag is present.</returns>
    public readonly bool PeekContextTag(byte tagNumber)
        => Asdu.PeekContextTag(_asdu[_index..], tagNumber);

    /// <summary>
    /// Checks whether the next element is context-tagged and returns its tag number.
    /// </summary>
    /// <param name="tagNumber">When this method returns <see langword="true"/>, contains the
    /// detected context tag number.</param>
    /// <returns><see langword="true"/> when a context tag is present.</returns>
    public readonly bool PeekContextTag(out byte tagNumber)
        => Asdu.PeekContextTag(_asdu[_index..], out tagNumber);

    /// <summary>
    /// Checks whether the next element is the specified opening context tag.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when a matching opening tag is present.</returns>
    public readonly bool PeekOpeningTag(byte tagNumber)
        => Asdu.PeekOpeningTag(_asdu[_index..], tagNumber);

    /// <summary>
    /// Checks whether the next element is the specified closing context tag.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when a matching closing tag is present.</returns>
    public readonly bool PeekClosingTag(byte tagNumber)
        => Asdu.PeekClosingTag(_asdu[_index..], tagNumber);

    #endregion

    #region Tag Reads

    /// <summary>
    /// Reads the context tag number at the current position without advancing the reader.
    /// </summary>
    /// <returns>The context tag number at the current reader position.</returns>
    /// <exception cref="AsduException">Thrown when the current element is not context-tagged.</exception>
    public byte ReadContextTagNumber()
    {
        if (!Asdu.PeekContextTag(_asdu[_index..], out var tagNumber))
        {
            throw new AsduException("Expected context tag at current reader position.");
        }

        return tagNumber;
    }

    /// <summary>
    /// Reads and validates the expected opening context tag and advances the reader position.
    /// </summary>
    /// <param name="tagNumber">The expected opening context tag number.</param>
    /// <exception cref="AsduException">Thrown when the expected opening tag is not present.</exception>
    public void ReadOpeningTag(byte tagNumber)
        => _index += Asdu.ReadOpeningTag(_asdu[_index..], tagNumber);

    /// <summary>
    /// Reads and validates the expected closing context tag and advances the reader position.
    /// </summary>
    /// <param name="tagNumber">The expected closing context tag number.</param>
    /// <exception cref="AsduException">Thrown when the expected closing tag is not present.</exception>
    public void ReadClosingTag(byte tagNumber)
        => _index += Asdu.ReadClosingTag(_asdu[_index..], tagNumber);

    #endregion

    #region Primitive And Raw Reads

    /// <summary>
    /// Reads one raw byte and advances the reader position by one.
    /// </summary>
    /// <returns>The byte at the current reader position.</returns>
    public byte ReadByte()
    {
        return _asdu[_index++];
    }

    /// <summary>
    /// Reads an application-tagged primitive payload for the expected tag number.
    /// </summary>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <returns>A span over the primitive payload bytes.</returns>
    /// <exception cref="AsduException">Thrown when the expected tag is not present or malformed.</exception>
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

    /// <summary>
    /// Reads a context-tagged primitive payload for the expected tag number.
    /// </summary>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>A span over the primitive payload bytes.</returns>
    /// <exception cref="AsduException">Thrown when the expected primitive context tag is not
    /// present or malformed.</exception>
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

    /// <summary>
    /// Reads one or more complete ASDU elements from the current position.
    /// Reading stops before a closing tag at the current nesting level.
    /// </summary>
    /// <returns>A span over the consumed encoded bytes.</returns>
    /// <exception cref="AsduException">Thrown when any consumed element is malformed or truncated.</exception>
    public ReadOnlySpan<byte> ReadAny()
    {
        var length = Asdu.ReadAny(_asdu[_index..]);
        var data = _asdu.Slice(_index, length);
        _index += length;
        return data;
    }

    /// <summary>
    /// Reads a constructed ASDU value delimited by the specified opening and closing tags.
    /// </summary>
    /// <param name="tagNumber">The opening/closing context tag number.</param>
    /// <returns>A span over the consumed bytes, including both enclosing tags.</returns>
    /// <exception cref="AsduException">Thrown when the enclosing tags are missing or content is malformed.</exception>
    public ReadOnlySpan<byte> ReadAny(byte tagNumber)
    {
        var length = Asdu.ReadAny(_asdu[_index..], tagNumber);
        var data = _asdu.Slice(_index, length);
        _index += length;
        return data;
    }

    #endregion

    #region Range Reads

    /// <summary>
    /// Reads bytes until the next closing tag at the current nesting level.
    /// </summary>
    /// <returns>A span over the bytes before the closing tag.</returns>
    /// <exception cref="NotImplementedException">Always thrown because this overload is not yet implemented.</exception>
    public ReadOnlySpan<byte> ReadUntilClosing()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Reads bytes until the specified closing tag is encountered.
    /// The closing tag is not consumed.
    /// </summary>
    /// <param name="tagNumber">The expected closing context tag number.</param>
    /// <returns>A span over the bytes between the current position and the closing tag.</returns>
    /// <exception cref="AsduException">Thrown when the closing tag is not found before input ends.</exception>
    public ReadOnlySpan<byte> ReadUntilClosing(byte tagNumber)
    {
        var start = _index;
        while (!PeekClosingTag(tagNumber))
        {
            if (End)
            {
                throw new AsduException($"Closing tag {tagNumber} not found.");
            }
            _index += Asdu.MeasureElement(_asdu[_index..]);
        }
        return _asdu[start.._index];
    }

    #endregion
}
