# BACnet Primitives

This directory contains strongly-typed representations of BACnet primitive data types.

## Design Philosophy

### When We Create Wrapper Types

We create dedicated structs for BACnet types when they:

1. **Have different structure than C# primitives**
   - Example: `Date` - 4 bytes with wildcard semantics
   - Example: `Time` - 4 bytes with hundredths, wildcards

2. **Need additional behavior**
   - Example: `OctetString` - immutability, hex conversion
   - Example: `CharacterString` - encoding metadata

3. **Require semantic distinction**
   - Example: `Null` - distinguishes from C# null

### When We Use C# Built-in Types

We use C# primitives directly for:

- **Boolean** → `bool`
- **Unsigned** → `uint`
- **Integer** → `int`
- **Real** → `float`
- **Double** → `double`
- **Enumerated** → C# `enum` types

**Rationale:** These have identical semantics, encoding, and value ranges. Wrapping adds no value and creates unnecessary API friction.

## Implementation Patterns

### Readonly Record Structs
All primitive types are `readonly record struct` for:
- **Immutability** - Thread-safe by default
- **Value semantics** - Copy-by-value behavior
- **Zero allocation overhead** - Stack allocation or inlining
- **Structural equality** - Automatic value-based equality
- **Consistency** - Uniform pattern across all primitives

### Memory Layout
Types that map to wire format use efficient memory layouts:
- **`Date`** - 4 individual byte fields (year, month, day, day-of-week)
- **`Time`** - 4 individual byte fields (hour, minute, second, hundredths)
- **`ObjectIdentifier`** - Single 32-bit uint with bit-packed type and instance
- **`OctetString`, `BitString`, `CharacterString`** - Managed byte arrays with metadata

### Wildcard Support
`Date` and `Time` types support BACnet wildcards:
- **Wildcard value (255)** for "any" field
- **`Date` special values**: Odd/even months (13, 14), odd/even days, last day of month (32)
- **Validation properties**: `IsValid`, `IsSpecific`, field-specific validity checks
- **Pattern matching** for scheduling and filtering via `Matches()` method
### Equality
All types provide:
- Structural equality via `record struct` - automatic value-based comparison
- `==` and `!=` operators
- Proper `GetHashCode()` for use in collections
- No need to manually implement `IEquatable<T>` - provided by `record`s
- Structural equality (value-based comparison)
### Serialization
Primitive types in this folder handle their own data representation:
- **`OctetString`, `BitString`, `CharacterString`** - Store raw BACnet-encoded bytes internally
- **`Date`, `Time`** - Store individual byte fields matching BACnet format
- **`ObjectIdentifier`** - Stores packed 32-bit value
- **`Null`, `Enumerated`** - Simple value types

### Conversions
Types provide conversions to/from .NET types:
- **`Date`** ↔ `DateTime`, `DateOnly` (explicit constructors and `ToDateTime()`, `ToDateOnly()`)
- **`Time`** ↔ `TimeSpan`, `TimeOnly`, `DateTime` (explicit constructors and conversion methods)
- **`OctetString`** ↔ `byte[]`, `ReadOnlySpan<byte>` (implicit and explicit conversions)
- **`BitString`** - Indexer access, `SetBit()`, `ClearBit()`, `IsBitSet()` methods
- **`CharacterString`** ↔ `string` (constructors with encoding, `Value` property)
- **`ObjectIdentifier`** - Constructor from type + instance, `Type` and `Instance` properties
- **`Enumerated`** ↔ strongly-typed enums via `FromEnum<T>()` and `ToEnum<T>()`
- `Time` ↔ `TimeSpan`, `TimeOnly`, `DateTime`
- `OctetString` ↔ `byte[]`, `ReadOnlySpan<byte>`
- **Implicit conversions** where natural and unambiguous

## Type Reference

### Files in Primitives Folder

| File                    | Type(s)                | Description |
|-------------------------|------------------------|-------------|
| `Null.cs`               | `Null`                 | BACnet Null primitive - semantic distinction from C# null |
| `OctetString.cs`        | `OctetString`          | Immutable byte sequence with hex conversion |
| `BitString.cs`          | `BitString`            | Variable-length bit array with BACnet encoding |
| `CharacterString.cs`    | `CharacterString`      | String with character set encoding metadata |
| `CharacterSet.cs`       | `CharacterSet` (enum)  | Character encoding identifiers (UTF-8, UCS-2, UCS-4, ISO-8859-1, JIS, DBCS) |
| `CharacterEncoder.cs`   | `CharacterEncoder`     | Encoding/decoding support for character strings |
| `Enumerated.cs`         | `Enumerated`           | Generic 32-bit enumeration wrapper |
| `Date.cs`               | `Date`                 | 4-byte date with wildcard and pattern support |
| `Time.cs`               | `Time`                 | 4-byte time with wildcard support |
| `ObjectIdentifier.cs`   | `ObjectIdentifier`     | 32-bit packed type and instance number |

### BACnet Primitive Type Mapping

| BACnet Type       | C# Implementation   | Location | Rationale |
|-------------------|---------------------|----------|-----------|
| Null              | `Null`              | Primitives | Semantic distinction from C# null |
| BOOLEAN           | `bool`              | Built-in | Identical semantics |
| Unsigned          | `uint`              | Built-in | Identical semantics |
| Integer           | `int`               | Built-in | Identical semantics |
| Real              | `float`             | Built-in | Identical semantics (32-bit IEEE 754) |
| Double            | `double`            | Built-in | Identical semantics (64-bit IEEE 754) |
| Octet String      | `OctetString`       | Primitives | Immutability, hex conversion |
| Bit String        | `BitString`         | Primitives | Non-standard bit array representation |
| Character String  | `CharacterString`   | Primitives | Encoding metadata required |
| Enumerated        | `Enumerated` / `enum` | Primitives / Built-in | Generic wrapper or strong typing |
| Date              | `Date`              | Primitives | 4-byte structure with wildcards |
| Time              | `Time`              | Primitives | 4-byte structure with wildcards |
| Object Identifier | `ObjectIdentifier`  | Primitives | 32-bit packed type + instance |

### Composite Types (in Composites Folder)

| Type              | Description |
|-------------------|-------------|
| `DateTime`        | Composite (Date + Time) |
| `DateRange`       | Composite (start + end dates) |
| `TimeRange`       | Composite (start + end times) |
| `DateTimeRange`   | Composite (start + end date-times) |
| `WeekNDay`        | 3-byte structure for recurring schedules |
| `ObjectType`      | Enumeration of BACnet object types |

## Performance Considerations

- **Zero overhead** - Structs are stack-allocated or inlined by JIT
- **Span-based APIs** - Avoid allocations in hot paths
- **JIT optimization** - Modern .NET optimizes small structs perfectly
- **Memory layout** - Direct mapping to wire format eliminates conversion overhead
- **No boxing** - Value types used throughout

## Examples

### Working with Date and Time

```csharp
// Create specific date
var date = new Date(new DateTime(2025, 12, 4));

// Date with wildcards - any day in December
var anyDayInDec = new Date(125, 12, Date.Wildcard, Date.Wildcard);

// Time from .NET TimeSpan
var time = new Time(TimeSpan.FromHours(14.5));

// Convert back to .NET types
DateTime? dt = date.ToDateTime();
TimeSpan? ts = time.ToTimeSpan();

// Composite DateTime
var dateTime = new DateTime(date, time);
var sysDateTime = dateTime.ToDateTime(); // Returns System.DateTime?
```

### Date and Time Ranges

```csharp
// DateRange - for scheduling date periods
var summerRange = new DateRange(
    new Date(new DateTime(2025, 6, 1)),
    new Date(new DateTime(2025, 8, 31))
);

if (summerRange.Contains(new Date(new DateTime(2025, 7, 15))))
{
    Console.WriteLine("Date is in summer range");
}

// TimeRange - for daily schedules (handles midnight-spanning)
var nightShift = new TimeRange(
    new Time(22, 0, 0, 0),  // 22:00
    new Time(6, 0, 0, 0)     // 06:00
);

if (nightShift.Contains(new Time(23, 30, 0, 0)))
{
    Console.WriteLine("Time is during night shift");
}

// DateTimeRange - for precise time periods
var eventRange = new DateTimeRange(
    new DateTime(2025, 12, 24, 18, 0, 0, 0),
    new DateTime(2025, 12, 25, 2, 0, 0, 0)
);

var duration = eventRange.GetDuration(); // Returns TimeSpan?
```

### Recurring Events with WeekNDay

```csharp
// Second Tuesday of March
var weekNDay = new WeekNDay(3, 2, 2);

// Last Friday of every month
var lastFriday = new WeekNDay(WeekNDay.Wildcard, 
                                     WeekNDay.LastWeek, 5);

// Every Monday in odd months
### Octet Strings

```csharp
// From byte array
byte[] data = { 0x48, 0x65, 0x6C, 0x6C, 0x6F };
var octetString = new OctetString(data);

// From hex string
var fromHex = OctetString.FromHex("48656C6C6F");

// Convert to hex
string hex = octetString.ToHexString(); // "48656C6C6F"

// Implicit conversion
OctetString str = new byte[] { 0x01, 0x02, 0x03 };

// Access via indexer
### NULL Values

```csharp
// BACnet NULL is a value, not absence of value
var nullValue = Null.Value;

// Check for NULL
if (value == Null.Value)
    Console.WriteLine("Value is explicitly NULL");

// Different from C# null
Null? optional = null;        // C# null (no value)
Null actual = Null.Value;     // BACnet NULL (explicit value)

// ToString returns "Null"
### Using C# Primitives Directly

```csharp
// BACnet Unsigned, Integer, Real, Double, Boolean
uint objectInstance = 1234;
int analogValue = -42;
float temperature = 21.5f;
double precision = 3.14159265359;
bool isActive = true;

// No wrapping needed - use directly in your API
// These are encoded/decoded by AsduWriter/AsduReader
```

### Bit Strings
### Working with Raw Bytes

```csharp
// Types store BACnet-formatted data internally
// For example, OctetString stores raw bytes directly
var octets = new OctetString([0x01, 0x02, 0x03]);
ReadOnlySpan<byte> span = octets.AsSpan();

// Date and Time can be created from raw bytes
// (year-1900, month, day, day-of-week)
var dateFromBytes = new Date(125, 12, 5, 4); // 2025-12-05, Thursday

// Access individual fields
byte year = dateFromBytes.Year;   // 125 (represents 2025)
byte month = dateFromBytes.Month; // 12
byte day = dateFromBytes.Day;     // 5
```

## Contributing

When adding new primitive types, follow these guidelines:

1. **Use `readonly record struct`** for value types (provides automatic structural equality)
2. **Add comprehensive XML documentation** on all public members
3. **Store data in BACnet wire format** where practical
4. **Add `ToString()` override** with human-readable output
5. **Include SPDX license header** in all files:
   ```csharp
   // SPDX-FileCopyrightText: Copyright 2024-2025 The BAClib Initiative and Contributors
   // SPDX-License-Identifier: BSD-2-Clause
   ```
6. **Write unit tests** covering edge cases and wildcards
7. **Update this README** with the new type
## Architecture Notes

### Why Individual Byte Fields vs Packed Integers?

For types like `Date` and `Time`, we use individual byte fields rather than a single packed integer:

**Advantages:**
- **Type safety** - Clear, self-documenting field access (`date.Month` vs bit shifting)
- **BACnet alignment** - Direct mapping to protocol specification
- **Wildcard support** - Trivial to check for special values (255)
- **Readability** - `date.Month` is clearer than `(packed >> 16) & 0xFF`
- **Performance** - Zero overhead with modern JIT optimization
- **Debugging** - Fields visible in debugger without bit manipulation

**When We Use Packed Integers:**
- `ObjectIdentifier` packs type (10 bits) and instance (22 bits) into a single `uint`
- This matches the BACnet wire format exactly (single 32-bit value)
- Provides efficient properties to extract components

### Why Record Struct?

All primitives are `readonly record struct` because:
- **Value semantics** - Copying behavior matches primitive types
- **No heap allocation** - Performance in tight loops
- **No null checks needed** - Always have a value
- **Immutable by default** - Thread-safe
- **Automatic equality** - Structural comparison without manual implementation
- **Consistent with .NET** - Matches `int`, `DateTime`, etc.

### Character Encoding Strategy

`CharacterString` uses a static `CharacterEncoder` property to handle encoding/decoding:
- **UTF-8, UCS-2, UCS-4, ISO-8859-1** - Pre-configured static encodings
- **JIS X 0208** - Uses code page 932 (Shift-JIS) by default
- **DBCS** - Dynamic code page lookup with caching
- **Thread-safe** - Uses `ConcurrentDictionary` for cache and `Volatile` for property access
- **Configurable** - Set `CharacterString.Encoder` at startup to customize encoding behavior

The encoder is cached to avoid repeated lookup overhead while allowing runtime configuration for JIS and DBCS variants.

#### Custom Character Encoding

To use a custom character encoder, inherit from `CharacterEncoder` and set it during application startup:

```csharp
// Custom encoder with different JIS encoding
public class CustomCharacterEncoder : CharacterEncoder
{
    // Override to use EUC-JP instead of Shift-JIS for JIS X 0208
    protected override TextEncoding JisX0208Encoding => GetDbcsEncoding(20932);
    
    // Or override GetString for complete control over decoding
    public override string GetString(ReadOnlySpan<byte> data, out CharacterSet charSet)
    {
        // Custom decoding logic
        return base.GetString(data, out charSet);
    }
}

// Set at application startup (before creating any CharacterString instances)
public static void Main()
{
    // Configure custom encoder once at startup
    CharacterString.Encoder = new CustomCharacterEncoder();
    
    // Now all CharacterString operations use the custom encoder
    var str = new CharacterString(bacnetBytes);
}
```

**Best Practices:**
- Set the encoder **once** during application startup
- Do not change the encoder after creating `CharacterString` instances
- The default encoder is thread-safe and suitable for most applications
- Only create a custom encoder if you need non-standard JIS encoding or special decoding logic

### Data Storage Philosophy

Each primitive type stores data in a form that balances:
1. **BACnet wire format alignment** - Easy encoding/decoding
2. **.NET developer ergonomics** - Familiar access patterns
3. **Performance** - Minimal allocations and conversions
4. **Type safety** - Compile-time correctness

Examples:
- `OctetString` - Immutable byte array (matches wire format, easy to work with)
- `BitString` - Byte array with metadata (length encoding in first byte)
- `CharacterString` - Decoded string + encoding metadata (fast access, preserves encoding info)
- `Date`/`Time` - Individual byte fields (readable, efficient, supports wildcards)
- `ObjectIdentifier` - Packed uint (compact, efficient extraction)

```
// Access components
ObjectType type = objId.Type;     // AnalogInput
uint instance = objId.Instance;   // 123

// From packed value
var fromValue = new ObjectIdentifier(0x00C0007B); // AI:123

// Get packed value
uint packed = objId.Value; // 0x00C0007B

// ToString with format
Console.WriteLine(objId); // Shows type and instance
```

### Enumerated Values

```csharp
// From strongly-typed enum
var enumValue = Enumerated.FromEnum(PropertyIdentifier.ObjectName);

// Get raw value
uint value = enumValue.Value;

// Convert back to strongly-typed enum
var propId = enumValue.ToEnum<PropertyIdentifier>();

// Safe conversion with validation
if (enumValue.TryToEnum<PropertyIdentifier>(out var result))
{
    Console.WriteLine($"Valid PropertyIdentifier: {result}");
}
```l actual = Null.Value; // BACnet NULL (explicit value)
```

### Using C# Primitives Directly

```csharp
// BACnet Unsigned, Integer, Real, Double, Boolean
uint objectInstance = 1234;
int analogValue = -42;
float temperature = 21.5f;
double precision = 3.14159265359;
bool isActive = true;

// No wrapping needed - use directly in your API
device.SetProperty(PropertyIdentifier.ObjectInstance, objectInstance);
device.SetProperty(PropertyIdentifier.PresentValue, temperature);
```

### Serialization

```csharp
// Encode to buffer (zero allocation)
Span<byte> buffer = stackalloc byte[4];
date.WriteTo(buffer);

// Decode from buffer
var decoded = new Date(buffer);

// Convenience method (allocates)
byte[] bytes = date.ToBytes();
```

## Contributing

When adding new primitive types, follow these guidelines:

1. **Use `readonly struct`** for value types
2. **Implement `IEquatable<T>`** with proper equality semantics
3. **Add comprehensive XML documentation** on all public members
4. **Provide `ReadOnlySpan<byte>` constructor** for deserialization
5. **Include `WriteTo()` and `ToBytes()` methods** for serialization
6. **Add `ToString()` override** with human-readable output
7. **Use `[StructLayout(LayoutKind.Sequential, Pack = 1)]`** where appropriate
8. **Include SPDX license header** in all files
9. **Write unit tests** covering edge cases and wildcards
10. **Update this README** with the new type

## Architecture Notes

### Why Individual Byte Fields vs Packed Integers?

For composite types like `Date` and `Time`, we use individual byte fields rather than a single packed integer:

**Advantages:**
- **Type safety** - Clear, self-documenting field access
- **BACnet alignment** - Direct mapping to protocol specification
- **Wildcard support** - Trivial to check for special values (255)
- **Readability** - `date.Month` vs bit manipulation
- **Performance** - Zero difference with modern JIT optimization

### Why Struct vs Class?

All primitives are structs because:
- **Value semantics** - Copying behavior matches primitive types
- **No heap allocation** - Performance in tight loops
- **No null checks needed** - Always have a value
- **Immutable by default** - Thread-safe
- **Consistent with .NET primitives** - Matches `int`, `DateTime`, etc.

### Character Encoding Strategy

`CharacterString` uses a configurable `CharacterEncoder` to handle:
- UTF-8, UCS-2, UCS-4, ISO-8859-1 (static encodings)
- JIS X 0208 (configurable via `JisEncodingName` property)
- DBCS (dynamic code page support)

This balances performance (cached encodings) with flexibility (runtime configuration).

## See Also

- [BACnet Protocol Specification (ASHRAE 135)](https://www.ashrae.org/technical-resources/bookstore/standard-135)
- [.NET Span<T> Documentation](https://docs.microsoft.com/en-us/dotnet/api/system.span-1)
- [Struct Design Guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/struct)
