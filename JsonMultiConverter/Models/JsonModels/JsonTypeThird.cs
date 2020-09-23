using JsonMultiConverter.Interfaces;

namespace JsonMultiConverter.Models.JsonModels
{
    public class JsonTypeThird : IJsonType
    {
        public JsonTypeThirdInsurer Insurer { get; set; }
        public string VehicleMark { get; set; }
        public string VehicleModel { get; set; }
        public string DateBegin { get; set; }
        public string DateEnd { get; set; }
    }
}
