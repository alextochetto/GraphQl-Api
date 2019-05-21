using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using RealEstateManager.DataAccess.Respositories.Contracts;
using RealEstateManager.Database.Models;
using RealEstateManager.Types;
using RealEstateManager.Types.Property;

namespace GraphQl.Api.Mutations
{
    public class PropertyMutation : ObjectGraphType
    {
        public PropertyMutation(IPropertyRepository propertyRepository)
        {
            Name = "AddPropertyMutation";

            Field<PropertyType>(
                "addProperty",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "property" }),
                resolve: context =>
                {
                    var property = context.GetArgument<Property>("property");
                    return propertyRepository.Add(property);
                });
        }
    }
}