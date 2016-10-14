using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQChapter2
{
  public partial class MyWidget
  {
    partial void MyWidgetStart(int count);
    partial void MyWidgetEnd(int count);

    public MyWidget()
    {
      int count = 0;
      MyWidgetStart(++count);
      Console.WriteLine("In the constructor of MyWidget.");
      MyWidgetEnd(++count);
      Console.WriteLine("count = " + count);
    }
  }
}
