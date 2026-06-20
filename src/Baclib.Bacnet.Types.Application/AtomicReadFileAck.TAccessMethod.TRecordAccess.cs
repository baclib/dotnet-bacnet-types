// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AtomicReadFileAck
{
    public partial record class TAccessMethod
    {
        /// <summary>
        /// Represents the sequence record-access as defined in ANSI/ASHRAE 135-2024 Clause 21.
        /// </summary>
        public partial record class TRecordAccess
        {
            /// <summary>
            /// The starting record number of the returned data.
            /// </summary>
            public required int FileStartRecord { get; init; }
            
            /// <summary>
            /// The number of records returned.
            /// </summary>
            public required Unsigned ReturnedRecordCount { get; init; }
            
            /// <summary>
            /// A list of records read from the file.
            /// </summary>
            public required TFileRecordData FileRecordData { get; init; }
            }
    }
}
