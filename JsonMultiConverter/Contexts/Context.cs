using AutoMapper;
using JsonMultiConverter.Handlers;
using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models;
using System;

namespace JsonMultiConverter.Contexts
{
    class Context
    {
        readonly AbstractHandler handler;
        readonly Mapper mapper;
        public Context(AbstractHandler handler, Mapper mapper)
        {
            this.handler = handler;
            this.mapper = mapper;
        }
        public BasePolicy ReturnBaseObject(string json)
        {
            BasePolicy result = new BasePolicy();
            var jsonType = (IJsonType)handler.Handle(json);

            if (handler.errors != null)
            {
                foreach (var item in handler.errors)
                    Console.WriteLine(item.ToString());
            }
            if (jsonType is null)
                Console.WriteLine("Ошибка конвертации");
            else
            {
                if (jsonType.GetType() == typeof(BasePolicy))
                    return (BasePolicy)jsonType;
                else
                    result = mapper.Map<BasePolicy>(jsonType);
            }
            return result;
        }
    }
}
