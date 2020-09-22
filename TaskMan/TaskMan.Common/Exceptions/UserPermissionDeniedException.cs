using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Common.Exceptions
{
    /// <summary>
    /// Used for cases where a user tries to access resources of another user
    /// </summary>
    public class UserPermissionDeniedException : Exception
    {
        public string EntityName { get; private set; }

        public UserPermissionDeniedException(string message, string entityName)
            : base(message)
        {
            EntityName = entityName;
        }
    }
}
