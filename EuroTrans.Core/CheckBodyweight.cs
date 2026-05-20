using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class CheckBodyweight
    {
        public static bool IsCompatible(double recipientWeight, double donorWeight)
        {
            return donorWeight >= recipientWeight * 0.8 && donorWeight <= recipientWeight * 1.2;
        }
    }
}