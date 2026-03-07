// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetAuditLogQueryParameters as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class AuditLogQueryParameters
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// Query audit log records based on the target device and object.
        /// </summary>
        ByTarget,

        /// <summary>
        /// Query audit log records based on the source device and object.
        /// </summary>
        BySource
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private AuditLogQueryParameters(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// Query audit log records based on the target device and object.
    /// </summary>
    public TByTarget ByTarget
    {
        get
        {
            if (Choice != Option.ByTarget)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ByTarget)} hat das Template erstellt");
            }
            return (TByTarget)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Query audit log records based on the target device and object.
    /// </summary>
    public static AuditLogQueryParameters NewByTarget(TByTarget value)
    {
        return new AuditLogQueryParameters(Option.ByTarget, value);
    }

    /// <summary>
    /// Query audit log records based on the source device and object.
    /// </summary>
    public TBySource BySource
    {
        get
        {
            if (Choice != Option.BySource)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BySource)} hat das Template erstellt");
            }
            return (TBySource)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Query audit log records based on the source device and object.
    /// </summary>
    public static AuditLogQueryParameters NewBySource(TBySource value)
    {
        return new AuditLogQueryParameters(Option.BySource, value);
    }
}
