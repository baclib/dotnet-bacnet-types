// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetSegmentation as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum Segmentation : byte
{
    /// <summary>
    /// Supports both segmented transmission and reception.
    /// </summary>
    SegmentedBoth = 0,

    /// <summary>
    /// Supports only segmented transmission.
    /// </summary>
    SegmentedTransmit = 1,

    /// <summary>
    /// Supports only segmented reception.
    /// </summary>
    SegmentedReceive = 2,

    /// <summary>
    /// Does not support segmentation.
    /// </summary>
    NoSegmentation = 3
}
