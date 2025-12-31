// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the BACnet BACnetxyColor type as defined in ANSI/ASHRAE 135-2024.
/// </summary>
/// <remarks>
/// This type represents a color in the CIE 1931 XY color space, where both coordinates
/// must be in the range [0.0, 1.0]. The XY color space is commonly used in lighting
/// applications to specify colors independently of brightness.
/// </remarks>
public readonly record struct XyColor
{
    /// <summary>
    /// The minimum allowed value for X and Y coordinates.
    /// </summary>
    public const float MinValue = 0.0f;

    /// <summary>
    /// The maximum allowed value for X and Y coordinates.
    /// </summary>
    public const float MaxValue = 1.0f;

    /// <summary>
    /// Gets the X coordinate in the CIE 1931 color space.
    /// </summary>
    public float X { get; }

    /// <summary>
    /// Gets the Y coordinate in the CIE 1931 color space.
    /// </summary>
    public float Y { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="XyColor"/> struct.
    /// </summary>
    /// <param name="x">The X coordinate. Must be in the range [0.0, 1.0].</param>
    /// <param name="y">The Y coordinate. Must be in the range [0.0, 1.0].</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when <paramref name="x"/> or <paramref name="y"/> is less than 0.0 or greater than 1.0,
    /// or when either value is NaN or infinite.
    /// </exception>
    public XyColor(float x, float y)
    {
        if (float.IsNaN(x) || float.IsInfinity(x))
        {
            throw new ArgumentOutOfRangeException(nameof(x), x, "X coordinate must be a valid finite number.");
        }

        if (float.IsNaN(y) || float.IsInfinity(y))
        {
            throw new ArgumentOutOfRangeException(nameof(y), y, "Y coordinate must be a valid finite number.");
        }

        ArgumentOutOfRangeException.ThrowIfLessThan(x, MinValue, nameof(x));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(x, MaxValue, nameof(x));
        ArgumentOutOfRangeException.ThrowIfLessThan(y, MinValue, nameof(y));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(y, MaxValue, nameof(y));

        X = x;
        Y = y;
    }

    /// <summary>
    /// Returns a string representation of this <see cref="XyColor"/> in the format "X: {x}, Y: {y}".
    /// </summary>
    /// <returns>A string representing the XY color coordinates.</returns>
    public override string ToString() => $"X: {X:F4}, Y: {Y:F4}";
}
