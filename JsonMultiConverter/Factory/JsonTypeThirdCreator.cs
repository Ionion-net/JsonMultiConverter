using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models.JsonModels;

namespace JsonMultiConverter.Factory
{
    class JsonTypeThirdCreator : JsonCreator
    {
        public override IJsonType FactoryMethod()
        {
            return new JsonTypeThird();
        }
    }
}
