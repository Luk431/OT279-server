﻿using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IOrganizationsService
    {
        public Task<List<Organization>> GetAllOrganization();

        public Task<Organization> GetByIdOrganization(int id);

        public Task<Organization> InsertOrganization(Organization organization);

        public Task<Organization> UpdateOrganization(int id, Organization organization);

        public Task<bool> DeleteOrganization(int id);
    }
}
