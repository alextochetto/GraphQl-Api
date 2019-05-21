using RealEstateManager.DataAccess.Respositories.Contracts;
using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateManager.DataAccess.Respositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateContext _dbContext;
        public PropertyRepository(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Property> GetAll()
        {
            return _dbContext.Properties;
        }

        public Property GetById(int id)
        {
            return _dbContext.Properties.SingleOrDefault(_ => _.Id == id);
        }

        public Property Add(Property property)
        {
            _dbContext.Properties.Add(property);
            _dbContext.SaveChanges();
            return property;
        }
    }
}
