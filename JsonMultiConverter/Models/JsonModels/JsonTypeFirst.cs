using JsonMultiConverter.Interfaces;
using Newtonsoft.Json;

namespace JsonMultiConverter.Models.JsonModels
{
    public class JsonTypeFirst : IJsonType
    {
        public JsonTypeFirstInsurer Insurer { get; set; }
        public JsonTypeFirstVehicle Vehicle { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
        public object Creater(string json)
        {
            return JsonConvert.DeserializeObject<JsonTypeFirst>(json);
        }
    }
}
