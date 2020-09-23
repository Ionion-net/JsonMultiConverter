using System.Collections.Generic;

namespace JsonMultiConverter.Interfaces
{
    public interface IHandler
    {
        IList<string> errors { get; set; }
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }
}
