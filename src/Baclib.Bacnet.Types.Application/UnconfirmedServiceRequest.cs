// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

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

    private readonly object _choiceValue;

    private UnconfirmedServiceRequest(Option choice, object value)
    {
        ArgumentNullException.ThrowIfNull(value);
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IAm)}.");
            }
            return (IAmRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.IAm"/>.
    /// </summary>
    public bool TryGetIAm(out IAmRequest value)
    {
        if (Choice == Option.IAm)
        {
            value = (IAmRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.IAm"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromIAm(IAmRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.IHave)}.");
            }
            return (IHaveRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.IHave"/>.
    /// </summary>
    public bool TryGetIHave(out IHaveRequest value)
    {
        if (Choice == Option.IHave)
        {
            value = (IHaveRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.IHave"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromIHave(IHaveRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedCovNotification)}.");
            }
            return (UnconfirmedCovNotificationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnconfirmedCovNotification"/>.
    /// </summary>
    public bool TryGetUnconfirmedCovNotification(out UnconfirmedCovNotificationRequest value)
    {
        if (Choice == Option.UnconfirmedCovNotification)
        {
            value = (UnconfirmedCovNotificationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnconfirmedCovNotification"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromUnconfirmedCovNotification(UnconfirmedCovNotificationRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedEventNotification)}.");
            }
            return (UnconfirmedEventNotificationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnconfirmedEventNotification"/>.
    /// </summary>
    public bool TryGetUnconfirmedEventNotification(out UnconfirmedEventNotificationRequest value)
    {
        if (Choice == Option.UnconfirmedEventNotification)
        {
            value = (UnconfirmedEventNotificationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnconfirmedEventNotification"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromUnconfirmedEventNotification(UnconfirmedEventNotificationRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedPrivateTransfer)}.");
            }
            return (UnconfirmedPrivateTransferRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnconfirmedPrivateTransfer"/>.
    /// </summary>
    public bool TryGetUnconfirmedPrivateTransfer(out UnconfirmedPrivateTransferRequest value)
    {
        if (Choice == Option.UnconfirmedPrivateTransfer)
        {
            value = (UnconfirmedPrivateTransferRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnconfirmedPrivateTransfer"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromUnconfirmedPrivateTransfer(UnconfirmedPrivateTransferRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedTextMessage)}.");
            }
            return (UnconfirmedTextMessageRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnconfirmedTextMessage"/>.
    /// </summary>
    public bool TryGetUnconfirmedTextMessage(out UnconfirmedTextMessageRequest value)
    {
        if (Choice == Option.UnconfirmedTextMessage)
        {
            value = (UnconfirmedTextMessageRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnconfirmedTextMessage"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromUnconfirmedTextMessage(UnconfirmedTextMessageRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.TimeSynchronization)}.");
            }
            return (TimeSynchronizationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.TimeSynchronization"/>.
    /// </summary>
    public bool TryGetTimeSynchronization(out TimeSynchronizationRequest value)
    {
        if (Choice == Option.TimeSynchronization)
        {
            value = (TimeSynchronizationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.TimeSynchronization"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromTimeSynchronization(TimeSynchronizationRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WhoHas)}.");
            }
            return (WhoHasRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.WhoHas"/>.
    /// </summary>
    public bool TryGetWhoHas(out WhoHasRequest value)
    {
        if (Choice == Option.WhoHas)
        {
            value = (WhoHasRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.WhoHas"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromWhoHas(WhoHasRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WhoIs)}.");
            }
            return (WhoIsRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.WhoIs"/>.
    /// </summary>
    public bool TryGetWhoIs(out WhoIsRequest value)
    {
        if (Choice == Option.WhoIs)
        {
            value = (WhoIsRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.WhoIs"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromWhoIs(WhoIsRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UtcTimeSynchronization)}.");
            }
            return (UtcTimeSynchronizationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UtcTimeSynchronization"/>.
    /// </summary>
    public bool TryGetUtcTimeSynchronization(out UtcTimeSynchronizationRequest value)
    {
        if (Choice == Option.UtcTimeSynchronization)
        {
            value = (UtcTimeSynchronizationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UtcTimeSynchronization"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromUtcTimeSynchronization(UtcTimeSynchronizationRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WriteGroup)}.");
            }
            return (WriteGroupRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.WriteGroup"/>.
    /// </summary>
    public bool TryGetWriteGroup(out WriteGroupRequest value)
    {
        if (Choice == Option.WriteGroup)
        {
            value = (WriteGroupRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.WriteGroup"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromWriteGroup(WriteGroupRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedCovNotificationMultiple)}.");
            }
            return (UnconfirmedCovNotificationMultipleRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnconfirmedCovNotificationMultiple"/>.
    /// </summary>
    public bool TryGetUnconfirmedCovNotificationMultiple(out UnconfirmedCovNotificationMultipleRequest value)
    {
        if (Choice == Option.UnconfirmedCovNotificationMultiple)
        {
            value = (UnconfirmedCovNotificationMultipleRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnconfirmedCovNotificationMultiple"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromUnconfirmedCovNotificationMultiple(UnconfirmedCovNotificationMultipleRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.UnconfirmedAuditNotification)}.");
            }
            return (UnconfirmedAuditNotificationRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.UnconfirmedAuditNotification"/>.
    /// </summary>
    public bool TryGetUnconfirmedAuditNotification(out UnconfirmedAuditNotificationRequest value)
    {
        if (Choice == Option.UnconfirmedAuditNotification)
        {
            value = (UnconfirmedAuditNotificationRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.UnconfirmedAuditNotification"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromUnconfirmedAuditNotification(UnconfirmedAuditNotificationRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.WhoAmI)}.");
            }
            return (WhoAmIRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.WhoAmI"/>.
    /// </summary>
    public bool TryGetWhoAmI(out WhoAmIRequest value)
    {
        if (Choice == Option.WhoAmI)
        {
            value = (WhoAmIRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.WhoAmI"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromWhoAmI(WhoAmIRequest value)
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
                throw new InvalidOperationException($"The active choice is {Choice}, not {(Option.YouAre)}.");
            }
            return (YouAreRequest)_choiceValue;
        }
    }

    /// <summary>
    /// Tries to get the value when the active choice is <see cref="Option.YouAre"/>.
    /// </summary>
    public bool TryGetYouAre(out YouAreRequest value)
    {
        if (Choice == Option.YouAre)
        {
            value = (YouAreRequest)_choiceValue;
            return true;
        }

        value = default!;
        return false;
    }
    
    /// <summary>
    /// Creates a choice with the <see cref="Option.YouAre"/> option.
    /// </summary>
    public static UnconfirmedServiceRequest FromYouAre(YouAreRequest value)
    {
        return new UnconfirmedServiceRequest(Option.YouAre, value);
    }
}
