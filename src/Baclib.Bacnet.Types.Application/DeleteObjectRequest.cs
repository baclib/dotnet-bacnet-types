// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the sequence DeleteObject-Request as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class DeleteObjectRequest
{
    /// <summary>
    /// The identifier of the object to be deleted.
    /// </summary>
    public required ObjectIdentifier ObjectIdentifier { get; init; }
    }
