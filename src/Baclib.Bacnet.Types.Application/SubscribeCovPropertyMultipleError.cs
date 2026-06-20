// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the choice SubscribeCOVPropertyMultiple-Error as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class SubscribeCovPropertyMultipleError
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// The type of error that occurred.
        /// </summary>
        ErrorType,

        /// <summary>
        /// Details of the first failed subscription, including object, property, and error type.
        /// </summary>
        FirstFailedSubscription
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private SubscribeCovPropertyMultipleError(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// The type of error that occurred.
    /// </summary>
    public Error ErrorType
    {
        get
        {
            if (Choice != Option.ErrorType)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ErrorType)}.");
            }
            return (Error)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for The type of error that occurred.
    /// </summary>
    public static SubscribeCovPropertyMultipleError FromErrorType(Error value)
    {
        return new SubscribeCovPropertyMultipleError(Option.ErrorType, value);
    }

    /// <summary>
    /// Details of the first failed subscription, including object, property, and error type.
    /// </summary>
    public TFirstFailedSubscription FirstFailedSubscription
    {
        get
        {
            if (Choice != Option.FirstFailedSubscription)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.FirstFailedSubscription)}.");
            }
            return (TFirstFailedSubscription)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Details of the first failed subscription, including object, property, and error type.
    /// </summary>
    public static SubscribeCovPropertyMultipleError FromFirstFailedSubscription(TFirstFailedSubscription value)
    {
        return new SubscribeCovPropertyMultipleError(Option.FirstFailedSubscription, value);
    }
}
