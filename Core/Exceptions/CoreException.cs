using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions
{
    public class CoreException : Exception
    {
        internal CoreException(string businessMessage)
               : base(businessMessage)
        {
        }
    }
}
