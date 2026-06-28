// SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

public interface IAsduConstructedDynamicCodec<T>
{
    bool CanDecode(ref NativeReader reader);

    T DecodeContents(ref NativeReader reader);

    void EncodeContents(ref NativeWriter writer, in T value);

    int GetEncodedLength(in T value);
}
