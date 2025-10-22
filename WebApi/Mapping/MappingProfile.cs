using System;
using AutoMapper;
using WebApi.Mapping.Resources.Employees;
using Core.Domain.Employees;
using Core.Domain.Documents;
using WebApi.Mapping.Resources.Documents;
using WebApi.Mapping.Resources.Management;
using Core.Domain.Management;

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

            CreateMap<Teacher, TeacherResource>();
            CreateMap<SaveTeacherResource, Teacher>();

            #endregion

            #region Documents

            CreateMap<Document, DocumentResource>();
            CreateMap<SaveDocumentResource, Document>();

            #endregion

            #region Management
            CreateMap<Schedule, ScheduleResource>();
            CreateMap<SaveScheduleResource, Schedule>();
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
