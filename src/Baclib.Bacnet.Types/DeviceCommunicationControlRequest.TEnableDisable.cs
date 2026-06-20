// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class DeviceCommunicationControlRequest
{
    /// <summary>
    /// Represents the enumeration enable-disable as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TEnableDisable : byte
    {
        /// <summary>
        /// Enable communications.
        /// </summary>
        Enable = 0,
    
        /// <summary>
        /// Disable initiation of communication requests.
        /// </summary>
        DisableInitiation = 2
    }
}
