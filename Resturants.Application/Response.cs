using Resturants.Application.Enums;

namespace Resturants.Application
{
    public class Response
    {

        public Response()
        {
            Message = null;
            Data = null;
            ResponseCode = ResponseType.Error;
        }

        public bool? Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public ResponseType? ResponseCode { get; set; }


    }
    public class OkApiResponse<TResult> : Response
    {
        public TResult Result { get; set; }
        public OkApiResponse(TResult result)
        {
            Result = result;
        }
    }
}