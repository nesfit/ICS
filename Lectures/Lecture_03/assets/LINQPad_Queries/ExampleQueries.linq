<Query Kind="Statements">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c129999f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\DemoDB.sdf</AttachFileName>
    <Persist>true</Persist>
  </Connection>
</Query>

// Customer with the most orders
var customerWithMostOrders = Orders
    .GroupBy(o => o.CustomerID)
    .OrderByDescending(g => g.Count())
	.Select(g => new { CustomerID = g.Key, OrderCount = g.Count() })
	.FirstOrDefault();
customerWithMostOrders.Dump("Customer with the most orders");

// List of countries with the most orders
var countriesWithMostOrders = Orders
	.GroupBy(o => o.ShipCountry)
	.OrderByDescending(g => g.Count())
	.Select(g => new { Country = g.Key, OrderCount = g.Count() })
	.ToList();
countriesWithMostOrders.Dump("List of countries with the most orders");

// Best-selling products
var bestSellingProducts = OrderDetails
	.GroupBy(od => od.ProductID)
	.OrderByDescending(g => g.Sum(od => od.Quantity))
	.Select(g => new { ProductID = g.Key, TotalQuantity = g.Sum(od => od.Quantity) })
	.ToList();
bestSellingProducts.Dump("Best-selling products");

// Orders by a specific customer (e.g., Customer ID "ALFKI")
var ordersBySpecificCustomer = Orders
	.Where(o => o.CustomerID == "ALFKI")
	.ToList();
ordersBySpecificCustomer.Dump("Orders by a specific customer (CustomerID = 'ALFKI')");

// Total sales per category
var totalSalesPerCategory = OrderDetails
	.Join(Products, od => od.ProductID, p => p.ProductID, (od, p) => new { od, p })
	.Join(Categories, op => op.p.CategoryID, c => c.CategoryID, (op, c) => new { op, c })
	.GroupBy(occ => occ.c.CategoryName)
	.OrderByDescending(g => g.Sum(occ => occ.op.od.Quantity * occ.op.od.UnitPrice))
	.Select(g => new { Category = g.Key, TotalSales = g.Sum(occ => occ.op.od.Quantity * occ.op.od.UnitPrice) })
	.ToList();
totalSalesPerCategory.Dump("Total sales per category");

// Average order value per customer
var averageOrderValuePerCustomer = Orders
	.Join(OrderDetails, o => o.OrderID, od => od.OrderID, (o, od) => new { o.CustomerID, od.UnitPrice, od.Quantity })
	.GroupBy(x => x.CustomerID)
	.Select(g => new { CustomerID = g.Key, AverageOrderValue = g.Average(x => x.UnitPrice * x.Quantity) })
	.ToList();
averageOrderValuePerCustomer.Dump("Average order value per customer");

// Monthly sales trends
var monthlySalesTrends = Orders
	.GroupBy(o => new { o.OrderDate.Value.Year, o.OrderDate.Value.Month })
	.OrderBy(g => g.Key.Year).ThenBy(g => g.Key.Month)
	.Select(g => new { Year = g.Key.Year, Month = g.Key.Month, TotalSales = g.Sum(o => o.OrderDetails.Sum(od => od.UnitPrice * od.Quantity)) })
	.ToList();
monthlySalesTrends.Dump("Monthly sales trends");
