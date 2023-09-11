namespace emp_handler_api_v2.EmpHandler.Application
{
    public class BaseResponse<T>
    {
        public BaseResponse(string? error = null,
                            string? errorCode = null,
                            string? resultStatus = null,
                            string? httpStatus = null,
                            string? httpCode = null)
        {
            this.error = error;
            this.errorCode = errorCode;
            this.resultStatus = resultStatus;
            this.httpStatus = httpStatus;
            this.httpCode = httpCode;
        }

        public string? error { get; set; }
        public string? errorCode { get; set; }
        public string? resultStatus { get; set; }
        public dynamic? httpStatus { get; set; }
        public dynamic? httpCode { get; set; }
        public T data { get; set; }
    }
}
