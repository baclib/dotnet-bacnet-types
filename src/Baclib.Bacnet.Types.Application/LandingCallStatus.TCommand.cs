// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class LandingCallStatus
{
    /// <summary>
    /// Represents the choice command as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public partial record class TCommand
    {
        /// <summary>
        /// Represents the tag choice of this choice type.
        /// </summary>
        public enum Option : byte
        {
            /// <summary>
            /// The direction requested for the lift car (up or down).
            /// </summary>
            Direction,
    
            /// <summary>
            /// The destination floor number for the call.
            /// </summary>
            Destination
        }
    
        /// <summary>
        /// The active choice of this instance.
        /// </summary>
        public Option Choice { get; }
    
        private readonly object _choiceValue;
    
        private TCommand(Option choice, object value)
        {
            ArgumentNullException.ThrowIfNull(value);
            Choice = choice;
            _choiceValue = value;
        }
    
        /// <summary>
        /// The direction requested for the lift car (up or down).
        /// </summary>
        public LiftCarDirection Direction
        {
            get
            {
                if (Choice != Option.Direction)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Direction)}.");
                }
                return (LiftCarDirection)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.Direction"/>.
        /// </summary>
        public bool TryGetDirection(out LiftCarDirection value)
        {
            if (Choice == Option.Direction)
            {
                value = (LiftCarDirection)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.Direction"/> option.
        /// </summary>
        public static TCommand FromDirection(LiftCarDirection value)
        {
            return new TCommand(Option.Direction, value);
        }
    
        /// <summary>
        /// The destination floor number for the call.
        /// </summary>
        public Unsigned8 Destination
        {
            get
            {
                if (Choice != Option.Destination)
                {
                    throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.Destination)}.");
                }
                return (Unsigned8)_choiceValue;
            }
        }
    
        /// <summary>
        /// Tries to get the value when the active choice is <see cref="Option.Destination"/>.
        /// </summary>
        public bool TryGetDestination(out Unsigned8 value)
        {
            if (Choice == Option.Destination)
            {
                value = (Unsigned8)_choiceValue;
                return true;
            }
    
            value = default!;
            return false;
        }
        
        /// <summary>
        /// Creates a choice with the <see cref="Option.Destination"/> option.
        /// </summary>
        public static TCommand FromDestination(Unsigned8 value)
        {
            return new TCommand(Option.Destination, value);
        }
    }
}
