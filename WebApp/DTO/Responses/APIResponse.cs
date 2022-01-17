namespace WebApp.DTO.Responses
{
    public class APIResponse
    {
        public APIResponse(int code, string errorMessage)
        {
            Code = code;
            ErrorMessage = errorMessage;
            Success = code == 200;
        }

        public int Code { get; }
        public string ErrorMessage { get; }    
        public bool Success { get; }

        public static APIResponse OK()
        {
            return new APIResponse(200, string.Empty);
        }

        public static APIResponse Fail(int code, string message)
        {
            return new APIResponse(code, message);
        }
    }

    public class APIResponse<T> : APIResponse
    {
        public T Data { get; }  
        public APIResponse(int code, string errorMessage, T data) : base(code, errorMessage)
        {
            Data = data;    
        }

        public static APIResponse<T> OK(T data)
        {
            return new APIResponse<T>(200, string.Empty, data); 
        }

    }
}
