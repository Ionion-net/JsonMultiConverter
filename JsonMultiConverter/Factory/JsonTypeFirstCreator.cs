using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models.JsonModels;

namespace JsonMultiConverter.Factory
{
    class JsonTypeFirstCreator : JsonCreator
    {
        public override IJsonType FactoryMethod()
        {
            return new JsonTypeFirst();
        }
    }
}
