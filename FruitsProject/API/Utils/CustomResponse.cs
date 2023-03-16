using System;

namespace API.Utils
{
    public class CustomResponse
    {
        public int Status { get; private set; }
        public string Msg { get; private set; }
        public DateTime Date { get; private set; }

        public sealed class Builder
        {
            private int _statusCode = 200;
            private string _msg = string.Empty;
            public Builder(int statusCode, string msg = "") 
            {
                _statusCode = statusCode;
                _msg = msg;
            }
            public static Builder Ok(string customMessage = "Ok") => new Builder(200, customMessage);
            public static Builder NotFound(string customMessage = "Resource not found") => new Builder(404, customMessage);
            public static Builder ValidationCriteriaNotMet(string customMessage = "Validation criteria was not met") => new Builder(400, customMessage);
            public CustomResponse Build()
            {
                return new CustomResponse()
                {
                    Date = DateTime.Now,
                    Status = _statusCode,
                    Msg = _msg
                };
            }
        }
    }
}
