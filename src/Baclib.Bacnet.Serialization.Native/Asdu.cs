// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public static class Asdu
{
    public static bool PeekApplicationTag(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber)
    {
        if (source.Length == 0)
        {
            return false;
        }
        var control = source[0];
        return (control >> 4 == (byte)tagNumber && (control & 0x08) == 0);
    }

    public static bool PeekApplicationTag(ReadOnlySpan<byte> source, out ApplicationTagNumber tagNumber)
    {
        if (source.Length == 0)
        {
            tagNumber = default;
            return false;
        }
        var control = source[0];
        tagNumber = (ApplicationTagNumber)(control >> 4);
        return (control & 0x08) == 0;
    }

    public static int PeekApplicationTag(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber, out int dataLength)
    {
        return PeekTag(source, (byte)tagNumber, false, out dataLength);
    }

    public static int PeekContextPrimitive(ReadOnlySpan<byte> source, byte tagNumber, out int dataLength)
    {
        return PeekTag(source, (byte)tagNumber, true, out dataLength);
    }

    public static bool PeekPrimitiveTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (tagNumber < 15)
        {
            if (source.Length == 0)
            {
                return false;
            }
            var control = source[0];
            return (((control >> 4) == tagNumber) && ((control & 0x07) >= 5));
        }
        if (source.Length > 1)
        {
            var control = source[0];
            return (((control & 0x07) >= 5) && source[1] == tagNumber);
        }
        return false;
    }

    public static bool PeekContextTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (tagNumber < 15)
        {
            if (source.Length == 0)
            {
                return false;
            }
            byte expected = (byte)((tagNumber << 4) | 0x08);
            return source[0] == expected;
        }
        if (source.Length > 1)
        {
            var control = source[0];
            return ((control & 0xF8) == 0xF8 && source[1] == tagNumber);
        }
        return false;
    }

    public static bool PeekContextTag(ReadOnlySpan<byte> source, out byte tagNumber)
    {
        if (source.Length == 0)
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

    public static bool PeekOpeningTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (tagNumber < 15)
        {
            if (source.Length == 0)
            {
                return false;
            }
            byte expected = (byte)((tagNumber << 4) | 0x0E);
            return source[0] == expected;
        }
        if (source.Length > 1)
        {
            var control = source[0];
            return (control == 0xFE && source[1] == tagNumber);
        }
        return false;
    }

    public static bool PeekClosingTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (tagNumber < 15)
        {
            if (source.Length == 0)
            {
                return false;
            }
            byte expected = (byte)((tagNumber << 4) | 0x0F);
            return source[0] == expected;
        }
        if (source.Length > 1)
        {
            var control = source[0];
            return (control == 0xFF && source[1] == tagNumber);
        }
        return false;
    }

    public static int ReadOpeningTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (!PeekOpeningTag(source, tagNumber))
        {
            throw new AsduException($"Expected opening tag {tagNumber} not found.");
        }
        return (tagNumber < 15 ? 1 : 2);
    }

    public static int ReadClosingTag(ReadOnlySpan<byte> source, byte tagNumber)
    {
        if (!PeekClosingTag(source, tagNumber))
        {
            throw new AsduException($"Expected closing tag {tagNumber} not found.");
        }
        return (tagNumber < 15 ? 1 : 2);
    }

    public static int PeekTag(ReadOnlySpan<byte> source, byte tagNumber, bool isContextTag, out int dataLength)
    {
        if (source.Length == 0)
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

        if (number != tagNumber || ((control & 0x08) != 0) != isContextTag)
        {
            dataLength = 0;
            return 0;
        }

        int lengthValue = control & 7;
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

    public static int ReadTag(ReadOnlySpan<byte> source, bool isContextTag, byte tagNumber, out int dataLength)
    {
        int tagLength = PeekTag(source, tagNumber, isContextTag, out dataLength);
        if (tagLength == 0)
        {
            throw new AsduException($"Tag number {tagNumber} does not exist.");
        }
        return tagLength;
    }

    public static int ReadTag(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber, out int dataLength)
    {
        return ReadTag(source, false, (byte)tagNumber, out dataLength);
    }

    public static int ReadTag(ReadOnlySpan<byte> source, byte tagNumber, out int dataLength)
    {
        return ReadTag(source, true, tagNumber, out dataLength);
    }

    public static int WriteTag(Span<byte> destination, byte tagNumber, AsduTagClass tagClass, int dataLength)
    {
        return AsduWriter.WriteTag(destination, tagClass, tagNumber, dataLength);
    }

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
}
