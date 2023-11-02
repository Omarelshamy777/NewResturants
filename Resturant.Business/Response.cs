namespace Resturant.Business
{
    public class Response
    { 
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
      

    }
    public  class okApiResponse<TResult> : Response
    {
        public TResult Result { get; set; }
        public okApiResponse(TResult result) 
        {
            Result = result;
        }
    }
}