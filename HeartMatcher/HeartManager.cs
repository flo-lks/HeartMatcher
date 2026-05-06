using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class HeartManager : IManager<Heart>
    {
        List<Heart> hearts = new List<Heart>();

        public List<Heart> GetAll()
        {
            return hearts;
        }
        public void Add(Heart heart)
        {
            hearts.Add(heart);
        }
        public void Remove(Heart heart)
        {
            hearts.Remove(heart);
        }
    }
}