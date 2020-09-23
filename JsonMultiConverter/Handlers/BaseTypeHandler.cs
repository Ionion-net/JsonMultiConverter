using JsonMultiConverter.Interfaces;
using JsonMultiConverter.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using System.Collections.Generic;

namespace JsonMultiConverter.Handlers
{
    class BaseTypeHandler : AbstractHandler
    {
        JSchemaGenerator generator = new JSchemaGenerator();
        JSchema jsonSchema;
        IList<string> error;
        public override IList<string> errors { get => error; }
        public BaseTypeHandler()
        {         
            jsonSchema = generator.Generate(typeof(BasePolicy));
            jsonSchema.Properties["DocumentDate"].Format = "string";
            jsonSchema.Properties["EffectiveDate"].Format = "string";
            jsonSchema.Properties["ExpirationDate"].Format = "string";
            jsonSchema.Properties["AcceptationDate"].Format = "string";
        }
        public override object Handle(object request)
        {
            JToken json = JToken.Parse(request.ToString());
            
            if (json.IsValid(jsonSchema, out error))
            {
                return JsonConvert.DeserializeObject<BasePolicy>(request.ToString());
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
