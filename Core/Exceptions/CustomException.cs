using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Core.Exceptions
{
    public class CustomException : Exception {
        public int Status { get; set; }
        public IDictionary<string, string[]> Errors { get; set; } = new ConcurrentDictionary<string, string[]>();
    }
}
