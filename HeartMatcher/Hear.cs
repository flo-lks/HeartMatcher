using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class Heart : IHeart
    {
        public int Id { get; set; }
        public int Bloodtype { get; set; }

        public Heart(int id, int bloodtype)
        {
            this.Id = id;
            this.Bloodtype = bloodtype;
        }
    }
}