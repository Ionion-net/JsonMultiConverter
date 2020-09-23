using JsonMultiConverter.Models.JsonModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace JsonMultiConverter.Handlers
{
    class ThirdTypeHandler : AbstractHandler
    {
        readonly JSchemaGenerator generator = new JSchemaGenerator();
        readonly JSchema jsonSchema;
        public ThirdTypeHandler()
        {
            jsonSchema = generator.Generate(typeof(JsonTypeThird));
        }
        public override object Handle(object request)
        {
            JToken json = JToken.Parse(request.ToString());

            if (json.IsValid(jsonSchema))
            {
                return JsonConvert.DeserializeObject<JsonTypeThird>(request.ToString());
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
