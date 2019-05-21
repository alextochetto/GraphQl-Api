using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.Types.Property
{
    public class PropertyInputType : InputObjectGraphType
    {
        public PropertyInputType()
        {
            //Name = "PropertyInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("city");
            Field<StringGraphType>("family");
            Field<StringGraphType>("street");
            Field<IntGraphType>("value");
        }
    }
}