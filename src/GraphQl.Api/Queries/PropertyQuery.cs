﻿using GraphQL.Types;
using RealEstateManager.DataAccess.Respositories.Contracts;
using RealEstateManager.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>("properties", resolve: context => propertyRepository.GetAll());

            Field<PropertyType>(
                "property",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context => propertyRepository.GetById(context.GetArgument<int>("id")));
        }
    }
}