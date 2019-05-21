using GraphQl.Api.Mutations;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQl.Api.Queries.Schema
{
    public class RealEstateSchema : GraphQL.Types.Schema
    {
        public RealEstateSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
            Mutation = resolver.Resolve<PropertyMutation>();
        }
    }
}