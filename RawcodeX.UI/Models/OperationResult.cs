using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RawcodeX.UI.Models
{
    public class OperationResult
    {
        public OperationResult()
        {
            Messages = new List<string>();
        }

        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public bool HasPartialError { get; set; }
        public List<string> Messages { get; set; }
    }
}