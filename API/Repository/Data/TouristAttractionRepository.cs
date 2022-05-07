﻿using API.Context;
using API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Data
{
    public class TouristAttractionRepository : GeneralRepository<TouristAttraction, MyContext, int>
    {
        public TouristAttractionRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}
