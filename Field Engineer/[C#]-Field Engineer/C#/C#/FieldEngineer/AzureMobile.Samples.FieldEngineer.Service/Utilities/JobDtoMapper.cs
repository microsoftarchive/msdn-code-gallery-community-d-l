// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using AutoMapper;
using AzureMobile.Samples.FieldEngineer.Service.DataObjects;
using AzureMobile.Samples.FieldEngineer.Service.Models;

namespace AzureMobile.Samples.FieldEngineer.Service.Utilities
{
    public class JobDTOMapper
    {
        public static void CreateMapping(IConfiguration cfg)
        {
            // Apply some name changes from the entity to the DTO
            cfg.CreateMap<Job, JobDTO>()
                .ForMember(jobDTO => jobDTO.JobHistories, map => map.MapFrom(job => job.JobHistories))
                .ForMember(jobDTO => jobDTO.Equipments, map => map.MapFrom(job => job.Equipments));

            // For incoming requests, ignore the relationships
            cfg.CreateMap<JobDTO, Job>()
                .ForMember(job => job.JobHistories, map => map.Ignore())
                .ForMember(job => job.Customer, map => map.Ignore())
                .ForMember(job => job.Equipments, map => map.Ignore());

            cfg.CreateMap<Customer, CustomerDTO>();
            cfg.CreateMap<JobHistory, JobHistoryDTO>();
            cfg.CreateMap<Equipment, EquipmentDTO>();
        }
    }
}
