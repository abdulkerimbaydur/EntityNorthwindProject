using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNorthwindProject.Service
{
    public class Uruncs
    {
        public static void Insert(URUNLER Urun)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            Entities.URUNLER.Add(Urun);
            Entities.SaveChanges();
        }



        public static void Update(URUNLER Urun)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniUrun= Entities.URUNLER.Where(x => x.ID == Urun.ID).FirstOrDefault();
            if (YeniUrun != null)
            {
                YeniUrun.ID = Urun.ID;
                YeniUrun.AD = Urun.AD;
                YeniUrun.TEDARIKCID = Urun.TEDARIKCID;
                YeniUrun.KATEGORID = Urun.KATEGORID;
                YeniUrun.FIYAT = Urun.FIYAT;
                YeniUrun.STOK = Urun.STOK;
               
                Entities.SaveChanges();

            }
        }

        public static void SIL(URUNLER Urun)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniUrun = Entities.URUNLER.Where(x => x.ID == Urun.ID).FirstOrDefault();
            if (YeniUrun != null)
            {
                YeniUrun.IS_FLAG = 0;
                Entities.SaveChanges();
            }
            //Entities.PERSONELLER.Remove(personelcs);
            //Entities.SaveChanges();
        }

        public static List<View_Urunler_List> LISTELE()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Urunler_List> URUNLER_LIST = Entities.View_Urunler_List.ToList();
            return URUNLER_LIST;
        }

        public static List<View_Urunler_List> LISTELEURUN()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_Urunler_List> URUNLER_LIST = Entities.View_Urunler_List.ToList();
            return URUNLER_LIST;
        }
        public static string FIYAT_GETIR(URUNLER Urun)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniUrun = Entities.URUNLER.Where(x => x.ID == Urun.ID).FirstOrDefault();
            return YeniUrun.FIYAT.ToString();
        }
        public static string STOK_GETIR(URUNLER Urun)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniUrun = Entities.URUNLER.Where(x => x.ID == Urun.ID).FirstOrDefault();
            return YeniUrun.STOK.ToString();
        }
    }
}
