// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private AuditLogQueryParameters(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ByTarget)}.");
            }
            return (TByTarget)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.ByTarget"/>.
    /// </summary>
    public bool TryGetByTarget(out TByTarget value)
    {
        if (Choice == Option.ByTarget)
        {
            value = (TByTarget)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.ByTarget"/> option.
    /// </summary>
    public static AuditLogQueryParameters FromByTarget(TByTarget value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.BySource)}.");
            }
            return (TBySource)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.BySource"/>.
    /// </summary>
    public bool TryGetBySource(out TBySource value)
    {
        if (Choice == Option.BySource)
        {
            value = (TBySource)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.BySource"/> option.
    /// </summary>
    public static AuditLogQueryParameters FromBySource(TBySource value)
    {
        return new AuditLogQueryParameters(Option.BySource, value);
    }
}
