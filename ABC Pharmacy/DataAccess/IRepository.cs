using ABC_Pharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Pharmacy.DataAccess
{
    public interface IRepository
    {
        List<Medicine> GetAll();

        bool Add(Medicine medicine);

        bool Update(Medicine medicine);

    }
}
