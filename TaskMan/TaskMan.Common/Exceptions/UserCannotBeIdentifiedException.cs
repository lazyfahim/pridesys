using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Common.Exceptions
{
    public class UserCannotBeIdentifiedException : Exception
    {
        public string EntityName { get; private set; }

        public UserCannotBeIdentifiedException(string message, string entityName)
            : base(message)
        {
            EntityName = entityName;
        }
    }
}
