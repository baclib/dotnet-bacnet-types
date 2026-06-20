// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

public partial record class Error
{
    /// <summary>
    /// Represents the enumeration error-code as defined in ANSI/ASHRAE 135-2024 Clause 21.
    /// </summary>
    public enum TErrorCode : ushort
    {
        /// <summary>
        /// Other or unspecified error.
        /// </summary>
        Other = 0,
    
        /// <summary>
        /// Configuration is in progress.
        /// </summary>
        ConfigurationInProgress = 2,
    
        /// <summary>
        /// Device is busy.
        /// </summary>
        DeviceBusy = 3,
    
        /// <summary>
        /// Dynamic creation is not supported.
        /// </summary>
        DynamicCreationNotSupported = 4,
    
        /// <summary>
        /// File access is denied.
        /// </summary>
        FileAccessDenied = 5,
    
        /// <summary>
        /// Parameters are inconsistent.
        /// </summary>
        InconsistentParameters = 7,
    
        /// <summary>
        /// Selection criteria are inconsistent.
        /// </summary>
        InconsistentSelectionCriterion = 8,
    
        /// <summary>
        /// Invalid data type.
        /// </summary>
        InvalidDataType = 9,
    
        /// <summary>
        /// Invalid file access method.
        /// </summary>
        InvalidFileAccessMethod = 10,
    
        /// <summary>
        /// Invalid file start position.
        /// </summary>
        InvalidFileStartPosition = 11,
    
        /// <summary>
        /// Invalid parameter data type.
        /// </summary>
        InvalidParameterDataType = 13,
    
        /// <summary>
        /// Invalid timestamp.
        /// </summary>
        InvalidTimestamp = 14,
    
        /// <summary>
        /// Missing required parameter.
        /// </summary>
        MissingRequiredParameter = 16,
    
        /// <summary>
        /// No objects of specified type.
        /// </summary>
        NoObjectsOfSpecifiedType = 17,
    
        /// <summary>
        /// No space for object.
        /// </summary>
        NoSpaceForObject = 18,
    
        /// <summary>
        /// No space to add list element.
        /// </summary>
        NoSpaceToAddListElement = 19,
    
        /// <summary>
        /// No space to write property.
        /// </summary>
        NoSpaceToWriteProperty = 20,
    
        /// <summary>
        /// No VT sessions available.
        /// </summary>
        NoVtSessionsAvailable = 21,
    
        /// <summary>
        /// Property is not a list.
        /// </summary>
        PropertyIsNotAList = 22,
    
        /// <summary>
        /// Object deletion is not permitted.
        /// </summary>
        ObjectDeletionNotPermitted = 23,
    
        /// <summary>
        /// Object identifier already exists.
        /// </summary>
        ObjectIdentifierAlreadyExists = 24,
    
        /// <summary>
        /// Operational problem.
        /// </summary>
        OperationalProblem = 25,
    
        /// <summary>
        /// Password failure.
        /// </summary>
        PasswordFailure = 26,
    
        /// <summary>
        /// Read access denied.
        /// </summary>
        ReadAccessDenied = 27,
    
        /// <summary>
        /// Service request denied.
        /// </summary>
        ServiceRequestDenied = 29,
    
        /// <summary>
        /// Operation timed out.
        /// </summary>
        Timeout = 30,
    
        /// <summary>
        /// Unknown object.
        /// </summary>
        UnknownObject = 31,
    
        /// <summary>
        /// Unknown property.
        /// </summary>
        UnknownProperty = 32,
    
        /// <summary>
        /// Unknown VT class.
        /// </summary>
        UnknownVtClass = 34,
    
        /// <summary>
        /// Unknown VT session.
        /// </summary>
        UnknownVtSession = 35,
    
        /// <summary>
        /// Unsupported object type.
        /// </summary>
        UnsupportedObjectType = 36,
    
        /// <summary>
        /// Value out of range.
        /// </summary>
        ValueOutOfRange = 37,
    
        /// <summary>
        /// VT session already closed.
        /// </summary>
        VtSessionAlreadyClosed = 38,
    
        /// <summary>
        /// VT session termination failure.
        /// </summary>
        VtSessionTerminationFailure = 39,
    
        /// <summary>
        /// Write access denied.
        /// </summary>
        WriteAccessDenied = 40,
    
        /// <summary>
        /// Character set not supported.
        /// </summary>
        CharacterSetNotSupported = 41,
    
        /// <summary>
        /// Invalid array index.
        /// </summary>
        InvalidArrayIndex = 42,
    
        /// <summary>
        /// COV subscription failed.
        /// </summary>
        CovSubscriptionFailed = 43,
    
        /// <summary>
        /// Not a COV property.
        /// </summary>
        NotCovProperty = 44,
    
        /// <summary>
        /// Optional functionality not supported.
        /// </summary>
        OptionalFunctionalityNotSupported = 45,
    
        /// <summary>
        /// Invalid configuration data.
        /// </summary>
        InvalidConfigurationData = 46,
    
        /// <summary>
        /// Datatype not supported.
        /// </summary>
        DatatypeNotSupported = 47,
    
        /// <summary>
        /// Duplicate name.
        /// </summary>
        DuplicateName = 48,
    
        /// <summary>
        /// Duplicate object identifier.
        /// </summary>
        DuplicateObjectId = 49,
    
        /// <summary>
        /// Property is not an array.
        /// </summary>
        PropertyIsNotAnArray = 50,
    
        /// <summary>
        /// Abort: buffer overflow.
        /// </summary>
        AbortBufferOverflow = 51,
    
        /// <summary>
        /// Abort: invalid APDU in this state.
        /// </summary>
        AbortInvalidApduInThisState = 52,
    
        /// <summary>
        /// Abort: preempted by higher priority task.
        /// </summary>
        AbortPreemptedByHigherPriorityTask = 53,
    
        /// <summary>
        /// Abort: segmentation not supported.
        /// </summary>
        AbortSegmentationNotSupported = 54,
    
        /// <summary>
        /// Abort: proprietary reason.
        /// </summary>
        AbortProprietary = 55,
    
        /// <summary>
        /// Abort: other reason.
        /// </summary>
        AbortOther = 56,
    
        /// <summary>
        /// Invalid tag.
        /// </summary>
        InvalidTag = 57,
    
        /// <summary>
        /// Network is down.
        /// </summary>
        NetworkDown = 58,
    
        /// <summary>
        /// Reject: buffer overflow.
        /// </summary>
        RejectBufferOverflow = 59,
    
        /// <summary>
        /// Reject: inconsistent parameters.
        /// </summary>
        RejectInconsistentParameters = 60,
    
        /// <summary>
        /// Reject: invalid parameter data type.
        /// </summary>
        RejectInvalidParameterDataType = 61,
    
        /// <summary>
        /// Reject: invalid tag.
        /// </summary>
        RejectInvalidTag = 62,
    
        /// <summary>
        /// Reject: missing required parameter.
        /// </summary>
        RejectMissingRequiredParameter = 63,
    
        /// <summary>
        /// Reject: parameter out of range.
        /// </summary>
        RejectParameterOutOfRange = 64,
    
        /// <summary>
        /// Reject: too many arguments.
        /// </summary>
        RejectTooManyArguments = 65,
    
        /// <summary>
        /// Reject: undefined enumeration.
        /// </summary>
        RejectUndefinedEnumeration = 66,
    
        /// <summary>
        /// Reject: unrecognized service.
        /// </summary>
        RejectUnrecognizedService = 67,
    
        /// <summary>
        /// Reject: proprietary reason.
        /// </summary>
        RejectProprietary = 68,
    
        /// <summary>
        /// Reject: other reason.
        /// </summary>
        RejectOther = 69,
    
        /// <summary>
        /// Unknown device.
        /// </summary>
        UnknownDevice = 70,
    
        /// <summary>
        /// Unknown route.
        /// </summary>
        UnknownRoute = 71,
    
        /// <summary>
        /// Value not initialized.
        /// </summary>
        ValueNotInitialized = 72,
    
        /// <summary>
        /// Invalid event state.
        /// </summary>
        InvalidEventState = 73,
    
        /// <summary>
        /// No alarm configured.
        /// </summary>
        NoAlarmConfigured = 74,
    
        /// <summary>
        /// Log buffer full.
        /// </summary>
        LogBufferFull = 75,
    
        /// <summary>
        /// Logged value purged.
        /// </summary>
        LoggedValuePurged = 76,
    
        /// <summary>
        /// No property specified.
        /// </summary>
        NoPropertySpecified = 77,
    
        /// <summary>
        /// Not configured for triggered logging.
        /// </summary>
        NotConfiguredForTriggeredLogging = 78,
    
        /// <summary>
        /// Unknown subscription.
        /// </summary>
        UnknownSubscription = 79,
    
        /// <summary>
        /// Parameter out of range.
        /// </summary>
        ParameterOutOfRange = 80,
    
        /// <summary>
        /// List element not found.
        /// </summary>
        ListElementNotFound = 81,
    
        /// <summary>
        /// Device or resource is busy.
        /// </summary>
        Busy = 82,
    
        /// <summary>
        /// Communication disabled.
        /// </summary>
        CommunicationDisabled = 83,
    
        /// <summary>
        /// Success (no error).
        /// </summary>
        Success = 84,
    
        /// <summary>
        /// Access denied.
        /// </summary>
        AccessDenied = 85,
    
        /// <summary>
        /// Bad destination address.
        /// </summary>
        BadDestinationAddress = 86,
    
        /// <summary>
        /// Bad destination device identifier.
        /// </summary>
        BadDestinationDeviceId = 87,
    
        /// <summary>
        /// Bad signature.
        /// </summary>
        BadSignature = 88,
    
        /// <summary>
        /// Bad source address.
        /// </summary>
        BadSourceAddress = 89,
    
        /// <summary>
        /// Duplicate message received.
        /// </summary>
        DuplicateMessage = 95,
    
        /// <summary>
        /// Encryption not configured.
        /// </summary>
        EncryptionNotConfigured = 96,
    
        /// <summary>
        /// Encryption required.
        /// </summary>
        EncryptionRequired = 97,
    
        /// <summary>
        /// Malformed message.
        /// </summary>
        MalformedMessage = 101,
    
        /// <summary>
        /// Security not configured.
        /// </summary>
        SecurityNotConfigured = 103,
    
        /// <summary>
        /// Source security required.
        /// </summary>
        SourceSecurityRequired = 104,
    
        /// <summary>
        /// Unknown authentication type.
        /// </summary>
        UnknownAuthenticationType = 106,
    
        /// <summary>
        /// Not a router to destination network.
        /// </summary>
        NotRouterToDnet = 110,
    
        /// <summary>
        /// Router is busy.
        /// </summary>
        RouterBusy = 111,
    
        /// <summary>
        /// Unknown network message.
        /// </summary>
        UnknownNetworkMessage = 112,
    
        /// <summary>
        /// Message too long.
        /// </summary>
        MessageTooLong = 113,
    
        /// <summary>
        /// Security error.
        /// </summary>
        SecurityError = 114,
    
        /// <summary>
        /// Addressing error.
        /// </summary>
        AddressingError = 115,
    
        /// <summary>
        /// Write BDT failed.
        /// </summary>
        WriteBdtFailed = 116,
    
        /// <summary>
        /// Read BDT failed.
        /// </summary>
        ReadBdtFailed = 117,
    
        /// <summary>
        /// Register foreign device failed.
        /// </summary>
        RegisterForeignDeviceFailed = 118,
    
        /// <summary>
        /// Read FDT failed.
        /// </summary>
        ReadFdtFailed = 119,
    
        /// <summary>
        /// Delete FDT entry failed.
        /// </summary>
        DeleteFdtEntryFailed = 120,
    
        /// <summary>
        /// Distribute broadcast failed.
        /// </summary>
        DistributeBroadcastFailed = 121,
    
        /// <summary>
        /// Unknown file size.
        /// </summary>
        UnknownFileSize = 122,
    
        /// <summary>
        /// Abort: APDU too long.
        /// </summary>
        AbortApduTooLong = 123,
    
        /// <summary>
        /// Abort: application exceeded reply time.
        /// </summary>
        AbortApplicationExceededReplyTime = 124,
    
        /// <summary>
        /// Abort: out of resources.
        /// </summary>
        AbortOutOfResources = 125,
    
        /// <summary>
        /// Abort: TSM timeout.
        /// </summary>
        AbortTsmTimeout = 126,
    
        /// <summary>
        /// Abort: window size out of range.
        /// </summary>
        AbortWindowSizeOutOfRange = 127,
    
        /// <summary>
        /// File full.
        /// </summary>
        FileFull = 128,
    
        /// <summary>
        /// Inconsistent configuration.
        /// </summary>
        InconsistentConfiguration = 129,
    
        /// <summary>
        /// Inconsistent object type.
        /// </summary>
        InconsistentObjectType = 130,
    
        /// <summary>
        /// Internal error.
        /// </summary>
        InternalError = 131,
    
        /// <summary>
        /// Not configured.
        /// </summary>
        NotConfigured = 132,
    
        /// <summary>
        /// Out of memory.
        /// </summary>
        OutOfMemory = 133,
    
        /// <summary>
        /// Value too long.
        /// </summary>
        ValueTooLong = 134,
    
        /// <summary>
        /// Abort: insufficient security.
        /// </summary>
        AbortInsufficientSecurity = 135,
    
        /// <summary>
        /// Abort: security error.
        /// </summary>
        AbortSecurityError = 136,
    
        /// <summary>
        /// Duplicate entry.
        /// </summary>
        DuplicateEntry = 137,
    
        /// <summary>
        /// Invalid value in this state.
        /// </summary>
        InvalidValueInThisState = 138,
    
        /// <summary>
        /// Invalid operation in this state.
        /// </summary>
        InvalidOperationInThisState = 139,
    
        /// <summary>
        /// List item not numbered.
        /// </summary>
        ListItemNotNumbered = 140,
    
        /// <summary>
        /// List item not timestamped.
        /// </summary>
        ListItemNotTimestamped = 141,
    
        /// <summary>
        /// Invalid data encoding.
        /// </summary>
        InvalidDataEncoding = 142,
    
        /// <summary>
        /// BVLC function unknown.
        /// </summary>
        BvlcFunctionUnknown = 143,
    
        /// <summary>
        /// BVLC proprietary function unknown.
        /// </summary>
        BvlcProprietaryFunctionUnknown = 144,
    
        /// <summary>
        /// Header encoding error.
        /// </summary>
        HeaderEncodingError = 145,
    
        /// <summary>
        /// Header not understood.
        /// </summary>
        HeaderNotUnderstood = 146,
    
        /// <summary>
        /// Message incomplete.
        /// </summary>
        MessageIncomplete = 147,
    
        /// <summary>
        /// Not a BACnet/SC hub.
        /// </summary>
        NotABacnetScHub = 148,
    
        /// <summary>
        /// Payload expected.
        /// </summary>
        PayloadExpected = 149,
    
        /// <summary>
        /// Unexpected data.
        /// </summary>
        UnexpectedData = 150,
    
        /// <summary>
        /// Node duplicate VMAC.
        /// </summary>
        NodeDuplicateVmac = 151,
    
        /// <summary>
        /// HTTP unexpected response code.
        /// </summary>
        HttpUnexpectedResponseCode = 152,
    
        /// <summary>
        /// HTTP upgrade not performed.
        /// </summary>
        HttpNoUpgrade = 153,
    
        /// <summary>
        /// HTTP resource not local.
        /// </summary>
        HttpResourceNotLocal = 154,
    
        /// <summary>
        /// HTTP proxy authentication failed.
        /// </summary>
        HttpProxyAuthenticationFailed = 155,
    
        /// <summary>
        /// HTTP response timeout.
        /// </summary>
        HttpResponseTimeout = 156,
    
        /// <summary>
        /// HTTP response syntax error.
        /// </summary>
        HttpResponseSyntaxError = 157,
    
        /// <summary>
        /// HTTP response value error.
        /// </summary>
        HttpResponseValueError = 158,
    
        /// <summary>
        /// HTTP response missing header.
        /// </summary>
        HttpResponseMissingHeader = 159,
    
        /// <summary>
        /// HTTP WebSocket header error.
        /// </summary>
        HttpWebsocketHeaderError = 160,
    
        /// <summary>
        /// HTTP upgrade required.
        /// </summary>
        HttpUpgradeRequired = 161,
    
        /// <summary>
        /// HTTP upgrade error.
        /// </summary>
        HttpUpgradeError = 162,
    
        /// <summary>
        /// HTTP temporarily unavailable.
        /// </summary>
        HttpTemporaryUnavailable = 163,
    
        /// <summary>
        /// HTTP endpoint is not a server.
        /// </summary>
        HttpNotAServer = 164,
    
        /// <summary>
        /// HTTP error.
        /// </summary>
        HttpError = 165,
    
        /// <summary>
        /// WebSocket scheme not supported.
        /// </summary>
        WebsocketSchemeNotSupported = 166,
    
        /// <summary>
        /// WebSocket unknown control message.
        /// </summary>
        WebsocketUnknownControlMessage = 167,
    
        /// <summary>
        /// WebSocket close error.
        /// </summary>
        WebsocketCloseError = 168,
    
        /// <summary>
        /// WebSocket closed by peer.
        /// </summary>
        WebsocketClosedByPeer = 169,
    
        /// <summary>
        /// WebSocket endpoint leaves.
        /// </summary>
        WebsocketEndpointLeaves = 170,
    
        /// <summary>
        /// WebSocket protocol error.
        /// </summary>
        WebsocketProtocolError = 171,
    
        /// <summary>
        /// WebSocket data not accepted.
        /// </summary>
        WebsocketDataNotAccepted = 172,
    
        /// <summary>
        /// WebSocket closed abnormally.
        /// </summary>
        WebsocketClosedAbnormally = 173,
    
        /// <summary>
        /// WebSocket data inconsistent.
        /// </summary>
        WebsocketDataInconsistent = 174,
    
        /// <summary>
        /// WebSocket data against policy.
        /// </summary>
        WebsocketDataAgainstPolicy = 175,
    
        /// <summary>
        /// WebSocket frame too long.
        /// </summary>
        WebsocketFrameTooLong = 176,
    
        /// <summary>
        /// WebSocket extension missing.
        /// </summary>
        WebsocketExtensionMissing = 177,
    
        /// <summary>
        /// WebSocket request unavailable.
        /// </summary>
        WebsocketRequestUnavailable = 178,
    
        /// <summary>
        /// WebSocket error.
        /// </summary>
        WebsocketError = 179,
    
        /// <summary>
        /// TLS client certificate error.
        /// </summary>
        TlsClientCertificateError = 180,
    
        /// <summary>
        /// TLS server certificate error.
        /// </summary>
        TlsServerCertificateError = 181,
    
        /// <summary>
        /// TLS client authentication failed.
        /// </summary>
        TlsClientAuthenticationFailed = 182,
    
        /// <summary>
        /// TLS server authentication failed.
        /// </summary>
        TlsServerAuthenticationFailed = 183,
    
        /// <summary>
        /// TLS client certificate expired.
        /// </summary>
        TlsClientCertificateExpired = 184,
    
        /// <summary>
        /// TLS server certificate expired.
        /// </summary>
        TlsServerCertificateExpired = 185,
    
        /// <summary>
        /// TLS client certificate revoked.
        /// </summary>
        TlsClientCertificateRevoked = 186,
    
        /// <summary>
        /// TLS server certificate revoked.
        /// </summary>
        TlsServerCertificateRevoked = 187,
    
        /// <summary>
        /// TLS error.
        /// </summary>
        TlsError = 188,
    
        /// <summary>
        /// DNS unavailable.
        /// </summary>
        DnsUnavailable = 189,
    
        /// <summary>
        /// DNS name resolution failed.
        /// </summary>
        DnsNameResolutionFailed = 190,
    
        /// <summary>
        /// DNS resolver failure.
        /// </summary>
        DnsResolverFailure = 191,
    
        /// <summary>
        /// DNS error.
        /// </summary>
        DnsError = 192,
    
        /// <summary>
        /// TCP connect timeout.
        /// </summary>
        TcpConnectTimeout = 193,
    
        /// <summary>
        /// TCP connection refused.
        /// </summary>
        TcpConnectionRefused = 194,
    
        /// <summary>
        /// TCP closed by local endpoint.
        /// </summary>
        TcpClosedByLocal = 195,
    
        /// <summary>
        /// TCP closed by other endpoint.
        /// </summary>
        TcpClosedOther = 196,
    
        /// <summary>
        /// TCP error.
        /// </summary>
        TcpError = 197,
    
        /// <summary>
        /// IP address not reachable.
        /// </summary>
        IpAddressNotReachable = 198,
    
        /// <summary>
        /// IP error.
        /// </summary>
        IpError = 199,
    
        /// <summary>
        /// Certificate expired.
        /// </summary>
        CertificateExpired = 200,
    
        /// <summary>
        /// Certificate invalid.
        /// </summary>
        CertificateInvalid = 201,
    
        /// <summary>
        /// Certificate malformed.
        /// </summary>
        CertificateMalformed = 202,
    
        /// <summary>
        /// Certificate revoked.
        /// </summary>
        CertificateRevoked = 203,
    
        /// <summary>
        /// Unknown certificate key.
        /// </summary>
        UnknownCertificateKey = 204,
    
        /// <summary>
        /// Referenced port in error.
        /// </summary>
        ReferencedPortInError = 205,
    
        /// <summary>
        /// Not enabled.
        /// </summary>
        NotEnabled = 206,
    
        /// <summary>
        /// Adjust scope required.
        /// </summary>
        AdjustScopeRequired = 207,
    
        /// <summary>
        /// Auth scope required.
        /// </summary>
        AuthScopeRequired = 208,
    
        /// <summary>
        /// Bind scope required.
        /// </summary>
        BindScopeRequired = 209,
    
        /// <summary>
        /// Config scope required.
        /// </summary>
        ConfigScopeRequired = 210,
    
        /// <summary>
        /// Control scope required.
        /// </summary>
        ControlScopeRequired = 211,
    
        /// <summary>
        /// Extended scope required.
        /// </summary>
        ExtendedScopeRequired = 212,
    
        /// <summary>
        /// Incorrect client.
        /// </summary>
        IncorrectClient = 213,
    
        /// <summary>
        /// Install scope required.
        /// </summary>
        InstallScopeRequired = 214,
    
        /// <summary>
        /// Insufficient scope.
        /// </summary>
        InsufficientScope = 215,
    
        /// <summary>
        /// No default scope.
        /// </summary>
        NoDefaultScope = 216,
    
        /// <summary>
        /// No policy.
        /// </summary>
        NoPolicy = 217,
    
        /// <summary>
        /// Token revoked.
        /// </summary>
        RevokedToken = 218,
    
        /// <summary>
        /// Override scope required.
        /// </summary>
        OverrideScopeRequired = 219,
    
        /// <summary>
        /// Token inactive.
        /// </summary>
        InactiveToken = 220,
    
        /// <summary>
        /// Unknown audience.
        /// </summary>
        UnknownAudience = 221,
    
        /// <summary>
        /// Unknown client.
        /// </summary>
        UnknownClient = 222,
    
        /// <summary>
        /// Unknown scope.
        /// </summary>
        UnknownScope = 223,
    
        /// <summary>
        /// View scope required.
        /// </summary>
        ViewScopeRequired = 224,
    
        /// <summary>
        /// Incorrect audience.
        /// </summary>
        IncorrectAudience = 225,
    
        /// <summary>
        /// Incorrect client origin.
        /// </summary>
        IncorrectClientOrigin = 226,
    
        /// <summary>
        /// Invalid array size.
        /// </summary>
        InvalidArraySize = 227,
    
        /// <summary>
        /// Incorrect issuer.
        /// </summary>
        IncorrectIssuer = 228,
    
        /// <summary>
        /// Invalid token.
        /// </summary>
        InvalidToken = 229
    }
}
