using App.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Interfaces
{
    public interface IHospede
    {
        void Cria();
        void Altera();
        void Deleta();
        IList<Hospede> Lista();
        void GetHospede(int id);

    }
}
