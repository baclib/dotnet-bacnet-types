# Baclib.Bacnet.Serialization.Native.Benchmarks

Microbenchmarks for native BACnet codec hot paths.

## Run all benchmarks

```powershell
dotnet run -c Release --project src/Baclib.Bacnet.Serialization.Native.Benchmarks/Baclib.Bacnet.Serialization.Native.Benchmarks.csproj
```

## Run only BitString benchmarks

```powershell
dotnet run -c Release --project src/Baclib.Bacnet.Serialization.Native.Benchmarks/Baclib.Bacnet.Serialization.Native.Benchmarks.csproj -- --filter "*BitString*"
```

## Notes

- The benchmark class uses `OperationsPerInvoke` with an internal loop to reduce framework overhead noise.
- Encode benchmarks reuse a single `NativeWriter` per benchmark invocation and call `Reset()` for each operation.
- Decode benchmarks recreate `NativeReader` for each operation (it is a `ref struct` over the input span).
