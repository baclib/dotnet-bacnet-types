namespace Baclib.Bacnet.Types;

public readonly record struct Optional<T>
{
    private readonly T _value;

    public bool HasValue { get; }

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

    public T Value => HasValue
        ? _value
        : throw new InvalidOperationException("Optional hat keinen Wert.");

    public T GetValueOr(T defaultValue) => HasValue ? _value : defaultValue;

    public static Optional<T> None => new Optional<T>();

    public static implicit operator Optional<T>(T value) => new Optional<T>(value);
}
