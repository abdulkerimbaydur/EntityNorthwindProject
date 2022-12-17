using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNorthwindProject.Service
{
    public class Sipariscs
    {
        public static void Insert(SIPARIS siparis)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            Entities.SIPARIS.Add(siparis);
            Entities.SaveChanges();
        }



        public static void Update(SIPARIS siparis)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniSiparis = Entities.SIPARIS.Where(x => x.ID == siparis.ID).FirstOrDefault();
            if (YeniSiparis != null)
            {
                YeniSiparis.MUSTERI_ID = siparis.MUSTERI_ID;
                YeniSiparis.PERSONEL_ID = siparis.PERSONEL_ID;
               

                Entities.SaveChanges(); //

            }
        }

        public static void SIL(SIPARIS siparis)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniSiparis = Entities.SIPARIS.Where(x => x.ID == siparis.ID).FirstOrDefault();
            if (YeniSiparis != null)
            {
                YeniSiparis.IS_FLAG = 0;
                Entities.SaveChanges();
            }
            //Entities.PERSONELLER.Remove(personelcs);
            //Entities.SaveChanges();
        }
        public static List<View_SIPARIS_LIST> LISTELE()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_SIPARIS_LIST> SIPARIS_LIST = Entities.View_SIPARIS_LIST.ToList();
            return SIPARIS_LIST;
        }

        public static List<View_SIPARIS_LIST> LISTELESIPP()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_SIPARIS_LIST> SIPARIS_LIST = Entities.View_SIPARIS_LIST.ToList();
            return SIPARIS_LIST;

        }
    }
}
