using RealEstateManager.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstateManager.DataAccess.Respositories.Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllByProperty(int propertyId);
        IEnumerable<Payment> GetAllByProperty(int propertyId, int lastAmount);
    }
}