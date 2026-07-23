// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native;

/// <summary>
/// Runtime-erased codec contract used by <c>Any</c> dispatch.
/// </summary>
public interface IAnyRuntimeCodec
{
    /// <summary>
    /// Gets the CLR value type supported by this codec.
    /// </summary>
    Type ValueType { get; }

    /// <summary>
    /// Determines whether the next element in the reader matches this codec.
    /// </summary>
    bool Matches(ref AsduReader reader);

    /// <summary>
    /// Decodes one element from the reader.
    /// </summary>
    object Decode(ref AsduReader reader);

    /// <summary>
    /// Encodes one element to the writer.
    /// </summary>
    void Encode(ref AsduWriter writer, object value);

    /// <summary>
    /// Gets the encoded length for one value.
    /// </summary>
    int GetEncodedLength(object value);
}
