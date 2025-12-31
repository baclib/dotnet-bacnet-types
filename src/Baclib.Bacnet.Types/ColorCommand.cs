// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet BACnetColorCommand type as defined in ANSI/ASHRAE 135-2024.
/// </summary>
/// <remarks>
/// This type represents a command to control the color or color temperature of a lighting device.
/// The operation determines which optional fields are relevant for the command.
/// </remarks>
public readonly record struct ColorCommand
{
    /// <summary>
    /// Minimum allowed fade time in milliseconds.
    /// </summary>
    public const uint MinFadeTime = 100;

    /// <summary>
    /// Maximum allowed fade time in milliseconds (24 hours).
    /// </summary>
    public const uint MaxFadeTime = 86400000;

    /// <summary>
    /// Minimum allowed ramp rate.
    /// </summary>
    public const uint MinRampRate = 1;

    /// <summary>
    /// Maximum allowed ramp rate.
    /// </summary>
    public const uint MaxRampRate = 30000;

    /// <summary>
    /// Minimum allowed step increment.
    /// </summary>
    public const uint MinStepIncrement = 1;

    /// <summary>
    /// Maximum allowed step increment.
    /// </summary>
    public const uint MaxStepIncrement = 30000;

    /// <summary>
    /// Gets the color operation to perform.
    /// </summary>
    public ColorOperation Operation { get; }

    /// <summary>
    /// Gets the target XY color coordinates. Optional field, used with <see cref="ColorOperation.FadeToColor"/>.
    /// </summary>
    public XyColor? TargetColor { get; }

    /// <summary>
    /// Gets the target correlated color temperature in Kelvin. Optional field, used with CCT-related operations.
    /// </summary>
    public uint? TargetColorTemperature { get; }

    /// <summary>
    /// Gets the fade time in milliseconds. Optional field, valid range is 100 to 86,400,000 (24 hours).
    /// </summary>
    public uint? FadeTime { get; }

    /// <summary>
    /// Gets the ramp rate. Optional field, valid range is 1 to 30,000.
    /// </summary>
    public uint? RampRate { get; }

    /// <summary>
    /// Gets the step increment. Optional field, valid range is 1 to 30,000.
    /// </summary>
    public uint? StepIncrement { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ColorCommand"/> struct.
    /// </summary>
    /// <param name="operation">The color operation to perform.</param>
    /// <param name="targetColor">The target XY color coordinates (optional).</param>
    /// <param name="targetColorTemperature">The target correlated color temperature in Kelvin (optional).</param>
    /// <param name="fadeTime">The fade time in milliseconds (optional, range: 100-86,400,000).</param>
    /// <param name="rampRate">The ramp rate (optional, range: 1-30,000).</param>
    /// <param name="stepIncrement">The step increment (optional, range: 1-30,000).</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="fadeTime"/> is not in the range 100-86,400,000,
    /// or when <paramref name="rampRate"/> or <paramref name="stepIncrement"/> is not in the range 1-30,000.
    /// </exception>
    public ColorCommand(
        ColorOperation operation,
        XyColor? targetColor = null,
        uint? targetColorTemperature = null,
        uint? fadeTime = null,
        uint? rampRate = null,
        uint? stepIncrement = null)
    {
        if (fadeTime.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(fadeTime.Value, MinFadeTime, nameof(fadeTime));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(fadeTime.Value, MaxFadeTime, nameof(fadeTime));
        }

        if (rampRate.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(rampRate.Value, MinRampRate, nameof(rampRate));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(rampRate.Value, MaxRampRate, nameof(rampRate));
        }

        if (stepIncrement.HasValue)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(stepIncrement.Value, MinStepIncrement, nameof(stepIncrement));
            ArgumentOutOfRangeException.ThrowIfGreaterThan(stepIncrement.Value, MaxStepIncrement, nameof(stepIncrement));
        }

        Operation = operation;
        TargetColor = targetColor;
        TargetColorTemperature = targetColorTemperature;
        FadeTime = fadeTime;
        RampRate = rampRate;
        StepIncrement = stepIncrement;
    }

    /// <summary>
    /// Returns a string representation of this <see cref="ColorCommand"/>.
    /// </summary>
    /// <returns>A string describing the color command operation and relevant parameters.</returns>
    public override string ToString()
    {
        var parts = new List<string> { $"Operation: {Operation}" };

        if (TargetColor.HasValue)
            parts.Add($"TargetColor: {TargetColor.Value}");

        if (TargetColorTemperature.HasValue)
            parts.Add($"TargetColorTemperature: {TargetColorTemperature.Value}K");

        if (FadeTime.HasValue)
            parts.Add($"FadeTime: {FadeTime.Value}ms");

        if (RampRate.HasValue)
            parts.Add($"RampRate: {RampRate.Value}");

        if (StepIncrement.HasValue)
            parts.Add($"StepIncrement: {StepIncrement.Value}");

        return string.Join(", ", parts);
    }
}