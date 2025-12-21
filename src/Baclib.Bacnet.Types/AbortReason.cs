// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetAbortReason as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum AbortReason : byte
{
    /// <summary>
    /// Other reason not covered by the enumerated values.
    /// </summary>
    Other = 0,

    /// <summary>
    /// Buffer overflow occurred during processing.
    /// </summary>
    BufferOverflow = 1,

    /// <summary>
    /// Invalid APDU received in the current state.
    /// </summary>
    InvalidApduInThisState = 2,

    /// <summary>
    /// Operation was preempted by a higher priority task.
    /// </summary>
    PreemptedByHigherPriorityTask = 3,

    /// <summary>
    /// Segmentation is not supported by the device.
    /// </summary>
    SegmentationNotSupported = 4,

    /// <summary>
    /// A security error occurred.
    /// </summary>
    SecurityError = 5,

    /// <summary>
    /// Insufficient security level for the requested operation.
    /// </summary>
    InsufficientSecurity = 6,

    /// <summary>
    /// Window size is out of the acceptable range.
    /// </summary>
    WindowSizeOutOfRange = 7,

    /// <summary>
    /// Application exceeded the allowed reply time.
    /// </summary>
    ApplicationExceededReplyTime = 8,

    /// <summary>
    /// Out of resources to complete the operation.
    /// </summary>
    OutOfResources = 9,

    /// <summary>
    /// Transaction State Machine (TSM) timeout occurred.
    /// </summary>
    TsmTimeout = 10,

    /// <summary>
    /// APDU is too long to process.
    /// </summary>
    ApduTooLong = 11,

    /// <summary>
    /// Inconsistent attributes detected.
    /// </summary>
    InconsistentAttributes = 12
}
