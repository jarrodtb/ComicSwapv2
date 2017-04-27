using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicSwapv2.Logic
{
    public class Comparator
    {
        public static bool GreaterThan(int a, int b)
        {
            if (a > b)
                return true;
            else
                return false;
        }
    }
}