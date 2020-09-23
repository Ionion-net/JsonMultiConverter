using JsonMultiConverter.Interfaces;
using System.Collections.Generic;

namespace JsonMultiConverter.Handlers
{
    abstract class AbstractHandler : IHandler
    {
        private IHandler _nextHandler;

        public virtual IList<string> errors { get; set; }

        public virtual object Handle(object request)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
    }
}
