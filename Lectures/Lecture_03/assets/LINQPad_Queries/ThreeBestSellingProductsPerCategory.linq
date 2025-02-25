<Query Kind="Statements">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c129999f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\DemoDB.sdf</AttachFileName>
    <Persist>true</Persist>
  </Connection>
</Query>

var years = new List<int> { 1992, 1993 };

var bestSellingProductsPerCategory = OrderDetails
	.Join(Orders, od => od.OrderID, o => o.OrderID, (od, o) => new { od, o })
	.Join(Products, oo => oo.od.ProductID, p => p.ProductID, (oo, p) => new { oo.od, oo.o, p })
	.Join(Categories, oop => oop.p.CategoryID, c => c.CategoryID, (oop, c) => new { oop.od, oop.o, oop.p, c })
	// 1st option - specify years explicitly.
	.Where(x => x.o.OrderDate.Value.Year == 1992 || x.o.OrderDate.Value.Year == 1993)
	
	// 2nd option - using .Any() extension method - error - Local sequence cannot be used in LINQ to SQL implementations of query operators except the Contains operator.
	// Could be used when data are loaded to the memory and query is not needed to be translated to SQL.
	//.ToList()
	//.Where(x => years.Any(y => y == x.o.OrderDate.Value.Year))
	
	// 3rd option - using .Contains() extension method.
	//.Where(x => years.Contains(x.o.OrderDate.Value.Year))
	.GroupBy(x => new { x.c.CategoryName, x.p.ProductName })
	.Select(g => new { g.Key.CategoryName, g.Key.ProductName, TotalQuantity = g.Sum(x => x.od.Quantity) })
	.OrderBy(g => g.CategoryName)
	.ThenByDescending(x => x.TotalQuantity)
	.GroupBy(x => x.CategoryName)
	.SelectMany(g => g.Take(3))
	.ToList();

bestSellingProductsPerCategory.Dump("3 Best-Selling Products Per Category for Years 1992 and 1993");