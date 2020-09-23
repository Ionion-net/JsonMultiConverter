using JsonMultiConverter.Interfaces;

namespace JsonMultiConverter.Factory
{
    abstract class JsonCreator
    {
        public abstract IJsonType FactoryMethod();
        public object CreateJsonSomeType(string json)
        {
            // Вызываем фабричный метод, чтобы получить объект-продукт.
            var product = FactoryMethod();
            // Далее, работаем с этим продуктом.
            var result = product.Creater(json);

            return result;
        }
    }
}
