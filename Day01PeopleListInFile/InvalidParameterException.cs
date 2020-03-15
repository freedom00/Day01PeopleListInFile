using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day01PeopleListInFile
{
    internal class InvalidParameterException : Exception
    {
        public InvalidParameterException(string msg) : base(msg)
        {
        }
    }
}