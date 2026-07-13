using System;
using System.Collections.Generic;
using System.Text;

namespace Baclib.Bacnet.Types.Application;

/// <summary>
/// Represents the acknowledgment of a CreateObject request in BACnet.
/// </summary>
public readonly record struct CreateObjectAck
{
    /// <summary>
    ///     
    /// </summary>
    public ObjectIdentifier ObjectIdentifier { get; init; }
}
