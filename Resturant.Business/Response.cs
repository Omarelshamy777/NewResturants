using NewResturants.Enums;

namespace Resturant.Business
{
    public class Response
    {

        public Response()
        {
            Message = null;
            Data = null;
            ResponseCode = ResponseTypeEnum.Error;
        }

        public bool? Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public ResponseTypeEnum? ResponseCode { get; set; }


    }
    public class okApiResponse<TResult> : Response
    {
        public TResult Result { get; set; }
        public okApiResponse(TResult result)
        {
            Result = result;
        }
    }
}