using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class HeartManager : IManager<DonorHeart>
    {
        List<DonorHeart> hearts = new List<DonorHeart>();

        public List<DonorHeart> GetAll()
        {
            return hearts;
        }
        public void Add(DonorHeart heart)
        {
            hearts.Add(heart);
        }
        public void Remove(DonorHeart heart)
        {
            hearts.Remove(heart);
        }
    }
}