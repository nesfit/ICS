<Query Kind="Expression" />

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