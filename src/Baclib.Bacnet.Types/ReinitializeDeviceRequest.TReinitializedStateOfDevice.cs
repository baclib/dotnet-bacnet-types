// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class ReinitializeDeviceRequest
{
    /// <summary>
    /// Represents the enumeration reinitialized-state-of-device as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TReinitializedStateOfDevice : byte
    {
        /// <summary>
        /// Device will perform a coldstart.
        /// </summary>
        Coldstart = 0,
    
        /// <summary>
        /// Device will perform a warmstart.
        /// </summary>
        Warmstart = 1,
    
        /// <summary>
        /// Device will start backup operation.
        /// </summary>
        StartBackup = 2,
    
        /// <summary>
        /// Device will end backup operation.
        /// </summary>
        EndBackup = 3,
    
        /// <summary>
        /// Device will start restore operation.
        /// </summary>
        StartRestore = 4,
    
        /// <summary>
        /// Device will end restore operation.
        /// </summary>
        EndRestore = 5,
    
        /// <summary>
        /// Device will abort restore operation.
        /// </summary>
        AbortRestore = 6,
    
        /// <summary>
        /// Device will activate configuration changes.
        /// </summary>
        ActivateChanges = 7
    }
}
