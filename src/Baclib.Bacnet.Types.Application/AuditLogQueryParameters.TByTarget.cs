// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class AuditLogQueryParameters
{
    /// <summary>
    /// Represents the sequence by-target as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TByTarget
    {
        /// <summary>
        /// The device identifier of the target device.
        /// </summary>
        public required ObjectIdentifier TargetDeviceIdentifier { get; init; }
        
        /// <summary>
        /// The network address of the target device.
        /// </summary>
        public Optional<Address> TargetDeviceAddress { get; init; }
    
        /// <summary>
        /// The object identifier on the target device.
        /// </summary>
        public Optional<ObjectIdentifier> TargetObjectIdentifier { get; init; }
    
        /// <summary>
        /// The property identifier on the target object.
        /// </summary>
        public Optional<PropertyIdentifier> TargetPropertyIdentifier { get; init; }
    
        /// <summary>
        /// The array index of the target property.
        /// </summary>
        public Optional<Unsigned> TargetArrayIndex { get; init; }
    
        /// <summary>
        /// The priority level of the operation (1-16).
        /// </summary>
        public Optional<TTargetPriority> TargetPriority { get; init; }
    
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
