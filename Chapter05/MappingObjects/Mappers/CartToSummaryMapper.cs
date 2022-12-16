using Mapster;
using MapsterMapper;
using Packt.Entities;
using Packt.ViewModels;

namespace MappingObjects.Mappers;

public static class CartToSummaryMapper
{
    public static TypeAdapterConfig GetMapsterConfiguration()
    {
        TypeAdapterConfig.GlobalSettings.RequireExplicitMapping = true;
        var config = new TypeAdapterConfig();
        config.NewConfig<Cart, Summary>()
                    .Map(dest => dest.FullName, src => $"{src.Customer.FirstName} {src.Customer.LastName}")
                    .Map(dest => dest.Total, src => src.Items.Sum(x => x.Quantity * x.UnitPrice));
        return config;
    }
}
