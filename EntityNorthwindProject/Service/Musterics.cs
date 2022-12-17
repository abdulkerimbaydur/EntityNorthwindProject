using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNorthwindProject.Service
{
    public class Musterics
    {
        public static void Insert(MUSTERILER musteriler)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            Entities.MUSTERILER.Add(musteriler);
            Entities.SaveChanges();
        }



        public static void Update(MUSTERILER musteriler)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniMusteri = Entities.MUSTERILER.Where(x => x.ID == musteriler.ID).FirstOrDefault();
            if (YeniMusteri != null)
            {
                YeniMusteri.MUSTERI_AD = musteriler.MUSTERI_AD;
                YeniMusteri.YETKILI = musteriler.YETKILI;
                YeniMusteri.ADRES = musteriler.ADRES;
                YeniMusteri.SEHIR = musteriler.SEHIR;
                YeniMusteri.ULKE = musteriler.ULKE;
                Entities.SaveChanges();

            }
        }

        public static void SIL(MUSTERILER musteriler)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniMusteri = Entities.MUSTERILER.Where(x => x.ID == musteriler.ID).FirstOrDefault();
            if (YeniMusteri != null)
            {
                YeniMusteri.IS_FLAG = 0;
                Entities.SaveChanges();
            }
            //Entities.PERSONELLER.Remove(personelcs);
            //Entities.SaveChanges();
        }

        public static List<View_Musteriler> LISTELE()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Musteriler> MUSTERI_LIST = Entities.View_Musteriler.ToList();
            return MUSTERI_LIST;
        }

        public static List<View_Musteriler> LISTELEPER()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Musteriler> MUSTERI_LIST = Entities.View_Musteriler.ToList();
            return MUSTERI_LIST;
        }

    }
}
