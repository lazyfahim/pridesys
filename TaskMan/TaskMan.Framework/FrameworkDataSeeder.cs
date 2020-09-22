
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskMan.Data;

namespace TaskMan.Framework
{
    public class FrameworkDataSeeder : DataSeeder
    {
        public FrameworkDataSeeder(FrameworkContext context) : base(context)
        {

        }

        public override Task SeedAsync()
        {
            throw new NotImplementedException();
        }
    }

}
