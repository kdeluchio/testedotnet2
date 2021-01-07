using AutoMapper;
using Luby.ProjectAppointments.Application.ViewModel.Appointment;
using Luby.ProjectAppointments.Application.ViewModel.Developer;
using Luby.ProjectAppointments.Application.ViewModel.Project;
using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.CrossCutting.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            Developer();
            Project();
            Appointment();
        }

        private void Developer()
        {
            CreateMap<Developer, DeveloperViewModel>()
                .ReverseMap();

            CreateMap<Developer, NewDeveloperViewModel>()
                .ReverseMap();
        }

        private void Project()
        {
            CreateMap<Project, ProjectViewModel>()
                .ReverseMap();

            CreateMap<Project, NewProjectViewModel>()
                .ReverseMap();

            CreateMap<LinkedDeveloper, NewLinkedDeveloperViewModel>()
                .ReverseMap();

            CreateMap<LinkedDeveloper, LinkedDeveloperViewModel>()
                .ReverseMap();
        }

        private void Appointment()
        {
            CreateMap<Appointment, AppointmentViewModel>()
                .ReverseMap();

            CreateMap<Appointment, NewAppointmentViewModel>()
                .ReverseMap();
        }
    }
}
