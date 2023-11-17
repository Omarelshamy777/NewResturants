using Resturants.Application.Enums;

namespace Resturants.Application
{
    public class Response<TResult>
    {

        public Response()
        {
            Message = null;
            Data = default;
            ResponseCode = ResponseType.Error;
        }

        public bool? Success { get; set; }
        public string? Message { get; set; }
        public TResult? Data { get; set; }
        public ResponseType? ResponseCode { get; set; }


    }

    public class Response  : Response<Object>
    {

    }
    public class OkApiResponse<TResult> : Response<TResult>
    {
        public OkApiResponse(TResult result)
        {
            Data = result;
        }
    }
}