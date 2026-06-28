// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleErrorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError>
{
    public static bool Matches(ref NativeReader reader)
    {

        var contextTagNumber = reader.PeekContextTagNumber();
        switch (contextTagNumber)
        {
            case 0:
            case 1:
                return true;
            default:
                return false;
        }
    }

    public static bool Matches(ref NativeReader reader, byte tagNumber)
        => reader.PeekOpeningTag(tagNumber);

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError Decode(ref NativeReader reader)
    {
        var tagNumber = reader.PeekContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var _errorType = Asdu.DecodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.FromErrorType(_errorType);
            case 1:
                var _firstFailedSubscription = Asdu.DecodeConstructed<SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription>(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.FromFirstFailedSubscription(_firstFailedSubscription);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError Decode(ref NativeReader reader, byte tagNumber)
    {
        reader.ReadOpeningTag(tagNumber);
        var value = Decode(ref reader);
        reader.ReadClosingTag(tagNumber);
        return value;
    }

    public static void Encode(ref NativeWriter writer, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.ErrorType:
                Asdu.EncodeConstructed<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(ref writer, 0, value.ErrorType);
                return;
            case global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.FirstFailedSubscription:
                Asdu.EncodeConstructed<SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription>(ref writer, 1, value.FirstFailedSubscription);
                return;
        }
        throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
    }

    public static void Encode(ref NativeWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value)
    {
        writer.WriteOpeningTag(tagNumber);
        Encode(ref writer, value);
        writer.WriteClosingTag(tagNumber);
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.ErrorType:
                return Asdu.GetConstructedLength<ErrorCodec, global::Baclib.Bacnet.Types.Application.Error>(0, value.ErrorType);
            case global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.FirstFailedSubscription:
                return Asdu.GetConstructedLength<SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.TFirstFailedSubscription>(1, value.FirstFailedSubscription);
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static int GetLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value, byte tagNumber)
    {
        return AsduLength.FromTagNumber((byte)tagNumber) + GetLength(value) + AsduLength.FromTagNumber((byte)tagNumber);
    }
}