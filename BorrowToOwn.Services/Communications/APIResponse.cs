using System;
using System.Collections.Generic;

namespace BorrowToOwn.Services.Communications
{
    public class APIResponse<T>
    {
        public APIResponse()
        {
            IsSuccessful = false;
            Errors = new List<string>();
        }
        public bool IsSuccessful { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
