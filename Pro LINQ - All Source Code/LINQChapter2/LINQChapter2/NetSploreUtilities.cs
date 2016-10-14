using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Netsplore.Utilities
{
  public static class StringConversions
  {
    public static double ToDouble(this string s)
    {
      return Double.Parse(s);
    }

    public static bool ToBool(this string s)
    {
      return Boolean.Parse(s);
    }
  }
}
