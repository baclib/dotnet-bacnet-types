// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class AtomicReadFileRequest
{
    public partial record class TAccessMethod
    {
        /// <summary>
        /// Represents the sequence stream-access as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TStreamAccess
        {
            /// <summary>
            /// The starting byte position in the file.
            /// </summary>
            public required int FileStartPosition { get; init; }
            
            /// <summary>
            /// The number of bytes to read.
            /// </summary>
            public required Unsigned RequestedOctetCount { get; init; }
            }
    }
}
