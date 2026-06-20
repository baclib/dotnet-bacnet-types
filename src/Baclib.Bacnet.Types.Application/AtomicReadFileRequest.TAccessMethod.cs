// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AtomicReadFileRequest
{
    /// <summary>
    /// Represents the choice access-method as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TAccessMethod
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// Read data from the file as a stream of bytes.
            /// </summary>
            StreamAccess,
    
            /// <summary>
            /// Read data from the file as a series of records.
            /// </summary>
            RecordAccess
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private object _choiceValue
        {
            get;
        }
    
        private TAccessMethod(Option choice, object value)
        {
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// Read data from the file as a stream of bytes.
        /// </summary>
        public TStreamAccess StreamAccess
        {
            get
            {
                if (Choice != Option.StreamAccess)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.StreamAccess)}.");
                }
                return (TStreamAccess)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Read data from the file as a stream of bytes.
        /// </summary>
        public static TAccessMethod FromStreamAccess(TStreamAccess value)
        {
            return new TAccessMethod(Option.StreamAccess, value);
        }
    
        /// <summary>
        /// Read data from the file as a series of records.
        /// </summary>
        public TRecordAccess RecordAccess
        {
            get
            {
                if (Choice != Option.RecordAccess)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.RecordAccess)}.");
                }
                return (TRecordAccess)_choiceValue;
            }
        }
        
        /// <summary>
        /// Create function for Read data from the file as a series of records.
        /// </summary>
        public static TAccessMethod FromRecordAccess(TRecordAccess value)
        {
            return new TAccessMethod(Option.RecordAccess, value);
        }
    }
}
