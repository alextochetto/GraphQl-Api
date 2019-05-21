using GraphQL.Types;
using RealEstateManager.DataAccess.Respositories.Contracts;
using RealEstateManager.Database.Models;
using System;

namespace RealEstateManager.Types
{
    public class PropertyType : ObjectGraphType<Database.Models.Property>
    {
        public PropertyType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Family);
            Field(x => x.Street);
            Field<ListGraphType<PaymentType>>("payments",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "last" }),
                resolve: context =>
                {
                    var lastItemsFilter = context.GetArgument<int?>("last");
                    return lastItemsFilter != null
                        ? paymentRepository.GetAllByProperty(context.Source.Id, lastItemsFilter.Value)
                        : paymentRepository.GetAllByProperty(context.Source.Id);
                });
        }
    }
}
