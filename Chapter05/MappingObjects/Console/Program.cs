using MappingObjects.Mappers;
using Mapster;
using MapsterMapper;
using Packt.Entities;
using Packt.ViewModels;

Cart cart = new(
    Customer: new(
        FirstName: "John",
        LastName: "Smith"
    ),
    Items: new()
    {
        new(ProductName: "Apples", UnitPrice: 0.49M, Quantity: 10),
        new(ProductName: "Bananas", UnitPrice: 0.99M, Quantity: 4)
    });

WriteLine($"{cart.Customer}");
foreach (var item in cart.Items)
{
    WriteLine($"    {item}");
}

var config = CartToSummaryMapper.GetMapsterConfiguration();

var mapper = new Mapper(config);
var summary = mapper.Map<Summary>(cart);
WriteLine($"Summary: {summary.FullName} spent {summary.Total}");
