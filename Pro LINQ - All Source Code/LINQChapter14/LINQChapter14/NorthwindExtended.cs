using System;
using System.Data.Linq;

namespace nwind
{
  public partial class Northwind : DataContext
  {
    partial void InsertShipper(Shipper instance)
    {
      Console.WriteLine("Insert override method was called for shipper {0}.",
        instance.CompanyName);
      //this.ExecuteDynamicInsert(instance);
    }

    partial void UpdateShipper(Shipper instance)
    {
      Console.WriteLine("Update override method was called for shipper {0}.",
        instance.CompanyName);
      //this.ExecuteDynamicUpdate(instance);
    }

    partial void DeleteShipper(Shipper instance)
    {
      Console.WriteLine("Delete override method was called for shipper {0}.",
        instance.CompanyName);
      //this.ExecuteDynamicDelete(instance);
    }
  }
}
