namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents an optional value that may or may not be present.
/// </summary>
/// <typeparam name="T">The underlying value type.</typeparam>
public readonly record struct Optional<T>
{
    private readonly T _value;

    /// <summary>
    /// Gets a value indicating whether this instance contains a value.
    /// </summary>
    public bool HasValue { get; }

    /// <summary>
    /// Initializes a new <see cref="Optional{T}"/> from the specified value.
    /// </summary>
    /// <param name="value">The value to wrap. If <see langword="null"/>, the instance represents no value.</param>
    public Optional(T value)
    {
        if (value == null)
        {
            _value = default!;
            HasValue = false;
        }
        else
        {
            _value = value;
            HasValue = true;
        }
    }

    /// <summary>
    /// Gets the contained value.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown when this instance has no value.</exception>
    public T Value => HasValue
        ? _value
        : throw new InvalidOperationException("Optional hat keinen Wert.");

    /// <summary>
    /// Gets the contained value if present; otherwise returns <paramref name="defaultValue"/>.
    /// </summary>
    /// <param name="defaultValue">The fallback value to return when no value is present.</param>
    /// <returns>The contained value or <paramref name="defaultValue"/>.</returns>
    public T GetValueOr(T defaultValue) => HasValue ? _value : defaultValue;

    /// <summary>
    /// Gets an empty <see cref="Optional{T}"/> instance.
    /// </summary>
    public static Optional<T> None => new Optional<T>();

    /// <summary>
    /// Implicitly converts a value to an <see cref="Optional{T}"/>.
    /// </summary>
    /// <param name="value">The value to wrap.</param>
    public static implicit operator Optional<T>(T value) => new Optional<T>(value);
}
