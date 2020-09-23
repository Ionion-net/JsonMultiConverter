using JsonMultiConverter.Models.JsonModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;

namespace JsonMultiConverter.Handlers
{
    class FirstTypeHandler : AbstractHandler
    {
        readonly JSchemaGenerator generator = new JSchemaGenerator();
        readonly JSchema jsonSchema;

        public FirstTypeHandler()
        {
            jsonSchema = generator.Generate(typeof(JsonTypeFirst));
        }
        public override object Handle(object request)
        {
                JToken json = JToken.Parse(request.ToString());

                if (json.IsValid(jsonSchema))
                {
                    return JsonConvert.DeserializeObject<JsonTypeFirst>(request.ToString());
                }
                else
                {
                    return base.Handle(request);
                }
        }
    }
}
