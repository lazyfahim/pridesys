using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Common.Exceptions
{
    public class IdCannotBeZeroOrNegativeException : Exception
    {
        public string EntityName { get; private set; }

        public IdCannotBeZeroOrNegativeException(string message, string entityName)
            : base(message)
        {
            EntityName = entityName;
        }
    }
}
