using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNorthwindProject.Service
{
    public class Tedarikcics
    {
        public static void Insert(TEDARIKCILER tedarici)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            Entities.TEDARIKCILER.Add(tedarici);
            Entities.SaveChanges();
        }



        public static void Update(TEDARIKCILER tedarici)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniTedarikci = Entities.TEDARIKCILER.Where(x => x.ID == tedarici.ID).FirstOrDefault();
            if (YeniTedarikci != null)
            {
                YeniTedarikci.AD = tedarici.AD;
                YeniTedarikci.YETKILI = tedarici.YETKILI;
                YeniTedarikci.ADRES = tedarici.ADRES;
                YeniTedarikci.SEHIR = tedarici.SEHIR;
                YeniTedarikci.ULKE = tedarici.ULKE;
                Entities.SaveChanges();

            }
        }

        public static void SIL(TEDARIKCILER tedarici)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniTedarikci = Entities.TEDARIKCILER.Where(x => x.ID == tedarici.ID).FirstOrDefault();
            if (YeniTedarikci != null)
            {
                YeniTedarikci.IS_FLAG = 0;
                Entities.SaveChanges();
            }
            //Entities.PERSONELLER.Remove(personelcs);
            //Entities.SaveChanges();
        }

        public static List<View_Tedarikci_List> LISTELE()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Tedarikci_List> TEDARIKCI_LIST = Entities.View_Tedarikci_List.ToList();
            return TEDARIKCI_LIST;
        }

        public static List<View_Tedarikci_List> LISTELE_COM()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Tedarikci_List> TEDARIKCI_LIST = Entities.View_Tedarikci_List.ToList();
            return TEDARIKCI_LIST;
        }



    }
}
