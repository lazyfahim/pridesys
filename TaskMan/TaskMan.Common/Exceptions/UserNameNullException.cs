using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Common.Exceptions
{
    public class UserNameNullException:Exception
    {

        public UserNameNullException(string message)
            : base(message)
        {
        }
    }
}
