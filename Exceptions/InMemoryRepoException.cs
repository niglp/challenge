using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiccarCodeTest.Exceptions
{
    public class InMemoryRepoException : Exception
    {
        public InMemoryRepoException(string message) : base(message) { }
    }
}
