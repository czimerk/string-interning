using System;
using System.Collections.Generic;
using System.Text;

namespace StringInterning
{
    class Hello
    {
        public const string HelloTxt = "Hello";

        public string getHello() {
            var t = "Hello";
            string.Intern(t);
            return t;
        }
    }
}
