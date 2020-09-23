using JsonMultiConverter.Interfaces;
using Newtonsoft.Json;

namespace JsonMultiConverter.Models.JsonModels
{
    public class JsonTypeSecond : IJsonType
    {
        public string InsurerFirstName { get; set; }
        public string InsurerLastName { get; set; }
        public JsonTypeFirstVehicle Vehicle { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }

        public object Creater(string json)
        {
            return JsonConvert.DeserializeObject<JsonTypeSecond>(json);
        }
    }
}
