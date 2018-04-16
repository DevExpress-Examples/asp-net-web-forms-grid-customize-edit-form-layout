using System;
using System.Collections.Generic;
using System.Linq;
namespace CustomExceptions {
    public class MyException : Exception {
        public MyException(string message)
            : base(message) {
        }
    }
}