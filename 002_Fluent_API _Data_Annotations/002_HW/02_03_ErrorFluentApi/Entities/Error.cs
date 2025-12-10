using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorFluentApi.Entities
{
    internal class Error
    {
        public string Message { get; set; } = string.Empty;
        public DateTime Time { get; set; }
        public string Request { get; set; } = string.Empty;
        public StatusCode Status { get; set; }
    }
}
