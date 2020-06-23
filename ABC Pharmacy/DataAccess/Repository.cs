using ABC_Pharmacy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ABC_Pharmacy.DataAccess
{
    public class Repository : IRepository
    {
        public bool Add(Medicine medicine)
        {
            List<Medicine> medicineList = LoadMedicineData();
            if (medicineList != null)
            {
                medicine.Id = Guid.NewGuid();
                medicineList.Add(medicine);
            }
            string medicineListjson = JsonConvert.SerializeObject(medicineList.ToArray());

            //write string to file
            System.IO.File.WriteAllText("DB/Medicine.json", medicineListjson);
            return true;
        }

        public List<Medicine> GetAll()
        {
            List<Medicine> medicineList = LoadMedicineData();
            return medicineList;
        }

        public bool Update(Medicine medicine)
        {
            List<Medicine> medicineList = LoadMedicineData();
            foreach (var meddata in medicineList)
            {
                if (meddata.Id == medicine.Id)
                {
                    meddata.FullName = medicine.FullName;
                    meddata.Brand = medicine.Brand;
                    meddata.ExpiryDate = medicine.ExpiryDate;
                    meddata.Price = medicine.Price;
                    meddata.Quantity = medicine.Quantity;
                    meddata.Notes = medicine.Notes;
                }
            }
            string medicineListjson = JsonConvert.SerializeObject(medicineList.ToArray());

            //write string to file
            System.IO.File.WriteAllText("DB/Medicine.json", medicineListjson);
            return true;
        }

        private List<Medicine> LoadMedicineData()
        {
            List<Medicine> items = new List<Medicine>();
            using (StreamReader r = new StreamReader("DB/Medicine.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Medicine>>(json);
            }
            return items;
        }
    }
}
