using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;

namespace LINQChapter18
{
  public partial class TestDB : DataContext
  {
    public Table<Shape> Shapes;

    public TestDB(string connection) :
      base(connection)
    {
    }

    public TestDB(System.Data.IDbConnection connection) :
      base(connection)
    {
    }

    public TestDB(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
      base(connection, mappingSource)
    {
    }

    public TestDB(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) :
      base(connection, mappingSource)
    {
    }
  }

  [Table]
  [InheritanceMapping(Code = "G", Type = typeof(Shape), IsDefault = true)]
  [InheritanceMapping(Code = "S", Type = typeof(Square))]
  [InheritanceMapping(Code = "R", Type = typeof(Rectangle))]
  public class Shape
  {
    [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "Int NOT NULL IDENTITY")]
    public int Id;

    [Column(IsDiscriminator = true, DbType = "NVarChar(2)")]
    public string ShapeCode;

    [Column(DbType = "Int")]
    public int StartingX;

    [Column(DbType = "Int")]
    public int StartingY;
  }

  public class Square : Shape
  {
    [Column(DbType = "Int")]
    public int Width;
  }

  public class Rectangle : Square
  {
    [Column(DbType = "Int")]
    public int Length;
  }
}
