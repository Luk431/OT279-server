﻿using OngProject.Core.Models.DTOs.OrganizationDTO;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Mapper
{
    public class OrganizationMapper
    {
        public GetOrganizationDto OrganizationToGetOrganizationDTO(Organization organization)
        {
            GetOrganizationDto getOrganizationDto = new()
            {
                Name = organization.Name,
                Image = organization.Image,
                Phone = organization.Phone,
                Address = organization.Address,
                FacebookUrl = organization.FacebookUrl,
                InstagramUrl = organization.InstagramUrl,
                LinkedinUrl = organization.LinkedinUrl
            };
            return getOrganizationDto;
        }


    }
}
