using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Common.Exceptions
{
    public class ExcelFileGenerationErrorException : Exception
    {
        public string EntityName { get; private set; }

        public ExcelFileGenerationErrorException(string message, string entityName)
            : base(message)
        {
            EntityName = entityName;
        }
    }
}
