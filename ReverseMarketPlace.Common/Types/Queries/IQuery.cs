using System;
using System.Collections.Generic;
using System.Text;

namespace ReverseMarketPlace.Common.Types.Queries
{
    /// <summary>
    /// Marker interface (pattern). Empty interface only to mark some objects as Iquery. "Obj A is IQuery".
    /// Repesents the user intention to retrive some data.
    /// Doesn't mutate the application state.
    /// Always returns a value.
    /// We shouldn't enqueu this messages.
    /// </summary>
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery
    {
    }
}
