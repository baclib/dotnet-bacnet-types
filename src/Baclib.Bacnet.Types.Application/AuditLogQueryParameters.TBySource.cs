// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AuditLogQueryParameters
{
    /// <summary>
    /// Represents the sequence by-source as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TBySource
    {
        /// <summary>
        /// The device identifier of the source device.
        /// </summary>
        public required ObjectIdentifier SourceDeviceIdentifier { get; init; }
    
        /// <summary>
        /// The network address of the source device.
        /// </summary>
        public Optional<Address> SourceDeviceAddress { get; init; }
    
        /// <summary>
        /// The object identifier on the source device.
        /// </summary>
        public Optional<ObjectIdentifier> SourceObjectIdentifier { get; init; }
    
        /// <summary>
        /// Bit flags specifying which operation types to include.
        /// </summary>
        public Optional<AuditOperationFlags> Operations { get; init; }
    
        /// <summary>
        /// Filter for successful or failed operations.
        /// </summary>
        public required SuccessFilter SuccessfulActionsOnly { get; init; }
    }
}
