// SPDX-FileCopyrightText: Copyright 2024-2025, The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Types;

/// <summary>
/// Represents the enumeration BACnetEngineeringUnits as defined in ANSI/ASHRAE 135-2024 Clause 20.6.
/// </summary>
public enum EngineeringUnits : ushort
{
    /// <summary>
    /// Square meters (m²).
    /// </summary>
    SquareMeters = 0,

    /// <summary>
    /// Square feet (ft²).
    /// </summary>
    SquareFeet = 1,

    /// <summary>
    /// Milliamperes (mA).
    /// </summary>
    Milliamperes = 2,

    /// <summary>
    /// Amperes (A).
    /// </summary>
    Amperes = 3,

    /// <summary>
    /// Ohms (Ω).
    /// </summary>
    Ohms = 4,

    /// <summary>
    /// Volts (V).
    /// </summary>
    Volts = 5,

    /// <summary>
    /// Kilovolts (kV).
    /// </summary>
    Kilovolts = 6,

    /// <summary>
    /// Megavolts (MV).
    /// </summary>
    Megavolts = 7,

    /// <summary>
    /// Volt-amperes (VA).
    /// </summary>
    VoltAmperes = 8,

    /// <summary>
    /// Kilovolt-amperes (kVA).
    /// </summary>
    KilovoltAmperes = 9,

    /// <summary>
    /// Megavolt-amperes (MVA).
    /// </summary>
    MegavoltAmperes = 10,

    /// <summary>
    /// Volt-amperes reactive (var).
    /// </summary>
    VoltAmperesReactive = 11,

    /// <summary>
    /// Kilovolt-amperes reactive (kvar).
    /// </summary>
    KilovoltAmperesReactive = 12,

    /// <summary>
    /// Megavolt-amperes reactive (Mvar).
    /// </summary>
    MegavoltAmperesReactive = 13,

    /// <summary>
    /// Degrees phase (°).
    /// </summary>
    DegreesPhase = 14,

    /// <summary>
    /// Power factor (unitless).
    /// </summary>
    PowerFactor = 15,

    /// <summary>
    /// Joules (J).
    /// </summary>
    Joules = 16,

    /// <summary>
    /// Kilojoules (kJ).
    /// </summary>
    Kilojoules = 17,

    /// <summary>
    /// Watt-hours (Wh).
    /// </summary>
    WattHours = 18,

    /// <summary>
    /// Kilowatt-hours (kWh).
    /// </summary>
    KilowattHours = 19,

    /// <summary>
    /// BTUs (BTU).
    /// </summary>
    Btus = 20,

    /// <summary>
    /// Therms (thm).
    /// </summary>
    Therms = 21,

    /// <summary>
    /// Ton-hours (ton·h).
    /// </summary>
    TonHours = 22,

    /// <summary>
    /// Joules per kilogram dry air (J/kg).
    /// </summary>
    JoulesPerKilogramDryAir = 23,

    /// <summary>
    /// BTUs per pound dry air (BTU/lb).
    /// </summary>
    BtusPerPoundDryAir = 24,

    /// <summary>
    /// Cycles per hour (cph).
    /// </summary>
    CyclesPerHour = 25,

    /// <summary>
    /// Cycles per minute (cpm).
    /// </summary>
    CyclesPerMinute = 26,

    /// <summary>
    /// Hertz (Hz).
    /// </summary>
    Hertz = 27,

    /// <summary>
    /// Grams of water per kilogram dry air (g/kg).
    /// </summary>
    GramsOfWaterPerKilogramDryAir = 28,

    /// <summary>
    /// Percent relative humidity (%RH).
    /// </summary>
    PercentRelativeHumidity = 29,

    /// <summary>
    /// Millimeters (mm).
    /// </summary>
    Millimeters = 30,

    /// <summary>
    /// Meters (m).
    /// </summary>
    Meters = 31,

    /// <summary>
    /// Inches (in).
    /// </summary>
    Inches = 32,

    /// <summary>
    /// Feet (ft).
    /// </summary>
    Feet = 33,

    /// <summary>
    /// Watts per square foot (W/ft²).
    /// </summary>
    WattsPerSquareFoot = 34,

    /// <summary>
    /// Watts per square meter (W/m²).
    /// </summary>
    WattsPerSquareMeter = 35,

    /// <summary>
    /// Lumens (lm).
    /// </summary>
    Lumens = 36,

    /// <summary>
    /// Luxes (lx).
    /// </summary>
    Luxes = 37,

    /// <summary>
    /// Foot-candles (fc).
    /// </summary>
    FootCandles = 38,

    /// <summary>
    /// Kilograms (kg).
    /// </summary>
    Kilograms = 39,

    /// <summary>
    /// Pounds mass (lb).
    /// </summary>
    PoundsMass = 40,

    /// <summary>
    /// Tons (ton).
    /// </summary>
    Tons = 41,

    /// <summary>
    /// Kilograms per second (kg/s).
    /// </summary>
    KilogramsPerSecond = 42,

    /// <summary>
    /// Kilograms per minute (kg/min).
    /// </summary>
    KilogramsPerMinute = 43,

    /// <summary>
    /// Kilograms per hour (kg/h).
    /// </summary>
    KilogramsPerHour = 44,

    /// <summary>
    /// Pounds mass per minute (lb/min).
    /// </summary>
    PoundsMassPerMinute = 45,

    /// <summary>
    /// Pounds mass per hour (lb/h).
    /// </summary>
    PoundsMassPerHour = 46,

    /// <summary>
    /// Watts (W).
    /// </summary>
    Watts = 47,

    /// <summary>
    /// Kilowatts (kW).
    /// </summary>
    Kilowatts = 48,

    /// <summary>
    /// Megawatts (MW).
    /// </summary>
    Megawatts = 49,

    /// <summary>
    /// BTUs per hour (BTU/h).
    /// </summary>
    BtusPerHour = 50,

    /// <summary>
    /// Horsepower (hp).
    /// </summary>
    Horsepower = 51,

    /// <summary>
    /// Tons refrigeration (TR).
    /// </summary>
    TonsRefrigeration = 52,

    /// <summary>
    /// Pascals (Pa).
    /// </summary>
    Pascals = 53,

    /// <summary>
    /// Kilopascals (kPa).
    /// </summary>
    Kilopascals = 54,

    /// <summary>
    /// Bars (bar).
    /// </summary>
    Bars = 55,

    /// <summary>
    /// Pounds-force per square inch (psi).
    /// </summary>
    PoundsForcePerSquareInch = 56,

    /// <summary>
    /// Centimeters of water (cmH₂O).
    /// </summary>
    CentimetersOfWater = 57,

    /// <summary>
    /// Inches of water (inH₂O).
    /// </summary>
    InchesOfWater = 58,

    /// <summary>
    /// Millimeters of mercury (mmHg).
    /// </summary>
    MillimetersOfMercury = 59,

    /// <summary>
    /// Centimeters of mercury (cmHg).
    /// </summary>
    CentimetersOfMercury = 60,

    /// <summary>
    /// Inches of mercury (inHg).
    /// </summary>
    InchesOfMercury = 61,

    /// <summary>
    /// Degrees Celsius (°C).
    /// </summary>
    DegreesCelsius = 62,

    /// <summary>
    /// Kelvin (K).
    /// </summary>
    Kelvin = 63,

    /// <summary>
    /// Degrees Fahrenheit (°F).
    /// </summary>
    DegreesFahrenheit = 64,

    /// <summary>
    /// Degree-days Celsius (°C·d).
    /// </summary>
    DegreeDaysCelsius = 65,

    /// <summary>
    /// Degree-days Fahrenheit (°F·d).
    /// </summary>
    DegreeDaysFahrenheit = 66,

    /// <summary>
    /// Years (yr).
    /// </summary>
    Years = 67,

    /// <summary>
    /// Months (mo).
    /// </summary>
    Months = 68,

    /// <summary>
    /// Weeks (wk).
    /// </summary>
    Weeks = 69,

    /// <summary>
    /// Days (d).
    /// </summary>
    Days = 70,

    /// <summary>
    /// Hours (h).
    /// </summary>
    Hours = 71,

    /// <summary>
    /// Minutes (min).
    /// </summary>
    Minutes = 72,

    /// <summary>
    /// Seconds (s).
    /// </summary>
    Seconds = 73,

    /// <summary>
    /// Meters per second (m/s).
    /// </summary>
    MetersPerSecond = 74,

    /// <summary>
    /// Kilometers per hour (km/h).
    /// </summary>
    KilometersPerHour = 75,

    /// <summary>
    /// Feet per second (ft/s).
    /// </summary>
    FeetPerSecond = 76,

    /// <summary>
    /// Feet per minute (ft/min).
    /// </summary>
    FeetPerMinute = 77,

    /// <summary>
    /// Miles per hour (mph).
    /// </summary>
    MilesPerHour = 78,

    /// <summary>
    /// Cubic feet (ft³).
    /// </summary>
    CubicFeet = 79,

    /// <summary>
    /// Cubic meters (m³).
    /// </summary>
    CubicMeters = 80,

    /// <summary>
    /// Imperial gallons (imp gal).
    /// </summary>
    ImperialGallons = 81,

    /// <summary>
    /// Liters (L).
    /// </summary>
    Liters = 82,

    /// <summary>
    /// US gallons (gal).
    /// </summary>
    UsGallons = 83,

    /// <summary>
    /// Cubic feet per minute (CFM).
    /// </summary>
    CubicFeetPerMinute = 84,

    /// <summary>
    /// Cubic meters per second (m³/s).
    /// </summary>
    CubicMetersPerSecond = 85,

    /// <summary>
    /// Imperial gallons per minute (imp gal/min).
    /// </summary>
    ImperialGallonsPerMinute = 86,

    /// <summary>
    /// Liters per second (L/s).
    /// </summary>
    LitersPerSecond = 87,

    /// <summary>
    /// Liters per minute (L/min).
    /// </summary>
    LitersPerMinute = 88,

    /// <summary>
    /// US gallons per minute (GPM).
    /// </summary>
    UsGallonsPerMinute = 89,

    /// <summary>
    /// Degrees angular (°).
    /// </summary>
    DegreesAngular = 90,

    /// <summary>
    /// Degrees Celsius per hour (°C/h).
    /// </summary>
    DegreesCelsiusPerHour = 91,

    /// <summary>
    /// Degrees Celsius per minute (°C/min).
    /// </summary>
    DegreesCelsiusPerMinute = 92,

    /// <summary>
    /// Degrees Fahrenheit per hour (°F/h).
    /// </summary>
    DegreesFahrenheitPerHour = 93,

    /// <summary>
    /// Degrees Fahrenheit per minute (°F/min).
    /// </summary>
    DegreesFahrenheitPerMinute = 94,

    /// <summary>
    /// No units (unitless).
    /// </summary>
    NoUnits = 95,

    /// <summary>
    /// Parts per million (ppm).
    /// </summary>
    PartsPerMillion = 96,

    /// <summary>
    /// Parts per billion (ppb).
    /// </summary>
    PartsPerBillion = 97,

    /// <summary>
    /// Percent (%).
    /// </summary>
    Percent = 98,

    /// <summary>
    /// Percent per second (%/s).
    /// </summary>
    PercentPerSecond = 99,

    /// <summary>
    /// PSI per degree Fahrenheit (psi/°F).
    /// </summary>
    PsiPerDegreeFahrenheit = 102,

    /// <summary>
    /// Radians (rad).
    /// </summary>
    Radians = 103,

    /// <summary>
    /// Revolutions per minute (RPM).
    /// </summary>
    RevolutionsPerMinute = 104,

    /// <summary>
    /// Currency 1 (site-specific).
    /// </summary>
    Currency1 = 105,

    /// <summary>
    /// Currency 2 (site-specific).
    /// </summary>
    Currency2 = 106,

    /// <summary>
    /// Currency 3 (site-specific).
    /// </summary>
    Currency3 = 107,

    /// <summary>
    /// Currency 4 (site-specific).
    /// </summary>
    Currency4 = 108,

    /// <summary>
    /// Currency 5 (site-specific).
    /// </summary>
    Currency5 = 109,

    /// <summary>
    /// Currency 6 (site-specific).
    /// </summary>
    Currency6 = 110,

    /// <summary>
    /// Currency 7 (site-specific).
    /// </summary>
    Currency7 = 111,

    /// <summary>
    /// Currency 8 (site-specific).
    /// </summary>
    Currency8 = 112,

    /// <summary>
    /// Currency 9 (site-specific).
    /// </summary>
    Currency9 = 113,

    /// <summary>
    /// Currency 10 (site-specific).
    /// </summary>
    Currency10 = 114,

    /// <summary>
    /// Square inches (in²).
    /// </summary>
    SquareInches = 115,

    /// <summary>
    /// Square centimeters (cm²).
    /// </summary>
    SquareCentimeters = 116,

    /// <summary>
    /// BTUs per pound (BTU/lb).
    /// </summary>
    BtusPerPound = 117,

    /// <summary>
    /// Centimeters (cm).
    /// </summary>
    Centimeters = 118,

    /// <summary>
    /// Pounds mass per second (lb/s).
    /// </summary>
    PoundsMassPerSecond = 119,

    /// <summary>
    /// Delta degrees Fahrenheit (Δ°F).
    /// </summary>
    DeltaDegreesFahrenheit = 120,

    /// <summary>
    /// Delta Kelvin (ΔK).
    /// </summary>
    DeltaKelvin = 121,

    /// <summary>
    /// Kiloohms (kΩ).
    /// </summary>
    Kiloohms = 122,

    /// <summary>
    /// Megaohms (MΩ).
    /// </summary>
    Megaohms = 123,

    /// <summary>
    /// Millivolts (mV).
    /// </summary>
    Millivolts = 124,

    /// <summary>
    /// Kilojoules per kilogram (kJ/kg).
    /// </summary>
    KilojoulesPerKilogram = 125,

    /// <summary>
    /// Megajoules (MJ).
    /// </summary>
    Megajoules = 126,

    /// <summary>
    /// Joules per Kelvin (J/K).
    /// </summary>
    JoulesPerKelvin = 127,

    /// <summary>
    /// Joules per kilogram Kelvin (J/(kg·K)).
    /// </summary>
    JoulesPerKilogramKelvin = 128,

    /// <summary>
    /// Kilohertz (kHz).
    /// </summary>
    Kilohertz = 129,

    /// <summary>
    /// Megahertz (MHz).
    /// </summary>
    Megahertz = 130,

    /// <summary>
    /// Per hour (1/h).
    /// </summary>
    PerHour = 131,

    /// <summary>
    /// Milliwatts (mW).
    /// </summary>
    Milliwatts = 132,

    /// <summary>
    /// Hectopascals (hPa).
    /// </summary>
    Hectopascals = 133,

    /// <summary>
    /// Millibars (mbar).
    /// </summary>
    Millibars = 134,

    /// <summary>
    /// Cubic meters per hour (m³/h).
    /// </summary>
    CubicMetersPerHour = 135,

    /// <summary>
    /// Liters per hour (L/h).
    /// </summary>
    LitersPerHour = 136,

    /// <summary>
    /// Kilowatt-hours per square meter (kWh/m²).
    /// </summary>
    KilowattHoursPerSquareMeter = 137,

    /// <summary>
    /// Kilowatt-hours per square foot (kWh/ft²).
    /// </summary>
    KilowattHoursPerSquareFoot = 138,

    /// <summary>
    /// Megajoules per square meter (MJ/m²).
    /// </summary>
    MegajoulesPerSquareMeter = 139,

    /// <summary>
    /// Megajoules per square foot (MJ/ft²).
    /// </summary>
    MegajoulesPerSquareFoot = 140,

    /// <summary>
    /// Watts per square meter per Kelvin (W/(m²·K)).
    /// </summary>
    WattsPerSquareMeterPerKelvin = 141,

    /// <summary>
    /// Cubic feet per second (ft³/s).
    /// </summary>
    CubicFeetPerSecond = 142,

    /// <summary>
    /// Percent obscuration per foot (%/ft).
    /// </summary>
    PercentObscurationPerFoot = 143,

    /// <summary>
    /// Percent obscuration per meter (%/m).
    /// </summary>
    PercentObscurationPerMeter = 144,

    /// <summary>
    /// Milliohms (mΩ).
    /// </summary>
    Milliohms = 145,

    /// <summary>
    /// Megawatt-hours (MWh).
    /// </summary>
    MegawattHours = 146,

    /// <summary>
    /// Kilo-BTUs (kBTU).
    /// </summary>
    KiloBtus = 147,

    /// <summary>
    /// Mega-BTUs (MBTU).
    /// </summary>
    MegaBtus = 148,

    /// <summary>
    /// Kilojoules per kilogram dry air (kJ/kg).
    /// </summary>
    KilojoulesPerKilogramDryAir = 149,

    /// <summary>
    /// Megajoules per kilogram dry air (MJ/kg).
    /// </summary>
    MegajoulesPerKilogramDryAir = 150,

    /// <summary>
    /// Kilojoules per Kelvin (kJ/K).
    /// </summary>
    KilojoulesPerKelvin = 151,

    /// <summary>
    /// Megajoules per Kelvin (MJ/K).
    /// </summary>
    MegajoulesPerKelvin = 152,

    /// <summary>
    /// Newton (N).
    /// </summary>
    Newton = 153,

    /// <summary>
    /// Grams per second (g/s).
    /// </summary>
    GramsPerSecond = 154,

    /// <summary>
    /// Grams per minute (g/min).
    /// </summary>
    GramsPerMinute = 155,

    /// <summary>
    /// Tons per hour (ton/h).
    /// </summary>
    TonsPerHour = 156,

    /// <summary>
    /// Kilo-BTUs per hour (kBTU/h).
    /// </summary>
    KiloBtusPerHour = 157,

    /// <summary>
    /// Hundredths seconds (cs).
    /// </summary>
    HundredthsSeconds = 158,

    /// <summary>
    /// Milliseconds (ms).
    /// </summary>
    Milliseconds = 159,

    /// <summary>
    /// Newton-meters (N·m).
    /// </summary>
    NewtonMeters = 160,

    /// <summary>
    /// Millimeters per second (mm/s).
    /// </summary>
    MillimetersPerSecond = 161,

    /// <summary>
    /// Millimeters per minute (mm/min).
    /// </summary>
    MillimetersPerMinute = 162,

    /// <summary>
    /// Meters per minute (m/min).
    /// </summary>
    MetersPerMinute = 163,

    /// <summary>
    /// Meters per hour (m/h).
    /// </summary>
    MetersPerHour = 164,

    /// <summary>
    /// Cubic meters per minute (m³/min).
    /// </summary>
    CubicMetersPerMinute = 165,

    /// <summary>
    /// Meters per second per second (m/s²).
    /// </summary>
    MetersPerSecondPerSecond = 166,

    /// <summary>
    /// Amperes per meter (A/m).
    /// </summary>
    AmperesPerMeter = 167,

    /// <summary>
    /// Amperes per square meter (A/m²).
    /// </summary>
    AmperesPerSquareMeter = 168,

    /// <summary>
    /// Ampere-square meters (A·m²).
    /// </summary>
    AmpereSquareMeters = 169,

    /// <summary>
    /// Farads (F).
    /// </summary>
    Farads = 170,

    /// <summary>
    /// Henrys (H).
    /// </summary>
    Henrys = 171,

    /// <summary>
    /// Ohm-meters (Ω·m).
    /// </summary>
    OhmMeters = 172,

    /// <summary>
    /// Siemens (S).
    /// </summary>
    Siemens = 173,

    /// <summary>
    /// Siemens per meter (S/m).
    /// </summary>
    SiemensPerMeter = 174,

    /// <summary>
    /// Teslas (T).
    /// </summary>
    Teslas = 175,

    /// <summary>
    /// Volts per Kelvin (V/K).
    /// </summary>
    VoltsPerKelvin = 176,

    /// <summary>
    /// Volts per meter (V/m).
    /// </summary>
    VoltsPerMeter = 177,

    /// <summary>
    /// Webers (Wb).
    /// </summary>
    Webers = 178,

    /// <summary>
    /// Candelas (cd).
    /// </summary>
    Candelas = 179,

    /// <summary>
    /// Candelas per square meter (cd/m²).
    /// </summary>
    CandelasPerSquareMeter = 180,

    /// <summary>
    /// Kelvin per hour (K/h).
    /// </summary>
    KelvinPerHour = 181,

    /// <summary>
    /// Kelvin per minute (K/min).
    /// </summary>
    KelvinPerMinute = 182,

    /// <summary>
    /// Joule-seconds (J·s).
    /// </summary>
    JouleSeconds = 183,

    /// <summary>
    /// Radians per second (rad/s).
    /// </summary>
    RadiansPerSecond = 184,

    /// <summary>
    /// Square meters per Newton (m²/N).
    /// </summary>
    SquareMetersPerNewton = 185,

    /// <summary>
    /// Kilograms per cubic meter (kg/m³).
    /// </summary>
    KilogramsPerCubicMeter = 186,

    /// <summary>
    /// Newton-seconds (N·s).
    /// </summary>
    NewtonSeconds = 187,

    /// <summary>
    /// Newtons per meter (N/m).
    /// </summary>
    NewtonsPerMeter = 188,

    /// <summary>
    /// Watts per meter per Kelvin (W/(m·K)).
    /// </summary>
    WattsPerMeterPerKelvin = 189,

    /// <summary>
    /// Microsiemens (µS).
    /// </summary>
    Microsiemens = 190,

    /// <summary>
    /// Cubic feet per hour (ft³/h).
    /// </summary>
    CubicFeetPerHour = 191,

    /// <summary>
    /// US gallons per hour (gal/h).
    /// </summary>
    UsGallonsPerHour = 192,

    /// <summary>
    /// Kilometers (km).
    /// </summary>
    Kilometers = 193,

    /// <summary>
    /// Micrometers (µm).
    /// </summary>
    Micrometers = 194,

    /// <summary>
    /// Grams (g).
    /// </summary>
    Grams = 195,

    /// <summary>
    /// Milligrams (mg).
    /// </summary>
    Milligrams = 196,

    /// <summary>
    /// Milliliters (mL).
    /// </summary>
    Milliliters = 197,

    /// <summary>
    /// Milliliters per second (mL/s).
    /// </summary>
    MillilitersPerSecond = 198,

    /// <summary>
    /// Decibels (dB).
    /// </summary>
    Decibels = 199,

    /// <summary>
    /// Decibels millivolt (dBmV).
    /// </summary>
    DecibelsMillivolt = 200,

    /// <summary>
    /// Decibels volt (dBV).
    /// </summary>
    DecibelsVolt = 201,

    /// <summary>
    /// Millisiemens (mS).
    /// </summary>
    Millisiemens = 202,

    /// <summary>
    /// Watt-hours reactive (varh).
    /// </summary>
    WattHoursReactive = 203,

    /// <summary>
    /// Kilowatt-hours reactive (kvarh).
    /// </summary>
    KilowattHoursReactive = 204,

    /// <summary>
    /// Megawatt-hours reactive (Mvarh).
    /// </summary>
    MegawattHoursReactive = 205,

    /// <summary>
    /// Millimeters of water (mmH₂O).
    /// </summary>
    MillimetersOfWater = 206,

    /// <summary>
    /// Per mille (‰).
    /// </summary>
    PerMille = 207,

    /// <summary>
    /// Grams per gram (g/g).
    /// </summary>
    GramsPerGram = 208,

    /// <summary>
    /// Kilograms per kilogram (kg/kg).
    /// </summary>
    KilogramsPerKilogram = 209,

    /// <summary>
    /// Grams per kilogram (g/kg).
    /// </summary>
    GramsPerKilogram = 210,

    /// <summary>
    /// Milligrams per gram (mg/g).
    /// </summary>
    MilligramsPerGram = 211,

    /// <summary>
    /// Milligrams per kilogram (mg/kg).
    /// </summary>
    MilligramsPerKilogram = 212,

    /// <summary>
    /// Grams per milliliter (g/mL).
    /// </summary>
    GramsPerMilliliter = 213,

    /// <summary>
    /// Grams per liter (g/L).
    /// </summary>
    GramsPerLiter = 214,

    /// <summary>
    /// Milligrams per liter (mg/L).
    /// </summary>
    MilligramsPerLiter = 215,

    /// <summary>
    /// Micrograms per liter (µg/L).
    /// </summary>
    MicrogramsPerLiter = 216,

    /// <summary>
    /// Grams per cubic meter (g/m³).
    /// </summary>
    GramsPerCubicMeter = 217,

    /// <summary>
    /// Milligrams per cubic meter (mg/m³).
    /// </summary>
    MilligramsPerCubicMeter = 218,

    /// <summary>
    /// Micrograms per cubic meter (µg/m³).
    /// </summary>
    MicrogramsPerCubicMeter = 219,

    /// <summary>
    /// Nanograms per cubic meter (ng/m³).
    /// </summary>
    NanogramsPerCubicMeter = 220,

    /// <summary>
    /// Grams per cubic centimeter (g/cm³).
    /// </summary>
    GramsPerCubicCentimeter = 221,

    /// <summary>
    /// Becquerels (Bq).
    /// </summary>
    Becquerels = 222,

    /// <summary>
    /// Kilobecquerels (kBq).
    /// </summary>
    Kilobecquerels = 223,

    /// <summary>
    /// Megabecquerels (MBq).
    /// </summary>
    Megabecquerels = 224,

    /// <summary>
    /// Gray (Gy).
    /// </summary>
    Gray = 225,

    /// <summary>
    /// Milligray (mGy).
    /// </summary>
    Milligray = 226,

    /// <summary>
    /// Microgray (µGy).
    /// </summary>
    Microgray = 227,

    /// <summary>
    /// Sieverts (Sv).
    /// </summary>
    Sieverts = 228,

    /// <summary>
    /// Millisieverts (mSv).
    /// </summary>
    Millisieverts = 229,

    /// <summary>
    /// Microsieverts (µSv).
    /// </summary>
    Microsieverts = 230,

    /// <summary>
    /// Microsieverts per hour (µSv/h).
    /// </summary>
    MicrosievertsPerHour = 231,

    /// <summary>
    /// Decibels A-weighted (dB(A)).
    /// </summary>
    DecibelsA = 232,

    /// <summary>
    /// Nephelometric turbidity unit (NTU).
    /// </summary>
    NephelometricTurbidityUnit = 233,

    /// <summary>
    /// pH (pH).
    /// </summary>
    Ph = 234,

    /// <summary>
    /// Grams per square meter (g/m²).
    /// </summary>
    GramsPerSquareMeter = 235,

    /// <summary>
    /// Minutes per Kelvin (min/K).
    /// </summary>
    MinutesPerKelvin = 236,

    /// <summary>
    /// Ohm-meter squared per meter (Ω·m²/m).
    /// </summary>
    OhmMeterSquaredPerMeter = 237,

    /// <summary>
    /// Ampere-seconds (A·s).
    /// </summary>
    AmpereSeconds = 238,

    /// <summary>
    /// Volt-ampere-hours (VA·h).
    /// </summary>
    VoltAmpereHours = 239,

    /// <summary>
    /// Kilovolt-ampere-hours (kVA·h).
    /// </summary>
    KilovoltAmpereHours = 240,

    /// <summary>
    /// Megavolt-ampere-hours (MVA·h).
    /// </summary>
    MegavoltAmpereHours = 241,

    /// <summary>
    /// Volt-ampere-hours reactive (varh).
    /// </summary>
    VoltAmpereHoursReactive = 242,

    /// <summary>
    /// Kilovolt-ampere-hours reactive (kvarh).
    /// </summary>
    KilovoltAmpereHoursReactive = 243,

    /// <summary>
    /// Megavolt-ampere-hours reactive (Mvarh).
    /// </summary>
    MegavoltAmpereHoursReactive = 244,

    /// <summary>
    /// Volt-square hours (V²·h).
    /// </summary>
    VoltSquareHours = 245,

    /// <summary>
    /// Ampere-square hours (A²·h).
    /// </summary>
    AmpereSquareHours = 246,

    /// <summary>
    /// Joules per hour (J/h).
    /// </summary>
    JoulesPerHour = 247,

    /// <summary>
    /// Cubic feet per day (ft³/d).
    /// </summary>
    CubicFeetPerDay = 248,

    /// <summary>
    /// Cubic meters per day (m³/d).
    /// </summary>
    CubicMetersPerDay = 249,

    /// <summary>
    /// Watt-hours per cubic meter (Wh/m³).
    /// </summary>
    WattHoursPerCubicMeter = 250,

    /// <summary>
    /// Joules per cubic meter (J/m³).
    /// </summary>
    JoulesPerCubicMeter = 251,

    /// <summary>
    /// Mole percent (mol%).
    /// </summary>
    MolePercent = 252,

    /// <summary>
    /// Pascal-seconds (Pa·s).
    /// </summary>
    PascalSeconds = 253,

    /// <summary>
    /// Million standard cubic feet per minute (MMSCFM).
    /// </summary>
    MillionStandardCubicFeetPerMinute = 254,

    /// <summary>
    /// Standard cubic feet per day (SCFD).
    /// </summary>
    StandardCubicFeetPerDay = 47808,

    /// <summary>
    /// Million standard cubic feet per day (MMSCFD).
    /// </summary>
    MillionStandardCubicFeetPerDay = 47809,

    /// <summary>
    /// Thousand cubic feet per day (MCF/d).
    /// </summary>
    ThousandCubicFeetPerDay = 47810,

    /// <summary>
    /// Thousand standard cubic feet per day (MSCFD).
    /// </summary>
    ThousandStandardCubicFeetPerDay = 47811,

    /// <summary>
    /// Pounds mass per day (lb/d).
    /// </summary>
    PoundsMassPerDay = 47812,

    /// <summary>
    /// Millirems (mrem).
    /// </summary>
    Millirems = 47814,

    /// <summary>
    /// Millirems per hour (mrem/h).
    /// </summary>
    MilliremsPerHour = 47815,

    /// <summary>
    /// Degrees Lovibond (°L).
    /// </summary>
    DegreesLovibond = 47816,

    /// <summary>
    /// Alcohol by volume (ABV).
    /// </summary>
    AlcoholByVolume = 47817,

    /// <summary>
    /// International bittering units (IBU).
    /// </summary>
    InternationalBitteringUnits = 47818,

    /// <summary>
    /// European bitterness units (EBU).
    /// </summary>
    EuropeanBitternessUnits = 47819,

    /// <summary>
    /// Degrees Plato (°P).
    /// </summary>
    DegreesPlato = 47820,

    /// <summary>
    /// Specific gravity (SG).
    /// </summary>
    SpecificGravity = 47821,

    /// <summary>
    /// European Brewing Convention (EBC).
    /// </summary>
    EuropeanBrewingConvention = 47822,

    /// <summary>
    /// Per day (1/d).
    /// </summary>
    PerDay = 47823,

    /// <summary>
    /// Per millisecond (1/ms).
    /// </summary>
    PerMillisecond = 47824,

    /// <summary>
    /// Yards (yd).
    /// </summary>
    Yards = 47825,

    /// <summary>
    /// Miles (mi).
    /// </summary>
    Miles = 47826,

    /// <summary>
    /// Nautical miles (nmi).
    /// </summary>
    NauticalMiles = 47827,

    /// <summary>
    /// Metric tonnes (t).
    /// </summary>
    MetricTonnes = 47830,

    /// <summary>
    /// Short tons (ton).
    /// </summary>
    ShortTons = 47831,

    /// <summary>
    /// Long tons (long ton).
    /// </summary>
    LongTons = 47832,

    /// <summary>
    /// Grams per hour (g/h).
    /// </summary>
    GramsPerHour = 47833,

    /// <summary>
    /// Grams per day (g/d).
    /// </summary>
    GramsPerDay = 47834,

    /// <summary>
    /// Kilograms per day (kg/d).
    /// </summary>
    KilogramsPerDay = 47835,

    /// <summary>
    /// Short tons per second (ton/s).
    /// </summary>
    ShortTonsPerSecond = 47836,

    /// <summary>
    /// Short tons per minute (ton/min).
    /// </summary>
    ShortTonsPerMinute = 47837,

    /// <summary>
    /// Short tons per hour (ton/h).
    /// </summary>
    ShortTonsPerHour = 47838,

    /// <summary>
    /// Short tons per day (ton/d).
    /// </summary>
    ShortTonsPerDay = 47839,

    /// <summary>
    /// Metric tonnes per second (t/s).
    /// </summary>
    MetricTonnesPerSecond = 47840,

    /// <summary>
    /// Metric tonnes per minute (t/min).
    /// </summary>
    MetricTonnesPerMinute = 47841,

    /// <summary>
    /// Metric tonnes per hour (t/h).
    /// </summary>
    MetricTonnesPerHour = 47842,

    /// <summary>
    /// Metric tonnes per day (t/d).
    /// </summary>
    MetricTonnesPerDay = 47843,

    /// <summary>
    /// Long tons per second (long ton/s).
    /// </summary>
    LongTonsPerSecond = 47844,

    /// <summary>
    /// Long tons per minute (long ton/min).
    /// </summary>
    LongTonsPerMinute = 47845,

    /// <summary>
    /// Long tons per hour (long ton/h).
    /// </summary>
    LongTonsPerHour = 47846,

    /// <summary>
    /// Long tons per day (long ton/d).
    /// </summary>
    LongTonsPerDay = 47847,

    /// <summary>
    /// BTUs per second (BTU/s).
    /// </summary>
    BtusPerSecond = 47848,

    /// <summary>
    /// BTUs per minute (BTU/min).
    /// </summary>
    BtusPerMinute = 47849,

    /// <summary>
    /// BTUs per day (BTU/d).
    /// </summary>
    BtusPerDay = 47850,

    /// <summary>
    /// Kilo-BTUs per second (kBTU/s).
    /// </summary>
    KiloBtusPerSecond = 47851,

    /// <summary>
    /// Kilo-BTUs per minute (kBTU/min).
    /// </summary>
    KiloBtusPerMinute = 47852,

    /// <summary>
    /// Kilo-BTUs per day (kBTU/d).
    /// </summary>
    KiloBtusPerDay = 47853,

    /// <summary>
    /// Mega-BTUs per second (MBTU/s).
    /// </summary>
    MegaBtusPerSecond = 47854,

    /// <summary>
    /// Mega-BTUs per minute (MBTU/min).
    /// </summary>
    MegaBtusPerMinute = 47855,

    /// <summary>
    /// Mega-BTUs per hour (MBTU/h).
    /// </summary>
    MegaBtusPerHour = 47856,

    /// <summary>
    /// Mega-BTUs per day (MBTU/d).
    /// </summary>
    MegaBtusPerDay = 47857,

    /// <summary>
    /// Joules per second (J/s).
    /// </summary>
    JoulesPerSecond = 47858,

    /// <summary>
    /// Joules per minute (J/min).
    /// </summary>
    JoulesPerMinute = 47859,

    /// <summary>
    /// Joules per day (J/d).
    /// </summary>
    JoulesPerDay = 47860,

    /// <summary>
    /// Kilojoules per second (kJ/s).
    /// </summary>
    KilojoulesPerSecond = 47861,

    /// <summary>
    /// Kilojoules per minute (kJ/min).
    /// </summary>
    KilojoulesPerMinute = 47862,

    /// <summary>
    /// Kilojoules per hour (kJ/h).
    /// </summary>
    KilojoulesPerHour = 47863,

    /// <summary>
    /// Kilojoules per day (kJ/d).
    /// </summary>
    KilojoulesPerDay = 47864,

    /// <summary>
    /// Megajoules per second (MJ/s).
    /// </summary>
    MegajoulesPerSecond = 47865,

    /// <summary>
    /// Megajoules per minute (MJ/min).
    /// </summary>
    MegajoulesPerMinute = 47866,

    /// <summary>
    /// Megajoules per hour (MJ/h).
    /// </summary>
    MegajoulesPerHour = 47867,

    /// <summary>
    /// Megajoules per day (MJ/d).
    /// </summary>
    MegajoulesPerDay = 47868,

    /// <summary>
    /// Degrees Celsius per day (°C/d).
    /// </summary>
    DegreesCelsiusPerDay = 47869,

    /// <summary>
    /// Degrees Fahrenheit per day (°F/d).
    /// </summary>
    DegreesFahrenheitPerDay = 47871,

    /// <summary>
    /// Delta degrees Celsius (Δ°C).
    /// </summary>
    DeltaDegreesCelsius = 47872,

    /// <summary>
    /// Million cubic feet per minute (MMCFM).
    /// </summary>
    MillionCubicFeetPerMinute = 47873,

    /// <summary>
    /// Million cubic feet per day (MMCFD).
    /// </summary>
    MillionCubicFeetPerDay = 47874,

    /// <summary>
    /// Imperial gallons per second (imp gal/s).
    /// </summary>
    ImperialGallonsPerSecond = 47875,

    /// <summary>
    /// Liters per day (L/d).
    /// </summary>
    LitersPerDay = 47878,

    /// <summary>
    /// US gallons per second (gal/s).
    /// </summary>
    UsGallonsPerSecond = 47879,

    /// <summary>
    /// US gallons per day (gal/d).
    /// </summary>
    UsGallonsPerDay = 47880,

    /// <summary>
    /// Percent per minute (%/min).
    /// </summary>
    PercentPerMinute = 47881,

    /// <summary>
    /// Percent per hour (%/h).
    /// </summary>
    PercentPerHour = 47882,

    /// <summary>
    /// Percent per day (%/d).
    /// </summary>
    PercentPerDay = 47883,

    /// <summary>
    /// Per million (1/10⁶).
    /// </summary>
    PerMillion = 47884,

    /// <summary>
    /// Per billion (1/10⁹).
    /// </summary>
    PerBillion = 47885,

    /// <summary>
    /// Micrograms per kilogram (µg/kg).
    /// </summary>
    MicrogramsPerKilogram = 47888,

    /// <summary>
    /// Nanograms per kilogram (ng/kg).
    /// </summary>
    NanogramsPerKilogram = 47889,

    /// <summary>
    /// Milligrams per milliliter (mg/mL).
    /// </summary>
    MilligramsPerMilliliter = 47890,

    /// <summary>
    /// Micrograms per milliliter (µg/mL).
    /// </summary>
    MicrogramsPerMilliliter = 47891,

    /// <summary>
    /// Nanograms per milliliter (ng/mL).
    /// </summary>
    NanogramsPerMilliliter = 47892,

    /// <summary>
    /// Kilograms per liter (kg/L).
    /// </summary>
    KilogramsPerLiter = 47893,

    /// <summary>
    /// Nanograms per liter (ng/L).
    /// </summary>
    NanogramsPerLiter = 47894,

    /// <summary>
    /// Milligrams per cubic centimeter (mg/cm³).
    /// </summary>
    MilligramsPerCubicCentimeter = 47895,

    /// <summary>
    /// Micrograms per cubic centimeter (µg/cm³).
    /// </summary>
    MicrogramsPerCubicCentimeter = 47896,

    /// <summary>
    /// Nanograms per cubic centimeter (ng/cm³).
    /// </summary>
    NanogramsPerCubicCentimeter = 47897,

    /// <summary>
    /// BTU per hour per watt (BTU/(h·W)).
    /// </summary>
    BtuPerHourPerWatt = 47898,

    /// <summary>
    /// BTU per watt-hour seasonal (BTU/(W·h)).
    /// </summary>
    BtuPerWattHourSeasonal = 47899,

    /// <summary>
    /// Coefficient of performance (COP).
    /// </summary>
    CoefficientOfPerformance = 47900,

    /// <summary>
    /// Coefficient of performance seasonal (SCOP).
    /// </summary>
    CoefficientOfPerformanceSeasonal = 47901,

    /// <summary>
    /// Kilowatt per ton refrigeration (kW/TR).
    /// </summary>
    KilowattPerTonRefrigeration = 47902,

    /// <summary>
    /// Lumens per watt (lm/W).
    /// </summary>
    LumensPerWatt = 47903,

    /// <summary>
    /// Pound-force feet (lbf·ft).
    /// </summary>
    PoundForceFeet = 47904,

    /// <summary>
    /// Pound-force inches (lbf·in).
    /// </summary>
    PoundForceInches = 47905,

    /// <summary>
    /// Ounce-force inches (ozf·in).
    /// </summary>
    OunceForceInches = 47906,

    /// <summary>
    /// Pounds-force per square inch absolute (psia).
    /// </summary>
    PoundsForcePerSquareInchAbsolute = 47907,

    /// <summary>
    /// Pounds-force per square inch gauge (psig).
    /// </summary>
    PoundsForcePerSquareInchGauge = 47908,

    /// <summary>
    /// Microsiemens per centimeter (µS/cm).
    /// </summary>
    MicrosiemensPerCentimeter = 47909,

    /// <summary>
    /// Active energy pulse value (pulse).
    /// </summary>
    ActiveEnergyPulseValue = 47910,

    /// <summary>
    /// Millisiemens per centimeter (mS/cm).
    /// </summary>
    MillisiemensPerCentimeter = 47910,

    /// <summary>
    /// Millisiemens per meter (mS/m).
    /// </summary>
    MillisiemensPerMeter = 47911,

    /// <summary>
    /// Millions of US gallons (Mgal).
    /// </summary>
    MillionsOfUsGallons = 47912,

    /// <summary>
    /// Millions of imperial gallons (Mimp gal).
    /// </summary>
    MillionsOfImperialGallons = 47913,

    /// <summary>
    /// Milliliters per minute (mL/min).
    /// </summary>
    MillilitersPerMinute = 47914,

    /// <summary>
    /// Mils per year (mpy).
    /// </summary>
    MilsPerYear = 47915,

    /// <summary>
    /// Millimeters per year (mm/yr).
    /// </summary>
    MillimetersPerYear = 47916,

    /// <summary>
    /// Pulses per minute (pulse/min).
    /// </summary>
    PulsesPerMinute = 47917,

    /// <summary>
    /// Reactive energy pulse value (pulse).
    /// </summary>
    ReactiveEnergyPulseValue = 47919,

    /// <summary>
    /// Apparent energy pulse value (pulse).
    /// </summary>
    ApparentEnergyPulseValue = 47920,

    /// <summary>
    /// Volt-squared hour pulse value (pulse).
    /// </summary>
    VoltSquaredHourPulseValue = 47921,

    /// <summary>
    /// Ampere-squared hour pulse value (pulse).
    /// </summary>
    AmpereSquaredHourPulseValue = 47922,

    /// <summary>
    /// Cubic meter pulse value (pulse).
    /// </summary>
    CubicMeterPulseValue = 47923,

    /// <summary>
    /// Gigawatts (GW).
    /// </summary>
    Gigawatts = 47924,

    /// <summary>
    /// Bits per second (bps).
    /// </summary>
    BitsPerSecond = 47929,

    /// <summary>
    /// Kilobits per second (kbps).
    /// </summary>
    KilobitsPerSecond = 47930,

    /// <summary>
    /// Megabits per second (Mbps).
    /// </summary>
    MegabitsPerSecond = 47931,

    /// <summary>
    /// Gigabits per second (Gbps).
    /// </summary>
    GigabitsPerSecond = 47932,

    /// <summary>
    /// Bytes per second (B/s).
    /// </summary>
    BytesPerSecond = 47933,

    /// <summary>
    /// Kilobytes per second (KB/s).
    /// </summary>
    KilobytesPerSecond = 47934,

    /// <summary>
    /// Megabytes per second (MB/s).
    /// </summary>
    MegabytesPerSecond = 47935,

    /// <summary>
    /// Gigabytes per second (GB/s).
    /// </summary>
    GigabytesPerSecond = 47936,

    /// <summary>
    /// Volume 1 (site-specific).
    /// </summary>
    Volume1 = 47937,

    /// <summary>
    /// Volume 2 (site-specific).
    /// </summary>
    Volume2 = 47938,

    /// <summary>
    /// Volume 3 (site-specific).
    /// </summary>
    Volume3 = 47939,

    /// <summary>
    /// Volume 4 (site-specific).
    /// </summary>
    Volume4 = 47940,

    /// <summary>
    /// Volume 5 (site-specific).
    /// </summary>
    Volume5 = 47941,

    /// <summary>
    /// Volume 6 (site-specific).
    /// </summary>
    Volume6 = 47942,

    /// <summary>
    /// Volume 7 (site-specific).
    /// </summary>
    Volume7 = 47943,

    /// <summary>
    /// Volume 8 (site-specific).
    /// </summary>
    Volume8 = 47944,

    /// <summary>
    /// Volume 9 (site-specific).
    /// </summary>
    Volume9 = 47945,

    /// <summary>
    /// Volume 10 (site-specific).
    /// </summary>
    Volume10 = 47946,

    /// <summary>
    /// Volumetric flow 1 (site-specific).
    /// </summary>
    VolumetricFlow1 = 47947,

    /// <summary>
    /// Volumetric flow 2 (site-specific).
    /// </summary>
    VolumetricFlow2 = 47948,

    /// <summary>
    /// Volumetric flow 3 (site-specific).
    /// </summary>
    VolumetricFlow3 = 47949,

    /// <summary>
    /// Volumetric flow 4 (site-specific).
    /// </summary>
    VolumetricFlow4 = 47950,

    /// <summary>
    /// Volumetric flow 5 (site-specific).
    /// </summary>
    VolumetricFlow5 = 47951,

    /// <summary>
    /// Volumetric flow 6 (site-specific).
    /// </summary>
    VolumetricFlow6 = 47952,

    /// <summary>
    /// Volumetric flow 7 (site-specific).
    /// </summary>
    VolumetricFlow7 = 47953,

    /// <summary>
    /// Volumetric flow 8 (site-specific).
    /// </summary>
    VolumetricFlow8 = 47954,

    /// <summary>
    /// Volumetric flow 9 (site-specific).
    /// </summary>
    VolumetricFlow9 = 47955,

    /// <summary>
    /// Volumetric flow 10 (site-specific).
    /// </summary>
    VolumetricFlow10 = 47956,

    /// <summary>
    /// Site unit 1 (site-specific).
    /// </summary>
    SiteUnit1 = 47958,

    /// <summary>
    /// Site unit 2 (site-specific).
    /// </summary>
    SiteUnit2 = 47959,

    /// <summary>
    /// Site unit 3 (site-specific).
    /// </summary>
    SiteUnit3 = 47960,

    /// <summary>
    /// Site unit 4 (site-specific).
    /// </summary>
    SiteUnit4 = 47961,

    /// <summary>
    /// Site unit 5 (site-specific).
    /// </summary>
    SiteUnit5 = 47962,

    /// <summary>
    /// Site unit 6 (site-specific).
    /// </summary>
    SiteUnit6 = 47963,

    /// <summary>
    /// Site unit 7 (site-specific).
    /// </summary>
    SiteUnit7 = 47964,

    /// <summary>
    /// Site unit 8 (site-specific).
    /// </summary>
    SiteUnit8 = 47965,

    /// <summary>
    /// Site unit 9 (site-specific).
    /// </summary>
    SiteUnit9 = 47966,

    /// <summary>
    /// Site unit 10 (site-specific).
    /// </summary>
    SiteUnit10 = 47967,

    /// <summary>
    /// Particles per cubic foot (particles/ft³).
    /// </summary>
    ParticlesPerCubicFoot = 47968,

    /// <summary>
    /// Particles per cubic meter (particles/m³).
    /// </summary>
    ParticlesPerCubicMeter = 47969,

    /// <summary>
    /// Picocuries per liter (pCi/L).
    /// </summary>
    PicocuriesPerLiter = 47970,

    /// <summary>
    /// Becquerels per cubic meter (Bq/m³).
    /// </summary>
    BecquerelsPerCubicMeter = 47971,

    /// <summary>
    /// Grains of water per pound dry air (gr/lb).
    /// </summary>
    GrainsOfWaterPerPoundDryAir = 47972,

    /// <summary>
    /// Degree-hours Celsius (°C·h).
    /// </summary>
    DegreeHoursCelsius = 47973,

    /// <summary>
    /// Degree-hours Fahrenheit (°F·h).
    /// </summary>
    DegreeHoursFahrenheit = 47974,

    /// <summary>
    /// Degree-minutes Celsius (°C·min).
    /// </summary>
    DegreeMinutesCelsius = 47975,

    /// <summary>
    /// Degree-minutes Fahrenheit (°F·min).
    /// </summary>
    DegreeMinutesFahrenheit = 47976,

    /// <summary>
    /// Degree-seconds Celsius (°C·s).
    /// </summary>
    DegreeSecondsCelsius = 47977,

    /// <summary>
    /// Degree-seconds Fahrenheit (°F·s).
    /// </summary>
    DegreeSecondsFahrenheit = 47978,

    /// <summary>
    /// Microseconds (µs).
    /// </summary>
    Microseconds = 47979,

    /// <summary>
    /// Nanoseconds (ns).
    /// </summary>
    Nanoseconds = 47980,

    /// <summary>
    /// Picoseconds (ps).
    /// </summary>
    Picoseconds = 47981
}
