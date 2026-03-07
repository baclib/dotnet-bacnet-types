// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

public partial record class AtomicWriteFileRequest
{
    public partial record class TAccessMethod
    {
        /// <summary>
        /// Represents the sequence record-access as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TRecordAccess
        {
            /// <summary>
            /// The starting record number in the file.
            /// </summary>
            public required int FileStartRecord { get; init; }
            
            /// <summary>
            /// The number of records to write.
            /// </summary>
            public required Unsigned RecordCount { get; init; }
            
            /// <summary>
            /// A list of records to write to the file.
            /// </summary>
            public required TFileRecordData FileRecordData { get; init; }
            }
    }
}
