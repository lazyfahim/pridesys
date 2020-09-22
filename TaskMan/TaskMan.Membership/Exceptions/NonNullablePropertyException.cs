using System;
using System.Collections.Generic;
using System.Text;

namespace TaskMan.Membership.Exceptions
{
    public class NonNullablePropertyException :Exception
    {
        public Type EntitType { get; set; }

    }
}
