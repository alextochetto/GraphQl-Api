using RealEstateManager.DataAccess.Respositories.Contracts;
using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateManager.DataAccess.Respositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly RealEstateContext _dbContext;
        public PaymentRepository(RealEstateContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Payment> GetAllByProperty(int propertyId)
        {
            return _dbContext.Payments.Where(x => x.PropertyId == propertyId);
        }

        public IEnumerable<Payment> GetAllByProperty(int propertyId, int lastAmount)
        {
            return _dbContext.Payments.Where(x => x.PropertyId == propertyId).OrderByDescending(_ => _.DateCreated).Take(lastAmount);
        }
    }
}
