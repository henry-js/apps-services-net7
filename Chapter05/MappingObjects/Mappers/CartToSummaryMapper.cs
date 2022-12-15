using Mapster;
using MapsterMapper;
using Packt.Entities;
using Packt.ViewModels;

namespace MappingObjects.Mappers;

public static class CartToSummaryMapper
{
    public static Mapper GetMapper()
    {
        var config = TypeAdapterConfig<(Cart cart, Customer customer), Summary>.NewConfig()
                    .Map(dest => dest.FullName, src => $"{src.customer.FirstName} {src.customer.LastName}")
                    .Map(dest => dest.Total, src => src.cart.Items.Sum(x => x.Quantity * x.UnitPrice));

        return new Mapper(config);
    }
}
