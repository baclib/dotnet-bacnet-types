// SPDX-FileCopyrightText: Copyright 2024-2026, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the sequence BACnetColorCommand as defined in ANSI/ASHRAE 135-2024 Clause 21.
/// </summary>
public partial record class ColorCommand
{
    /// <summary>
    /// The color operation to be performed.
    /// </summary>
    public required ColorOperation Operation { get; init; }
    
    /// <summary>
    /// The target color in XY color space. Optional.
    /// </summary>
    public XyColor? TargetColor { get; init; }

    /// <summary>
    /// The target correlated color temperature in Kelvin. Optional.
    /// </summary>
    public Unsigned? TargetColorTemperature { get; init; }

    /// <summary>
    /// The fade time in milliseconds, ranging from 100 ms to 86400000 ms (24 hours). Optional.
    /// </summary>
    public TFadeTime? FadeTime { get; init; }

    /// <summary>
    /// The ramp rate in Kelvin per second, ranging from 1 to 30000. Optional.
    /// </summary>
    public TRampRate? RampRate { get; init; }

    /// <summary>
    /// The step increment in Kelvin for step operations, ranging from 1 to 30000. Optional.
    /// </summary>
    public TStepIncrement? StepIncrement { get; init; }
}
