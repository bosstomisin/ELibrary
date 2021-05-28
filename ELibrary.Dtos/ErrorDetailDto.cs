using Newtonsoft.Json;

namespace ELibrary.Dtos
{
    public class ErrorDetailDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
