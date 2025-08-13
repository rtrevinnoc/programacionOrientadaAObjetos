using System;
using AutoMapper;
using WebApi.Mapping.Resources.Employees;
using Core.Domain.Employees;

namespace WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Domain to API Resource

            #region Employees

            CreateMap<Employee, EmployeeResource>();
            CreateMap<SaveEmployeeResource, Employee>();

            #endregion

            #endregion

            #region API Resource to Domain
            #region Management
            #endregion
            #endregion

            #region ExtraMapping
            #endregion
        }
    }
}
