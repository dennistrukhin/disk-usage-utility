using System.Text.Json.Serialization;

namespace DiskUsageUtility.Web.Dto
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        
        [JsonIgnore]
        public ErrorDto Error { get; set; }

        public static ResponseDto<T> FromDto(T dto)
        {
            return new ResponseDto<T>
            {
                Data = dto,
            };
        }
    }
}