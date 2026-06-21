// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public sealed class NativeCodec<T> where T : ICodec<T>
{
    public T Decode(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }

    public T Decode(ref NativeReader reader, byte tagNumber)
    {
        throw new NotImplementedException();
    }

    public Optional<T> DecodeOptional(ref NativeReader reader)
    {
        throw new NotImplementedException();
    }

    public Optional<T> DecodeOptional(ref NativeReader reader, byte tagNumber)
    {
        throw new NotImplementedException();
    }

    public void Encode(ref NativeWriter writer, in T value)
    {
        throw new NotImplementedException();
    }

    public void Encode(ref NativeWriter writer, byte tagNumber, in T value)
    {
        throw new NotImplementedException();
    }

    public int GetSize(in T value)
    {
        throw new NotImplementedException();
    }

    public int GetSize(byte tagNumber, in T value)
    {
        throw new NotImplementedException();
    }
}
