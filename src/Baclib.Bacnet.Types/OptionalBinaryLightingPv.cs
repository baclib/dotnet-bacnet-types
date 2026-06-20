// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetOptionalBinaryLightingPV as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class OptionalBinaryLightingPv
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Indicates the absence of a binary lighting PV value.
        /// </summary>
        Null,

        /// <summary>
        /// Specifies the BACnet binary lighting PV value when present.
        /// </summary>
        BinaryLightingPv
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private OptionalBinaryLightingPv(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Indicates the absence of a binary lighting PV value.
    /// </summary>
    public Null Null
    {
        get
        {
            if (Choice != Option.Null)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Null)}.");
            }
            return (Null)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Indicates the absence of a binary lighting PV value.
    /// </summary>
    public static OptionalBinaryLightingPv FromNull(Null value)
    {
        return new OptionalBinaryLightingPv(Option.Null, value);
    }

    /// <summary>
    /// Specifies the BACnet binary lighting PV value when present.
    /// </summary>
    public BinaryLightingPv BinaryLightingPv
    {
        get
        {
            if (Choice != Option.BinaryLightingPv)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BinaryLightingPv)}.");
            }
            return (BinaryLightingPv)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Specifies the BACnet binary lighting PV value when present.
    /// </summary>
    public static OptionalBinaryLightingPv FromBinaryLightingPv(BinaryLightingPv value)
    {
        return new OptionalBinaryLightingPv(Option.BinaryLightingPv, value);
    }
}
