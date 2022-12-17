
using EntityNorthwindProject.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNorthwindProject.Service
{
    public class Kategorics
    {
        public static void Insert(Kategoriler kategoriler)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            Entities.Kategoriler.Add(kategoriler);
            Entities.SaveChanges();
        }



        public static void Update(Kategoriler kategoriler)
        {
            
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniKategori = Entities.Kategoriler.Where(x => x.ID == kategoriler.ID).FirstOrDefault();
            if (YeniKategori != null)
            {
                YeniKategori.AD = kategoriler.AD;
                Entities.SaveChanges();

            }
        }
    


        public static void SIL(Kategoriler kategoriler)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniKategori = Entities.Kategoriler.Where(x => x.ID == kategoriler.ID).FirstOrDefault();
            if (YeniKategori != null)
            {
                YeniKategori.IS_FLAG = 0;
                Entities.SaveChanges();
            }
            //Entities.PERSONELLER.Remove(personelcs);
            //Entities.SaveChanges();
        }

        public static List<View_Kategoriler> LISTELE()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Kategoriler> KATEGORI_LIST = Entities.View_Kategoriler.ToList();
            return KATEGORI_LIST;
        }

        public static List<View_Kategoriler> LISTELE_COM()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Kategoriler> KATEGORI_LIST = Entities.View_Kategoriler.ToList();
            return KATEGORI_LIST;
        }
    }
}
