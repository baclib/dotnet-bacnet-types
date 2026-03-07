// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetLightingCommand as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class LightingCommand
{
    /// <summary>
    /// The lighting operation to be performed.
    /// </summary>
    public required LightingOperation Operation { get; init; }
    
    /// <summary>
    /// Optional target lighting level as a percentage (0-100%).
    /// </summary>
    public TTargetLevel? TargetLevel { get; init; }

    /// <summary>
    /// Optional ramp rate in percent per second (0.1-100%).
    /// </summary>
    public TRampRate? RampRate { get; init; }

    /// <summary>
    /// Optional step increment as a percentage for step operations (0.1-100%).
    /// </summary>
    public TStepIncrement? StepIncrement { get; init; }

    /// <summary>
    /// Optional fade time in milliseconds (100ms to 24 hours).
    /// </summary>
    public TFadeTime? FadeTime { get; init; }

    /// <summary>
    /// Optional priority level for the command (1-16, where 1 is highest priority).
    /// </summary>
    public TPriority? Priority { get; init; }
}
