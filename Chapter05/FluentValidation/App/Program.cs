using System.Net.Http.Headers;

Order order = new()
{
    OrderId = default,
    CustomerName = null,
    CustomerEmail = "Hello",
    CustomerLevel = CustomerLevel.Silver,
    Total = -50,
    OrderDate = DateTime.UtcNow,
    ShipDate = new DateTime()
};

OrderValidator validator = new();
ValidationResult result = validator.Validate(order);
WriteLine($"""
{"CustomerName",-15}: {order.CustomerName}
{"CustomerEmail",-15}: {order.CustomerEmail}
{"CustomerLevel",-15}: {order.CustomerLevel}
{"OrderId",-15}: {order.OrderId}
{"OrderDate",-15}: {order.OrderDate}
{"ShipDate",-15}: {order.ShipDate}
{"Total",-15}: {order.Total}

{String.Format("{0,-15}", "IsValid")}: {result.IsValid}
"""
);
foreach (var item in result.Errors)
{
    WriteLine($"{item.Severity} from property {item.PropertyName}: {item.ErrorMessage}");
}
