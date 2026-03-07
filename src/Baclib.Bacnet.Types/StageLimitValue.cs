// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetStageLimitValue as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class StageLimitValue
{
    /// <summary>
    /// The limit value for the stage.
    /// </summary>
    public required float Limit { get; init; }
    
    /// <summary>
    /// A bit string representing the active stages.
    /// </summary>
    public required BitString Values { get; init; }
    
    /// <summary>
    /// The deadband value for the stage.
    /// </summary>
    public required float Deadband { get; init; }
    }
