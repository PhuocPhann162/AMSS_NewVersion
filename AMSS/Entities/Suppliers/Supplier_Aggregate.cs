﻿using AMSS.Aggregates;
using AMSS.Dto.Auth;
using AMSS.Dto.Requests.Suppliers;

namespace AMSS.Models.Suppliers
{
    public partial class Supplier : IAggregateRoot
    {
        public Supplier()
        {
            
        }

        public Supplier(RegistrationRequestDto request) 
        {
            Id = Guid.NewGuid();
            Name = request.CompanyName.Trim();
            ContactName = request.ContactName.Trim();
            CountryCode = request.Country;
            ProvinceCode = request.ProvinceCode;
            PhoneCode = request.PhoneCode;
            PhoneNumber = request.PhoneNumber;
            Address = request.StreetAddress.Trim();
            Email = request.UserName.Trim();
            SupplierRole = request.Role;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public Supplier(CreateSupplierRequest request)
        {
            Id = Guid.NewGuid();
            Name = request.Name.Trim();
            ContactName = request.ContactName.Trim();
            PhoneCode = request.PhoneCode.Trim();
            PhoneNumber = request.PhoneNumber.Trim();
            Email = request.Email.Trim();
            Address = request.Address.Trim();
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }

        public void Update(UpdateSupplierRequest request)
        {
            Name = request.Name.Trim(); 
            ContactName = request.ContactName.Trim();
            PhoneCode = request.PhoneCode.Trim();
            PhoneNumber = request.PhoneNumber.Trim();
            Email = request.Email.Trim();
            Address = request.Address.Trim();
            PhoneCode = request.PhoneCode;
            PhoneNumber = request.PhoneNumber.Trim();
            UpdatedAt = DateTime.Now;
        }
    }
}
