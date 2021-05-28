using Newtonsoft.Json;

namespace ELibrary.Dtos
{
    class ErrorDetialDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
