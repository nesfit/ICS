<Query Kind="Expression">
  <Connection>
    <ID>54bf9502-9daf-4093-88e8-7177c129999f</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Provider>System.Data.SqlServerCe.4.0</Provider>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\DemoDB.sdf</AttachFileName>
    <Persist>true</Persist>
  </Connection>
</Query>

// Best-selling products with additional data
OrderDetails
.GroupBy(od => od.Product)
.OrderByDescending(g => g.Sum(od => od.Quantity))
.Select(g => new
{
	Product = new
	{
		g.Key.ProductName,
		g.Key.Category.CategoryName,
		g.Key.Supplier.CompanyName
	},
	TotalQuantity = g.Sum(od => od.Quantity),
	//Orders = g.Key.OrderDetails.Select(od => od.Order)
})