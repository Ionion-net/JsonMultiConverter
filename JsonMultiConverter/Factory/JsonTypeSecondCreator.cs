using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models.JsonModels;

namespace JsonMultiConverter.Factory
{
    class JsonTypeSecondCreator : JsonCreator
    {
        public override IJsonType FactoryMethod()
        {
            return new JsonTypeSecond();
        }
    }
}
