// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the choice BACnet-Unconfirmed-Service-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class UnconfirmedServiceRequest
{
    /// <summary>
    /// Represents the tag choice of this choice type.
    /// </summary>
    public enum Option : byte
    {
        /// <summary>
        /// I-Am service request.
        /// </summary>
        IAm,

        /// <summary>
        /// I-Have service request.
        /// </summary>
        IHave,

        /// <summary>
        /// Unconfirmed COV notification request.
        /// </summary>
        UnconfirmedCovNotification,

        /// <summary>
        /// Unconfirmed event notification request.
        /// </summary>
        UnconfirmedEventNotification,

        /// <summary>
        /// Unconfirmed private transfer request.
        /// </summary>
        UnconfirmedPrivateTransfer,

        /// <summary>
        /// Unconfirmed text message request.
        /// </summary>
        UnconfirmedTextMessage,

        /// <summary>
        /// Time synchronization request.
        /// </summary>
        TimeSynchronization,

        /// <summary>
        /// Who-Has service request.
        /// </summary>
        WhoHas,

        /// <summary>
        /// Who-Is service request.
        /// </summary>
        WhoIs,

        /// <summary>
        /// UTC time synchronization request.
        /// </summary>
        UtcTimeSynchronization,

        /// <summary>
        /// Write group request.
        /// </summary>
        WriteGroup,

        /// <summary>
        /// Unconfirmed COV notification multiple request.
        /// </summary>
        UnconfirmedCovNotificationMultiple,

        /// <summary>
        /// Unconfirmed audit notification request.
        /// </summary>
        UnconfirmedAuditNotification,

        /// <summary>
        /// Who-Am-I service request.
        /// </summary>
        WhoAmI,

        /// <summary>
        /// You-Are service request.
        /// </summary>
        YouAre
    }

    /// <summary>
    /// The active choice of this instance.
    /// </summary>
    public Option Choice { get; }

    private object _choiceValue
    {
        get;
    }

    private UnconfirmedServiceRequest(Option choice, object value)
    {
        Choice = choice;
        _choiceValue = value;
    }

    /// <summary>
    /// I-Am service request.
    /// </summary>
    public IAmRequest IAm
    {
        get
        {
            if (Choice != Option.IAm)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IAm)} hat das Template erstellt");
            }
            return (IAmRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for I-Am service request.
    /// </summary>
    public static UnconfirmedServiceRequest NewIAm(IAmRequest value)
    {
        return new UnconfirmedServiceRequest(Option.IAm, value);
    }

    /// <summary>
    /// I-Have service request.
    /// </summary>
    public IHaveRequest IHave
    {
        get
        {
            if (Choice != Option.IHave)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IHave)} hat das Template erstellt");
            }
            return (IHaveRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for I-Have service request.
    /// </summary>
    public static UnconfirmedServiceRequest NewIHave(IHaveRequest value)
    {
        return new UnconfirmedServiceRequest(Option.IHave, value);
    }

    /// <summary>
    /// Unconfirmed COV notification request.
    /// </summary>
    public UnconfirmedCovNotificationRequest UnconfirmedCovNotification
    {
        get
        {
            if (Choice != Option.UnconfirmedCovNotification)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedCovNotification)} hat das Template erstellt");
            }
            return (UnconfirmedCovNotificationRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Unconfirmed COV notification request.
    /// </summary>
    public static UnconfirmedServiceRequest NewUnconfirmedCovNotification(UnconfirmedCovNotificationRequest value)
    {
        return new UnconfirmedServiceRequest(Option.UnconfirmedCovNotification, value);
    }

    /// <summary>
    /// Unconfirmed event notification request.
    /// </summary>
    public UnconfirmedEventNotificationRequest UnconfirmedEventNotification
    {
        get
        {
            if (Choice != Option.UnconfirmedEventNotification)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedEventNotification)} hat das Template erstellt");
            }
            return (UnconfirmedEventNotificationRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Unconfirmed event notification request.
    /// </summary>
    public static UnconfirmedServiceRequest NewUnconfirmedEventNotification(UnconfirmedEventNotificationRequest value)
    {
        return new UnconfirmedServiceRequest(Option.UnconfirmedEventNotification, value);
    }

    /// <summary>
    /// Unconfirmed private transfer request.
    /// </summary>
    public UnconfirmedPrivateTransferRequest UnconfirmedPrivateTransfer
    {
        get
        {
            if (Choice != Option.UnconfirmedPrivateTransfer)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedPrivateTransfer)} hat das Template erstellt");
            }
            return (UnconfirmedPrivateTransferRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Unconfirmed private transfer request.
    /// </summary>
    public static UnconfirmedServiceRequest NewUnconfirmedPrivateTransfer(UnconfirmedPrivateTransferRequest value)
    {
        return new UnconfirmedServiceRequest(Option.UnconfirmedPrivateTransfer, value);
    }

    /// <summary>
    /// Unconfirmed text message request.
    /// </summary>
    public UnconfirmedTextMessageRequest UnconfirmedTextMessage
    {
        get
        {
            if (Choice != Option.UnconfirmedTextMessage)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedTextMessage)} hat das Template erstellt");
            }
            return (UnconfirmedTextMessageRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Unconfirmed text message request.
    /// </summary>
    public static UnconfirmedServiceRequest NewUnconfirmedTextMessage(UnconfirmedTextMessageRequest value)
    {
        return new UnconfirmedServiceRequest(Option.UnconfirmedTextMessage, value);
    }

    /// <summary>
    /// Time synchronization request.
    /// </summary>
    public TimeSynchronizationRequest TimeSynchronization
    {
        get
        {
            if (Choice != Option.TimeSynchronization)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimeSynchronization)} hat das Template erstellt");
            }
            return (TimeSynchronizationRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Time synchronization request.
    /// </summary>
    public static UnconfirmedServiceRequest NewTimeSynchronization(TimeSynchronizationRequest value)
    {
        return new UnconfirmedServiceRequest(Option.TimeSynchronization, value);
    }

    /// <summary>
    /// Who-Has service request.
    /// </summary>
    public WhoHasRequest WhoHas
    {
        get
        {
            if (Choice != Option.WhoHas)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WhoHas)} hat das Template erstellt");
            }
            return (WhoHasRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Who-Has service request.
    /// </summary>
    public static UnconfirmedServiceRequest NewWhoHas(WhoHasRequest value)
    {
        return new UnconfirmedServiceRequest(Option.WhoHas, value);
    }

    /// <summary>
    /// Who-Is service request.
    /// </summary>
    public WhoIsRequest WhoIs
    {
        get
        {
            if (Choice != Option.WhoIs)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WhoIs)} hat das Template erstellt");
            }
            return (WhoIsRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Who-Is service request.
    /// </summary>
    public static UnconfirmedServiceRequest NewWhoIs(WhoIsRequest value)
    {
        return new UnconfirmedServiceRequest(Option.WhoIs, value);
    }

    /// <summary>
    /// UTC time synchronization request.
    /// </summary>
    public UtcTimeSynchronizationRequest UtcTimeSynchronization
    {
        get
        {
            if (Choice != Option.UtcTimeSynchronization)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UtcTimeSynchronization)} hat das Template erstellt");
            }
            return (UtcTimeSynchronizationRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for UTC time synchronization request.
    /// </summary>
    public static UnconfirmedServiceRequest NewUtcTimeSynchronization(UtcTimeSynchronizationRequest value)
    {
        return new UnconfirmedServiceRequest(Option.UtcTimeSynchronization, value);
    }

    /// <summary>
    /// Write group request.
    /// </summary>
    public WriteGroupRequest WriteGroup
    {
        get
        {
            if (Choice != Option.WriteGroup)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WriteGroup)} hat das Template erstellt");
            }
            return (WriteGroupRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Write group request.
    /// </summary>
    public static UnconfirmedServiceRequest NewWriteGroup(WriteGroupRequest value)
    {
        return new UnconfirmedServiceRequest(Option.WriteGroup, value);
    }

    /// <summary>
    /// Unconfirmed COV notification multiple request.
    /// </summary>
    public UnconfirmedCovNotificationMultipleRequest UnconfirmedCovNotificationMultiple
    {
        get
        {
            if (Choice != Option.UnconfirmedCovNotificationMultiple)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedCovNotificationMultiple)} hat das Template erstellt");
            }
            return (UnconfirmedCovNotificationMultipleRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Unconfirmed COV notification multiple request.
    /// </summary>
    public static UnconfirmedServiceRequest NewUnconfirmedCovNotificationMultiple(UnconfirmedCovNotificationMultipleRequest value)
    {
        return new UnconfirmedServiceRequest(Option.UnconfirmedCovNotificationMultiple, value);
    }

    /// <summary>
    /// Unconfirmed audit notification request.
    /// </summary>
    public UnconfirmedAuditNotificationRequest UnconfirmedAuditNotification
    {
        get
        {
            if (Choice != Option.UnconfirmedAuditNotification)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedAuditNotification)} hat das Template erstellt");
            }
            return (UnconfirmedAuditNotificationRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Unconfirmed audit notification request.
    /// </summary>
    public static UnconfirmedServiceRequest NewUnconfirmedAuditNotification(UnconfirmedAuditNotificationRequest value)
    {
        return new UnconfirmedServiceRequest(Option.UnconfirmedAuditNotification, value);
    }

    /// <summary>
    /// Who-Am-I service request.
    /// </summary>
    public WhoAmIRequest WhoAmI
    {
        get
        {
            if (Choice != Option.WhoAmI)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WhoAmI)} hat das Template erstellt");
            }
            return (WhoAmIRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for Who-Am-I service request.
    /// </summary>
    public static UnconfirmedServiceRequest NewWhoAmI(WhoAmIRequest value)
    {
        return new UnconfirmedServiceRequest(Option.WhoAmI, value);
    }

    /// <summary>
    /// You-Are service request.
    /// </summary>
    public YouAreRequest YouAre
    {
        get
        {
            if (Choice != Option.YouAre)
            {
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.YouAre)} hat das Template erstellt");
            }
            return (YouAreRequest)_choiceValue;
        }
    }
    
    /// <summary>
    /// Create function for You-Are service request.
    /// </summary>
    public static UnconfirmedServiceRequest NewYouAre(YouAreRequest value)
    {
        return new UnconfirmedServiceRequest(Option.YouAre, value);
    }
}
