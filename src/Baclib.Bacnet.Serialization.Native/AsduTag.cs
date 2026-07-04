// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

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

    public ReadOnlySpan<byte> GetContents(ref AsduReader reader)
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
}
