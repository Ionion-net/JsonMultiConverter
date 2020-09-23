using JsonMultiConverter.Interfaces;

namespace JsonMultiConverter.Models.JsonModels
{
    public class JsonTypeFirst : IJsonType
    {
        public JsonTypeFirstInsurer Insurer { get; set; }
        public JsonTypeFirstVehicle Vehicle { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
    }
}
