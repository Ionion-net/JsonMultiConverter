using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models;

namespace JsonMultiConverter.Strategy
{
    class BaseTypeStrategy : IStrategy
    {
        public BasePolicy BasePolicyCreatorFromJson(IJsonType data)
        {
            BasePolicy basePolicy = (BasePolicy)data;
            return basePolicy;
        }
    }
}
