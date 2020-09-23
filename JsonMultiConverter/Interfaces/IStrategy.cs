using JsonMultiConverter.Models;

namespace JsonMultiConverter.Interfaces
{
    public interface IStrategy
    {
        BasePolicy BasePolicyCreatorFromJson(IJsonType data);
    }
}
