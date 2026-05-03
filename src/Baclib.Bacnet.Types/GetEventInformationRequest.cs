// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence GetEventInformation-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class GetEventInformationRequest
{
    /// <summary>
    /// Optional object identifier of the last event object received, used for pagination of event information.
    /// </summary>
    public Optional<ObjectIdentifier> LastReceivedObjectIdentifier { get; init; }
}
