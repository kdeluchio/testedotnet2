using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Interfaces
{
    public interface IAppointmentValidation : IBaseValidation<Appointment>
    {
    }
}
