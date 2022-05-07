using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class HarborRepository : GeneralRepository<Harbor, MyContext, int>
    {
        public HarborRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
