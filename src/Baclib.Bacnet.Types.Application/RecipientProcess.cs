// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence BACnetRecipientProcess as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class RecipientProcess
{
    /// <summary>
    /// The recipient of the notification or message.
    /// </summary>
    public required Recipient Recipient { get; init; }

    /// <summary>
    /// The process identifier associated with the recipient.
    /// </summary>
    public required Unsigned32 ProcessIdentifier { get; init; }
}
