// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnetPDU as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class Pdu
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// A confirmed request PDU that expects an acknowledgment.
        /// </summary>
        ConfirmedRequestPdu,

        /// <summary>
        /// An unconfirmed request PDU that does not expect an acknowledgment.
        /// </summary>
        UnconfirmedRequestPdu,

        /// <summary>
        /// A simple acknowledgment PDU for a confirmed request.
        /// </summary>
        SimpleAckPdu,

        /// <summary>
        /// A complex acknowledgment PDU that can include response data.
        /// </summary>
        ComplexAckPdu,

        /// <summary>
        /// A segment acknowledgment PDU used with segmented messages.
        /// </summary>
        SegmentAckPdu,

        /// <summary>
        /// An error PDU indicating a service error response.
        /// </summary>
        ErrorPdu,

        /// <summary>
        /// A reject PDU indicating a request was rejected.
        /// </summary>
        RejectPdu,

        /// <summary>
        /// An abort PDU indicating a transaction was aborted.
        /// </summary>
        AbortPdu
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private Pdu(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// A confirmed request PDU that expects an acknowledgment.
    /// </summary>
    public ConfirmedRequestPdu ConfirmedRequestPdu
    {
        get
        {
            if (Choice != Option.ConfirmedRequestPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ConfirmedRequestPdu)} hat das Template erstellt");
            }
            return (ConfirmedRequestPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A confirmed request PDU that expects an acknowledgment.
    /// </summary>
    public static Pdu NewConfirmedRequestPdu(ConfirmedRequestPdu value)
    {
        return new Pdu(Option.ConfirmedRequestPdu, value);
    }

    /// <summary>
    /// An unconfirmed request PDU that does not expect an acknowledgment.
    /// </summary>
    public UnconfirmedRequestPdu UnconfirmedRequestPdu
    {
        get
        {
            if (Choice != Option.UnconfirmedRequestPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedRequestPdu)} hat das Template erstellt");
            }
            return (UnconfirmedRequestPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An unconfirmed request PDU that does not expect an acknowledgment.
    /// </summary>
    public static Pdu NewUnconfirmedRequestPdu(UnconfirmedRequestPdu value)
    {
        return new Pdu(Option.UnconfirmedRequestPdu, value);
    }

    /// <summary>
    /// A simple acknowledgment PDU for a confirmed request.
    /// </summary>
    public SimpleAckPdu SimpleAckPdu
    {
        get
        {
            if (Choice != Option.SimpleAckPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SimpleAckPdu)} hat das Template erstellt");
            }
            return (SimpleAckPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A simple acknowledgment PDU for a confirmed request.
    /// </summary>
    public static Pdu NewSimpleAckPdu(SimpleAckPdu value)
    {
        return new Pdu(Option.SimpleAckPdu, value);
    }

    /// <summary>
    /// A complex acknowledgment PDU that can include response data.
    /// </summary>
    public ComplexAckPdu ComplexAckPdu
    {
        get
        {
            if (Choice != Option.ComplexAckPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ComplexAckPdu)} hat das Template erstellt");
            }
            return (ComplexAckPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A complex acknowledgment PDU that can include response data.
    /// </summary>
    public static Pdu NewComplexAckPdu(ComplexAckPdu value)
    {
        return new Pdu(Option.ComplexAckPdu, value);
    }

    /// <summary>
    /// A segment acknowledgment PDU used with segmented messages.
    /// </summary>
    public SegmentAckPdu SegmentAckPdu
    {
        get
        {
            if (Choice != Option.SegmentAckPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.SegmentAckPdu)} hat das Template erstellt");
            }
            return (SegmentAckPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A segment acknowledgment PDU used with segmented messages.
    /// </summary>
    public static Pdu NewSegmentAckPdu(SegmentAckPdu value)
    {
        return new Pdu(Option.SegmentAckPdu, value);
    }

    /// <summary>
    /// An error PDU indicating a service error response.
    /// </summary>
    public ErrorPdu ErrorPdu
    {
        get
        {
            if (Choice != Option.ErrorPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.ErrorPdu)} hat das Template erstellt");
            }
            return (ErrorPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An error PDU indicating a service error response.
    /// </summary>
    public static Pdu NewErrorPdu(ErrorPdu value)
    {
        return new Pdu(Option.ErrorPdu, value);
    }

    /// <summary>
    /// A reject PDU indicating a request was rejected.
    /// </summary>
    public RejectPdu RejectPdu
    {
        get
        {
            if (Choice != Option.RejectPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.RejectPdu)} hat das Template erstellt");
            }
            return (RejectPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for A reject PDU indicating a request was rejected.
    /// </summary>
    public static Pdu NewRejectPdu(RejectPdu value)
    {
        return new Pdu(Option.RejectPdu, value);
    }

    /// <summary>
    /// An abort PDU indicating a transaction was aborted.
    /// </summary>
    public AbortPdu AbortPdu
    {
        get
        {
            if (Choice != Option.AbortPdu)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.AbortPdu)} hat das Template erstellt");
            }
            return (AbortPdu)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for An abort PDU indicating a transaction was aborted.
    /// </summary>
    public static Pdu NewAbortPdu(AbortPdu value)
    {
        return new Pdu(Option.AbortPdu, value);
    }
}
