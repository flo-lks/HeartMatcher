using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public interface IMatch
    {
        Patient Patient { get; set; }
        Heart Heart { get; set; }
    }
}