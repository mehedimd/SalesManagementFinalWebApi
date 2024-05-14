using SalesManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services.Interfaces
{
    public interface IPharmacyService
    {
        Task<bool> CreatePharmacy(Pharmacy pharmacy);

        Task<IEnumerable<Pharmacy>> GetAllPharmacys();

        Task<Pharmacy> GetPharmacyById(int pharmacyId);

        Task<bool> UpdatePharmacy(Pharmacy pharmacy);

        Task<bool> DeletePharmacy(int pharmacyId);
    }
}
