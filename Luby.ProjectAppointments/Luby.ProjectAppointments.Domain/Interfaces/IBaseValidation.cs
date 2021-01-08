using Luby.ProjectAppointments.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Luby.ProjectAppointments.Domain.Interfaces
{
    public interface IBaseValidation<T> where T : BaseEntity
    {
        void ValidationOnCreating(T obj);
        void ValidationOnUpdating(T obj);
        void ValidationOnRemoving(T obj);
    }
}
