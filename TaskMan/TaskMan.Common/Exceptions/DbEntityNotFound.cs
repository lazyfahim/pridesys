using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Common.Exceptions
{
    public class DbEntityNotFound : Exception
    {
        public string EntityName { get; private set; }

        public DbEntityNotFound(string message, string entityName)
            : base(message)
        {
            EntityName = entityName;
        }
    }
}
