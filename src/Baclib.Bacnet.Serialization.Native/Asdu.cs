// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public static class Asdu
{
    /// <summary>
    /// Checks whether the first encoded element is an application tag with the expected
    /// <paramref name="tagNumber"/>.
    /// </summary>
    public static bool PeekApplicationTag(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber)
    {
        if (source.IsEmpty)
        {
            return false;
        }

        var control = source[0];
        return (control & 0xF8) == ((byte)tagNumber << 4);
    }

    /// <summary>
    /// Checks whether the first encoded element is an application-tagged value and returns its
    /// tag number.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">When this method returns <see langword="true"/>, contains the
    /// application tag number; otherwise contains the default value.</param>
    /// <returns><see langword="true"/> when an application tag is present; otherwise
    /// <see langword="false"/>.</returns>
    public static bool PeekApplicationTag(ReadOnlySpan<byte> source, out ApplicationTagNumber tagNumber)
    {
        if (source.IsEmpty)
        {
            tagNumber = default;
            return false;
        }

        var control = source[0];
        if ((control & 0x08) != 0)
        {
            tagNumber = default;
            return false;
        }

        tagNumber = (ApplicationTagNumber)(control >> 4);
        return true;
    }

    /// <summary>
    /// Checks whether the first encoded element is the expected application tag and, when it is,
    /// reads the encoded data-length value from the tag header.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="dataLength">When this method returns a non-zero value, contains the number
    /// of payload bytes for the element.</param>
    /// <returns>The number of bytes occupied by the tag header, or <c>0</c> when the expected tag
    /// is not present or is truncated.</returns>
    public static int PeekApplicationTag(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber, out int dataLength)
    {
        if (source.IsEmpty)
        {
            dataLength = 0;
            return 0;
        }

        var control = source[0];
        if ((control & 0xF8) != ((byte)tagNumber << 4))
        {
            dataLength = 0;
            return 0;
        }

        return ReadTagLength(source, 1, out dataLength);
    }

    /// <summary>
    /// Checks whether the first encoded element is application-tagged and, when it is, returns
    /// both the tag number and payload length.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">When this method returns a non-zero value, contains the
    /// application tag number.</param>
    /// <param name="dataLength">When this method returns a non-zero value, contains the number
    /// of payload bytes for the element.</param>
    /// <returns>The number of bytes occupied by the tag header, or <c>0</c> when the element is
    /// not an application tag or is truncated.</returns>
    public static int PeekApplicationTag(ReadOnlySpan<byte> source, out ApplicationTagNumber tagNumber, out int dataLength)
    {
        if (source.IsEmpty)
        {
            tagNumber = default;
            dataLength = 0;
            return 0;
        }

        var control = source[0];
        if ((control & 0x08) != 0)
        {
            tagNumber = default;
            dataLength = 0;
            return 0;
        }

        tagNumber = (ApplicationTagNumber)(control >> 4);
        return ReadTagLength(source, 1, out dataLength);
    }

    /// <summary>
    /// Checks whether the first encoded element is a context tag with the expected
    /// <paramref name="tagNumber"/>.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when the expected context tag is present; otherwise
    /// <see langword="false"/>.</returns>
    public static bool PeekContextTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (tagNumber < 15)
        {
            if (source.IsEmpty)
            {
                return false;
            }

            var control = source[0];
            byte expected = (byte)((tagNumber << 4) | 0x08);
            return (control & 0xF8) == expected;
        }

        if (source.Length > 1)
        {
            var control = source[0];
            return (control & 0xF8) == 0xF8 && source[1] == tagNumber;
        }

        return false;
    }

    /// <summary>
    /// Checks whether the first encoded element is context-tagged and returns its tag number.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">When this method returns <see langword="true"/>, contains the
    /// context tag number; otherwise <c>0</c>.</param>
    /// <returns><see langword="true"/> when a context tag is present; otherwise
    /// <see langword="false"/>.</returns>
    public static bool PeekContextTag(ReadOnlySpan<byte> source, out byte tagNumber)
    {
        if (source.IsEmpty)
        {
            tagNumber = 0;
            return false;
        }

        var control = source[0];
        if ((control & 0x08) == 0)
        {
            tagNumber = 0;
            return false;
        }

        tagNumber = (byte)(control >> 4);
        if (tagNumber == 15)
        {
            if (source.Length < 2)
            {
                tagNumber = 0;
                return false;
            }
            tagNumber = source[1];
        }
        return true;
    }

    /// <summary>
    /// Checks whether the first encoded element is a primitive context tag with the expected
    /// <paramref name="tagNumber"/>.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when a matching primitive context element is present;
    /// otherwise <see langword="false"/>.</returns>
    public static bool PeekContextPrimitive(ReadOnlySpan<byte> source, byte tagNumber)
    {
        return PeekContextTag(source, tagNumber) && (source[0] & 0x07) < 6;
    }

    /// <summary>
    /// Checks whether the first encoded element is a primitive context-tagged value and returns
    /// its tag number.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">When this method returns <see langword="true"/>, contains the
    /// context tag number; otherwise <c>0</c>.</param>
    /// <returns><see langword="true"/> when a primitive context element is present; otherwise
    /// <see langword="false"/>.</returns>
    public static bool PeekContextPrimitive(ReadOnlySpan<byte> source, out byte tagNumber)
    {
        return PeekContextTag(source, out tagNumber) && (source[0] & 0x07) < 6;
    }

    /// <summary>
    /// Checks whether the first encoded element is a matching primitive context tag and, when it
    /// is, reads the payload length.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="dataLength">When this method returns a non-zero value, contains the number
    /// of payload bytes for the element.</param>
    /// <returns>The number of bytes occupied by the tag header, or <c>0</c> when a matching
    /// primitive context element is not present or is truncated.</returns>
    public static int PeekContextPrimitive(ReadOnlySpan<byte> source, byte tagNumber, out int dataLength)
    {
        if (source.IsEmpty)
        {
            dataLength = 0;
            return 0;
        }

        var control = source[0];
        var number = (byte)(control >> 4);
        var index = 1;

        if (number == 15)
        {
            if (source.Length < 2)
            {
                dataLength = 0;
                return 0;
            }
            number = source[1];
            index = 2;
        }

        if (number != tagNumber || (control & 0x08) == 0 || (control & 0x07) >= 6)
        {
            dataLength = 0;
            return 0;
        }

        return ReadTagLength(source, index, out dataLength);
    }

    /// <summary>
    /// Checks whether the first encoded element is a primitive context-tagged value and, when it
    /// is, returns both the tag number and payload length.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">When this method returns a non-zero value, contains the context
    /// tag number.</param>
    /// <param name="dataLength">When this method returns a non-zero value, contains the number
    /// of payload bytes for the element.</param>
    /// <returns>The number of bytes occupied by the tag header, or <c>0</c> when the element is
    /// not a primitive context tag or is truncated.</returns>
    public static int PeekContextPrimitive(ReadOnlySpan<byte> source, out byte tagNumber, out int dataLength)
    {
        if (source.IsEmpty)
        {
            tagNumber = 0;
            dataLength = 0;
            return 0;
        }

        var control = source[0];
        var number = (byte)(control >> 4);
        var index = 1;

        if (number == 15)
        {
            if (source.Length < 2)
            {
                tagNumber = 0;
                dataLength = 0;
                return 0;
            }
            number = source[1];
            index = 2;
        }

        if ((control & 0x08) == 0 || (control & 0x07) >= 6)
        {
            tagNumber = 0;
            dataLength = 0;
            return 0;
        }
        tagNumber = number;

        return ReadTagLength(source, index, out dataLength);
    }

    /// <summary>
    /// Checks whether the first encoded element is the expected opening context tag.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when the expected opening tag is present; otherwise
    /// <see langword="false"/>.</returns>
    public static bool PeekOpeningTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (tagNumber < 15)
        {
            if (source.IsEmpty)
            {
                return false;
            }
            byte expected = (byte)((tagNumber << 4) | 0x0E);
            return source[0] == expected;
        }
        if (source.Length > 1)
        {
            var control = source[0];
            return control == 0xFE && source[1] == tagNumber;
        }
        return false;
    }

    /// <summary>
    /// Checks whether the first encoded element is the expected closing context tag.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns><see langword="true"/> when the expected closing tag is present; otherwise
    /// <see langword="false"/>.</returns>
    public static bool PeekClosingTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (tagNumber < 15)
        {
            if (source.IsEmpty)
            {
                return false;
            }
            byte expected = (byte)((tagNumber << 4) | 0x0F);
            return source[0] == expected;
        }
        if (source.Length > 1)
        {
            var control = source[0];
            return control == 0xFF && source[1] == tagNumber;
        }
        return false;
    }

    /// <summary>
    /// Reads and validates the expected opening context tag at the start of
    /// <paramref name="source"/>.
    /// </summary>
    /// <param name="source">The bytes positioned at the opening tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The number of bytes consumed by the opening tag (1 or 2).</returns>
    /// <exception cref="AsduException">Thrown when the expected opening tag is absent.</exception>
    public static int ReadOpeningTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (!PeekOpeningTag(source, tagNumber))
        {
            throw new AsduException($"Expected opening tag {tagNumber} not found.");
        }
        return tagNumber < 15 ? 1 : 2;
    }

    /// <summary>
    /// Reads and validates the expected closing context tag at the start of
    /// <paramref name="source"/>.
    /// </summary>
    /// <param name="source">The bytes positioned at the closing tag.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <returns>The number of bytes consumed by the closing tag (1 or 2).</returns>
    /// <exception cref="AsduException">Thrown when the expected closing tag is absent.</exception>
    public static int ReadClosingTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (!PeekClosingTag(source, tagNumber))
        {
            throw new AsduException($"Expected closing tag {tagNumber} not found.");
        }
        return tagNumber < 15 ? 1 : 2;
    }

    private static int ReadTagLength(ReadOnlySpan<byte> source, int index, out int dataLength)
    {
        int lengthValue = source[0] & 0x07;
        if (lengthValue < 5)
        {
            dataLength = lengthValue;
            return index;
        }

        if (lengthValue == 5)
        {
            if (source.Length <= index)
            {
                dataLength = 0;
                return 0;
            }

            dataLength = source[index];
            if (dataLength < 254)
            {
                return index + 1;
            }

            if (dataLength == 254)
            {
                if (source.Length < index + 3)
                {
                    dataLength = 0;
                    return 0;
                }
                dataLength = AsduBinaryPrimitives.ReadUnsigned16(source.Slice(index + 1, 2));
                return index + 3;
            }

            if (source.Length < index + 5)
            {
                dataLength = 0;
                return 0;
            }
            dataLength = AsduBinaryPrimitives.ReadInteger32(source.Slice(index + 1, 4));
            return index + 5;
        }

        dataLength = 0;
        return 0;
    }

    /// <summary>
    /// Reads an application tag with the expected <paramref name="tagNumber"/> and returns its
    /// header length.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected application tag number.</param>
    /// <param name="dataLength">When this method returns, contains the number of payload bytes
    /// for the element.</param>
    /// <returns>The number of bytes occupied by the tag header.</returns>
    /// <exception cref="AsduException">Thrown when the expected application tag is absent,
    /// malformed, or truncated.</exception>
    public static int ReadTag(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber, out int dataLength)
    {
        int tagLength = PeekApplicationTag(source, tagNumber, out dataLength);
        if (tagLength == 0)
        {
            throw new AsduException($"The application tag number {tagNumber} does not exist.");
        }
        return tagLength;
    }

    /// <summary>
    /// Reads a primitive context tag with the expected <paramref name="tagNumber"/> and returns
    /// its header length.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of an encoded element.</param>
    /// <param name="tagNumber">The expected context tag number.</param>
    /// <param name="dataLength">When this method returns, contains the number of payload bytes
    /// for the element.</param>
    /// <returns>The number of bytes occupied by the tag header.</returns>
    /// <exception cref="AsduException">Thrown when the expected primitive context tag is absent,
    /// malformed, or truncated.</exception>
    public static int ReadTag(ReadOnlySpan<byte> source, byte tagNumber, out int dataLength)
    {
        int tagLength = PeekContextPrimitive(source, tagNumber, out dataLength);
        if (tagLength == 0)
        {
            throw new AsduException($"The context tag number {tagNumber} does not exist.");
        }
        return tagLength;
    }

    /// <summary>
    /// Writes an application or context data tag into <paramref name="destination"/>.
    /// </summary>
    /// <param name="destination">The destination span where tag bytes are written.</param>
    /// <param name="tagNumber">The tag number to encode.</param>
    /// <param name="tagClass">The tag class (application or context).</param>
    /// <param name="dataLength">The encoded payload length to place in the tag header.</param>
    /// <returns>The number of bytes written for the tag header.</returns>
    public static int WriteTag(Span<byte> destination, byte tagNumber, AsduTagClass tagClass, int dataLength)
    {
        return AsduWriter.WriteTag(destination, tagClass, tagNumber, dataLength);
    }

    /// <summary>
    /// Writes an opening or closing context tag to <paramref name="destination"/> and returns
    /// the number of bytes written.
    /// </summary>
    /// <param name="destination">The destination span where tag bytes are written.</param>
    /// <param name="tagNumber">The context tag number to encode.</param>
    /// <param name="type">The enclosing tag type to encode.</param>
    /// <returns>The number of bytes written for the tag (1 or 2).</returns>
    public static int WriteTag(Span<byte> destination, byte tagNumber, AsduTagType type)
    {
        if (tagNumber < 15)
        {
            destination[0] = (byte)((tagNumber << 4) | (type == AsduTagType.Opening ? 6 : 7));
            return 1;
        }

        destination[0] = (byte)(type == AsduTagType.Opening ? 0xFE : 0xFF);
        destination[1] = tagNumber;
        return 2;
    }
    /// <summary>
    /// Validates that <paramref name="source"/> contains zero or more well-formed ASDU elements
    /// from start to end, and returns the total byte count.
    /// </summary>
    /// <param name="source">The bytes to validate.</param>
    /// <returns>The length of <paramref name="source"/> in bytes.</returns>
    /// <exception cref="AsduException">Thrown when any element is malformed or truncated.</exception>
    public static int ReadAny(ReadOnlySpan<byte> source)
    {
        var offset = 0;
        while (offset < source.Length)
        {
            if ((source[offset] & 0x07) == 7)
            {
                break;
            }

            MeasureElement(source, ref offset);
        }
        return offset;
    }

    /// <summary>
    /// Validates a constructed ASDU value delimited by a matching opening/closing tag pair with
    /// the given <paramref name="tagNumber"/>, including all enclosed elements, and returns the
    /// total byte count (opening tag + content + closing tag).
    /// </summary>
    /// <param name="source">The bytes positioned at the opening tag.</param>
    /// <param name="tagNumber">The context tag number of the opening and closing tags.</param>
    /// <returns>The total number of bytes consumed, including both delimiter tags.</returns>
    /// <exception cref="AsduException">Thrown when the opening tag is absent, any enclosed
    /// element is malformed, the closing tag is missing, or data is truncated.</exception>
    public static int ReadAny(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (!PeekOpeningTag(source, tagNumber))
        {
            throw new AsduException($"Expected opening tag {tagNumber} not found.");
        }

        var offset = tagNumber < 15 ? 1 : 2;

        while (!PeekClosingTag(source[offset..], tagNumber))
        {
            if (offset >= source.Length)
            {
                throw new AsduException($"Closing tag {tagNumber} not found.");
            }
            MeasureElement(source, ref offset);
        }

        offset += tagNumber < 15 ? 1 : 2;
        return offset;
    }

    /// <summary>
    /// Measures the total encoded length, in bytes, of exactly one complete ASDU element at the
    /// start of <paramref name="source"/>. The element may be a primitive value (application- or
    /// context-tagged) or a constructed value delimited by matching opening/closing tags.
    /// </summary>
    /// <param name="source">The bytes positioned at the start of the element.</param>
    /// <returns>The number of bytes occupied by the element.</returns>
    /// <exception cref="AsduException">Thrown when the element is malformed or truncated.</exception>
    public static int MeasureElement(ReadOnlySpan<byte> source)
    {
        var offset = 0;
        MeasureElement(source, ref offset);
        return offset;
    }

    private static void MeasureElement(ReadOnlySpan<byte> source, ref int offset)
    {
        if (offset >= source.Length)
        {
            throw new AsduException("Unexpected end of ASDU while measuring element.");
        }

        var lvt = source[offset] & 0x07;

        if (lvt == 6)
        {
            // Opening tag: constructed value delimited by a matching closing tag.
            var control = source[offset];
            var tagNumber = control >> 4;
            if (tagNumber == 15)
            {
                if (offset + 1 >= source.Length)
                {
                    throw new AsduException("Truncated extended tag number.");
                }
                tagNumber = source[offset + 1];
                offset += 2;
            }
            else
            {
                offset += 1;
            }

            while (true)
            {
                if (offset >= source.Length)
                {
                    throw new AsduException("Unterminated constructed value: closing tag not found.");
                }

                if ((source[offset] & 0x07) == 7)
                {
                    control = source[offset];
                    var closingNumber = control >> 4;
                    if (closingNumber == 15)
                    {
                        if (offset + 1 >= source.Length)
                        {
                            throw new AsduException("Truncated extended tag number.");
                        }
                        closingNumber = source[offset + 1];
                        offset += 2;
                    }
                    else
                    {
                        offset += 1;
                    }

                    if (closingNumber != tagNumber)
                    {
                        throw new AsduException("Mismatched closing tag in constructed value.");
                    }
                    return;
                }

                MeasureElement(source, ref offset);
            }
        }

        if (lvt == 7)
        {
            throw new AsduException("Unexpected closing tag at element start.");
        }

        // Primitive/data tag: header followed by the data bytes.
        var primitiveControl = source[offset];
        var number = primitiveControl >> 4;
        var isApplicationBoolean = (primitiveControl & 0x08) == 0 && number == (byte)ApplicationTagNumber.Boolean;
        offset += 1;

        if (number == 15)
        {
            if (offset >= source.Length)
            {
                throw new AsduException("Truncated extended tag number.");
            }
            offset += 1;
        }

        var primitiveLvt = primitiveControl & 0x07;
        int dataLength;

        if (isApplicationBoolean)
        {
            // BACnet application BOOLEAN encodes the value in LVT and carries no payload bytes.
            dataLength = 0;
        }
        else if (primitiveLvt < 5)
        {
            dataLength = primitiveLvt;
        }
        else
        {
            if (offset >= source.Length)
            {
                throw new AsduException("Truncated extended length.");
            }

            var first = source[offset++];
            if (first < 254)
            {
                dataLength = first;
            }
            else if (first == 254)
            {
                if (offset + 2 > source.Length)
                {
                    throw new AsduException("Truncated extended length.");
                }
                dataLength = AsduBinaryPrimitives.ReadUnsigned16(source.Slice(offset, 2));
                offset += 2;
            }
            else
            {
                if (offset + 4 > source.Length)
                {
                    throw new AsduException("Truncated extended length.");
                }
                dataLength = AsduBinaryPrimitives.ReadInteger32(source.Slice(offset, 4));
                offset += 4;
            }
        }

        if (offset + dataLength > source.Length)
        {
            throw new AsduException("Truncated element data.");
        }
        offset += dataLength;
    }
}
