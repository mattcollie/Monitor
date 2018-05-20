using System;

namespace Monitor.Common.Enums
{
    [Flags]
    public enum ClientTypes
    {
        None = -1,
        Client = 1,
        Reporter = 2,
        Machine = 4
    }
}