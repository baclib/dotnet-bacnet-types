using System;
using System.Collections.Generic;
using System.Text;

namespace Baclib.Bacnet.Types.Application;

public readonly record struct CreateObjectAck
{
    public ObjectIdentifier ObjectIdentifier { get; init; }
}
