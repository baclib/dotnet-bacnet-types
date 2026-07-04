// SPDX-FileCopyrightText: Copyright 2024-2026 The BAClib Initiative and Contributors
// SPDX-License-Identifier: EPL-2.0

namespace Baclib.Bacnet.Serialization.Native.AsduCodecs;

public sealed class SubscribeCovPropertyMultipleErrorCodec :
    IAsduElementCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError>,
    IAsduConstructedCodec<global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError>
{
    public static bool Matches(ref AsduReader reader)
    {
        if (!reader.PeekContextTag(out var contextTagNumber))
        {
            return false;
        }
        return contextTagNumber switch
        {
            0 or
            1 => true,
            _ => false
        };
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError Decode(ref AsduReader reader)
    {
        var tagNumber = reader.ReadContextTagNumber();
        switch (tagNumber)
        {
            case 0:
                var @errorType = ErrorCodec.Decode(ref reader, 0);
                return global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.FromErrorType(@errorType);
            case 1:
                var @firstFailedSubscription = SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec.Decode(ref reader, 1);
                return global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.FromFirstFailedSubscription(@firstFailedSubscription);
        }
        throw new FormatException(nameof(reader));
    }

    public static global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError Decode(ref AsduReader reader, byte tagNumber)
        => AsduConstructed.Decode<SubscribeCovPropertyMultipleErrorCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError>(ref reader, tagNumber);

    public static void Encode(ref AsduWriter writer, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value)
    {
        switch (value.Choice)
        {
            case global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.ErrorType:
                ErrorCodec.Encode(ref writer, 0, value.ErrorType);
                return;
            case global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.FirstFailedSubscription:
                SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec.Encode(ref writer, 1, value.FirstFailedSubscription);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported.");
        }
    }

    public static void Encode(ref AsduWriter writer, byte tagNumber, in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value)
        => AsduConstructed.Encode<SubscribeCovPropertyMultipleErrorCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError>(ref writer, tagNumber, value);

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value)
    {
        return value.Choice switch
        {
            global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.ErrorType
                => ErrorCodec.GetEncodedLength(value.ErrorType, 0),
            global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError.Option.FirstFailedSubscription
                => SubscribeCovPropertyMultipleErrorTFirstFailedSubscriptionCodec.GetEncodedLength(value.FirstFailedSubscription, 1),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value.Choice, "The choice is not supported."),
        };
    }

    public static int GetEncodedLength(in global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError value, byte tagNumber)
        => AsduElement.GetEncodedLength<SubscribeCovPropertyMultipleErrorCodec, global::Baclib.Bacnet.Types.Application.SubscribeCovPropertyMultipleError>(tagNumber, value);
}
