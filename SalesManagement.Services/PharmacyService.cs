using SalesManagement.Core.Interfaces;
using SalesManagement.Core.Models;
using SalesManagement.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement.Services
{
    public class PharmacyService:IPharmacyService
    {
        public IUnitOfWork _unitOfWork;

        public PharmacyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreatePharmacy(Pharmacy pharmacy)
        {
            if (pharmacy != null)
            {
                await _unitOfWork.Pharmacies.Add(pharmacy);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeletePharmacy(int pharmacyId)
        {
            if (pharmacyId > 0)
            {
                var pharmacy = await _unitOfWork.Pharmacies.GetById(pharmacyId);
                if (pharmacy != null)
                {
                    _unitOfWork.Pharmacies.Delete(pharmacy);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Pharmacy>> GetAllPharmacys()
        {
            var pharmacyList = await _unitOfWork.Pharmacies.GetAll();
            return pharmacyList;
        }

        public async Task<Pharmacy> GetPharmacyById(int pharmacyId)
        {
            if (pharmacyId > 0)
            {
                var pharmacy = await _unitOfWork.Pharmacies.GetById(pharmacyId);
                if (pharmacy != null)
                {
                    return pharmacy;
                }
            }
            return null;
        }

        public async Task<bool> UpdatePharmacy(Pharmacy pharmacy)
        {
            if (pharmacy != null)
            {
                var pharmacyFind = await _unitOfWork.Pharmacies.GetById(pharmacy.PharmacyId);
                if (pharmacyFind != null)
                {
                    pharmacyFind.PharmacyName = pharmacy.PharmacyName;
                    pharmacyFind.State = pharmacy.State;
                    pharmacyFind.Address = pharmacy.Address;
                    pharmacyFind.PhoneNumber = pharmacy .PhoneNumber;
                    pharmacyFind.EmailAddress = pharmacy.EmailAddress;
                    pharmacyFind.City = pharmacy.City;
                    pharmacyFind.Country = pharmacy.Country;
                    pharmacyFind.PostalCode = pharmacy.PostalCode;


                    _unitOfWork.Pharmacies.Update(pharmacyFind);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
