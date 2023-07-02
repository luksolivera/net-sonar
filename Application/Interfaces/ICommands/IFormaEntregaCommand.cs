﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.ICommands
{
    public interface IFormaEntregaCommand
    {
        //Task Create();
        Task Insert(FormaEntrega formaEntrega);
        Task Update(FormaEntrega formaEntrega);
        Task Delete(int id);
    }
}
