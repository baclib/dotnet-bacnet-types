// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

using System.Runtime.CompilerServices;

namespace Baclib.Bacnet.Serialization.Native;

public readonly record struct AsduTag
{
    private readonly byte _initialOctet;

    private readonly byte _tagNumber;

    private readonly int _dataLength;

    public AsduTag(bool value)
    {
        _tagNumber = 1;
        _initialOctet = (byte)(value ? 0x11 : 0x10);
        _dataLength = 0;
    }

    public AsduTag(byte tagNumber, AsduTagType tagType)
    {
        _tagNumber = tagNumber;
        _initialOctet = tagNumber < 15 ? tagNumber : (byte)0xF0;
        _initialOctet |= 8;
        _initialOctet |= (byte)(tagType == AsduTagType.Opening ? 6 : 7);
        _dataLength = 0;
    }

    public AsduTag(byte tagNumber, AsduTagClass tagClass, int dataLength)
    {
        _tagNumber = tagNumber;
        _initialOctet = tagNumber < 15 ? tagNumber : (byte)0xF0;
        if (tagClass != AsduTagClass.Application)
        {
            _initialOctet |= 8;
        }
        _initialOctet |= (byte)(dataLength < 5 ? dataLength : 5);
        _dataLength = dataLength;
    }


    public ReadOnlySpan<byte> GetContents(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }


    public bool IsPrimitive => (_initialOctet & 7) < 6;

    public bool IsConstructed => (_initialOctet & 7) < 5;


    public byte InitialOctet => _initialOctet;

    public bool HasExtendedTagNumber => _tagNumber >= 15;

    public byte TagNumber => _tagNumber;

    public bool IsApplicationBoolean => (_initialOctet & 0xEF) == 0;

    public bool IsApplicationFalse => _initialOctet == 0x10;

    public bool IsApplicationTrue => _initialOctet == 0x11;

    public AsduTagClass Class => (_initialOctet & 8) != 0 ? AsduTagClass.Context : AsduTagClass.Application;

    public byte LengthValueType => (byte)(_initialOctet & 7);

    public bool HasDataLength => LengthValueType < 5 && !IsApplicationBoolean;

    public bool HasExtendedDataLength => _dataLength > 5;

    public int DataLength => HasDataLength ? _dataLength : throw new InvalidOperationException("Tag does not have a data length.");

    public bool HasType => LengthValueType > 5;

    public AsduTagType Type => LengthValueType switch
    {
        6 => AsduTagType.Opening,
        7 => AsduTagType.Closing,
        _ => throw new InvalidOperationException("Tag is not of Opening or Closing type.")
    };

    public bool IsOpeningTag => (_initialOctet & 0xF1) == 0;

    public bool IsClosingTag => (_initialOctet & 0xF0) == 0;

    public bool HasValue => IsApplicationFalse || IsApplicationTrue;

    public bool Value => _initialOctet switch
    {
        0x10 => false,
        0x11 => true,
        _ => throw new InvalidOperationException("Tag does not contain a valid value.")
    };











    public static int PeekTagWithFixedDataLength(ReadOnlySpan<byte> source, byte tagNumber, AsduTagClass tagClass, int fixedSize)
    {
        int length = PeekTag(source, tagNumber, tagClass, out int dataLength);
        return length != 0 && dataLength == fixedSize ? length : 0;
    }

    public static int PeekTagWithFixedDataLength(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber, int fixedSize)
    {
        return PeekTagWithFixedDataLength(source, (byte)tagNumber, AsduTagClass.Application, fixedSize);
    }

    public static int PeekTagWithFixedDataLength(ReadOnlySpan<byte> source, byte tagNumber, int fixedSize)
    {
        return PeekTagWithFixedDataLength(source, tagNumber, AsduTagClass.Context, fixedSize);
    }

    public static int PeekTagWithPositiveLength(ReadOnlySpan<byte> source, byte tagNumber, AsduTagClass tagClass, int maximumLength)
    {
        int length = PeekTag(source, tagNumber, tagClass, out int dataLength);
        return length != 0 && dataLength > 0 && dataLength < maximumLength ? length : 0;
    }

    public static int PeekTagWithPositiveLength(ReadOnlySpan<byte> source, ApplicationTagNumber tagNumber, int maximumLength)
    {
        return PeekTagWithPositiveLength(source, (byte)tagNumber, AsduTagClass.Application, maximumLength);
    }

    public static int PeekTagWithPositiveLength(ReadOnlySpan<byte> source, byte tagNumber, int maximumLength)
    {
        return PeekTagWithPositiveLength(source, tagNumber, AsduTagClass.Context, maximumLength);
    }















    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int PeekTag(ReadOnlySpan<byte> source, byte tagNumber, AsduTagClass tagClass, out int dataLength)
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

        if (number != tagNumber || ((control & 0x08) != 0 ? AsduTagClass.Context : AsduTagClass.Application) != tagClass)
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
                dataLength = System.Buffers.Binary.BinaryPrimitives.ReadUInt16BigEndian(source.Slice(index + 1, 2));
                return index + 3;
            }

            if (source.Length < index + 5)
            {
                dataLength = 0;
                return 0;
            }
            dataLength = System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(source.Slice(index + 1, 4));
            return index + 5;
        }

        dataLength = 0;
        return 0;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int PeekTag(ReadOnlySpan<byte> source, byte tagNumber, AsduTagType tagType)
    {
        if (tagNumber < 15)
        {
            if (source.Length == 0)
            {
                return 0;
            }
            
            byte expected = (byte)((tagNumber << 4) | (tagType == AsduTagType.Opening ? 6 : 7));
            return source[0] == expected ? 1 : 0;
        }

        if (source.Length < 2)
        {
            return 0;
        }

        byte expectedFirst = (byte)(tagType == AsduTagType.Opening ? 0xFE : 0xFF);
        return (source[0] == expectedFirst & source[1] == tagNumber) ? 2 : 0;
    }










    public static int ReadTag(ReadOnlySpan<byte> source, out byte tagNumber, out AsduTagClassType tagClassType, out int dataLength)
    {
        int index = 0;
        byte initialOctet = source[index++];

        tagNumber = (byte)(initialOctet >> 4);
        if (tagNumber == 15)
        {
            tagNumber = source[index++];
        }

        tagClassType = (initialOctet & 0x08) != 0 ? AsduTagClassType.Context : AsduTagClassType.Application;

        dataLength = initialOctet & 0x07;
        if (dataLength < 5)
        {
            return index;
        }

        if (dataLength == 5)
        {
            dataLength = source[index++];
            if (dataLength < 254)
            {
                return index;
            }

            if (dataLength == 254)
            {
                dataLength = System.Buffers.Binary.BinaryPrimitives.ReadUInt16BigEndian(source.Slice(index, 2));
                return index + 2;
            }

            dataLength = System.Buffers.Binary.BinaryPrimitives.ReadInt32BigEndian(source.Slice(index, 4));
            return index + 4;
        }

        tagClassType = dataLength == 6 ? AsduTagClassType.Opening : AsduTagClassType.Closing;
        dataLength = 0;
        return index;
    }

    public static int Read(ReadOnlySpan<byte> source, out AsduTag tag)
    {
        var result = ReadTag(source, out byte tagNumber, out AsduTagClassType tagClassType, out int dataLength);
        tag = tagClassType switch
        {
            AsduTagClassType.Application or AsduTagClassType.Context => new AsduTag(tagNumber, (AsduTagClass)tagClassType, dataLength),
            AsduTagClassType.Opening or AsduTagClassType.Closing => new AsduTag(tagNumber, (AsduTagType)tagClassType),
            _ => throw new InvalidOperationException("Invalid tag class type."),
        };
        return result;
    }

    public static int WriteTag(Span<byte> destination, byte tagNumber, AsduTagClass tagClass, int dataLength)
    {
        int index = 0;
        ref byte initialOctet = ref destination[index++];

        if (tagNumber < 15)
        {
            initialOctet = (byte)(tagNumber << 4);
        }
        else
        {
            initialOctet = 0xF0;
            destination[index++] = tagNumber;
        }

        if (tagClass != AsduTagClass.Application)
        {
            initialOctet |= 0x08;
        }

        if (dataLength < 5)
        {
            initialOctet |= unchecked((byte)dataLength);
        }
        else
        {
            initialOctet |= 0x05;
            if (dataLength < 0xFE)
            {
                destination[index++] = (byte)dataLength;
            }
            else if (dataLength < 0x10000)
            {
                destination[index++] = 254;
                System.Buffers.Binary.BinaryPrimitives.WriteUInt16BigEndian(destination[index..], unchecked((ushort)dataLength));
            }
            else
            {
                destination[index++] = 255;
                System.Buffers.Binary.BinaryPrimitives.WriteUInt32BigEndian(destination[index..], unchecked((uint)dataLength));
            }
        }

        return index;
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

