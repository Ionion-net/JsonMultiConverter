using AutoMapper;
using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models;

namespace JsonMultiConverter.Strategy
{
    class FirstTypeStrategy : IStrategy
    {
        readonly Mapper mapper;
        public FirstTypeStrategy(Mapper mapper)
        {
            this.mapper = mapper;
        }
        public BasePolicy BasePolicyCreatorFromJson(IJsonType data)
        {
            BasePolicy basePolicy = mapper.Map<BasePolicy>(data);
            return basePolicy;
        }
    }
}
