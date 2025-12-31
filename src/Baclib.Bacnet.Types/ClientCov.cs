// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet BACnetClientCOV choice type as defined in ANSI/ASHRAE 135-2024.
/// </summary>
/// <remarks>
/// This type allows specifying either a specific COV increment value or using the default.
/// </remarks>
public readonly record struct ClientCov
{
    /// <summary>
    /// Defines the discriminator values for the BACnetClientCOV choice.
    /// </summary>
    public enum ChoiceType
    {
        /// <summary>
        /// A specific real-valued increment.
        /// </summary>
        RealIncrement,

        /// <summary>
        /// Use the default increment (Null).
        /// </summary>
        DefaultIncrement
    }

    private readonly float? _value;

    /// <summary>
    /// Initializes a new instance of the <see cref="ClientCov"/> struct with a specific real increment value.
    /// </summary>
    /// <param name="value">The real increment value.</param>
    public ClientCov(float value)
    {
        _value = value;
    }

    /// <summary>
    /// Gets the default increment value.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the choice is <see cref="ChoiceType.RealIncrement"/> rather than <see cref="ChoiceType.DefaultIncrement"/>.
    /// </exception>
    public Null DefaultIncrement => !_value.HasValue 
        ? Null.Value 
        : throw new InvalidOperationException($"Cannot access DefaultIncrement when choice is {ActiveChoice}.");

    /// <summary>
    /// Gets the real increment value.
    /// </summary>
    /// <exception cref="InvalidOperationException">
    /// Thrown when the choice is <see cref="ChoiceType.DefaultIncrement"/> rather than <see cref="ChoiceType.RealIncrement"/>.
    /// </exception>
    public float RealIncrement => _value 
        ?? throw new InvalidOperationException($"Cannot access RealIncrement when choice is {ActiveChoice}.");

    /// <summary>
    /// Gets the active choice discriminator indicating which variant is currently set.
    /// </summary>
    public ChoiceType ActiveChoice => _value.HasValue ? ChoiceType.RealIncrement : ChoiceType.DefaultIncrement;

    /// <summary>
    /// Implicitly converts a <see cref="float"/> value to a <see cref="ClientCov"/> with real increment.
    /// </summary>
    /// <param name="value">The real increment value.</param>
    public static implicit operator ClientCov(float value) => new(value);

    /// <summary>
    /// Implicitly converts a <see cref="Null"/> value to a <see cref="ClientCov"/> with default increment.
    /// </summary>
    /// <param name="_">The null value (ignored).</param>
    public static implicit operator ClientCov(Null _) => default;

    /// <summary>
    /// Returns a string representation of this <see cref="ClientCov"/> instance.
    /// </summary>
    /// <returns>A string indicating the active choice and its value.</returns>
    public override string ToString() => _value.HasValue 
        ? $"RealIncrement: {_value.Value}" 
        : "DefaultIncrement";
}
