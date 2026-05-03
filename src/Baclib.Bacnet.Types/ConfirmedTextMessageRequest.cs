// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence ConfirmedTextMessage-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ConfirmedTextMessageRequest
{
    /// <summary>
    /// The identifier of the device sending the text message.
    /// </summary>
    public required ObjectIdentifier TextMessageSourceDevice { get; init; }
    
    /// <summary>
    /// An optional classification for the message.
    /// </summary>
    public Optional<TMessageClass> MessageClass { get; init; }

    /// <summary>
    /// The priority level of the message.
    /// </summary>
    public required TMessagePriority MessagePriority { get; init; }
    
    /// <summary>
    /// The text content of the message.
    /// </summary>
    public required CharacterString Message { get; init; }
    }
