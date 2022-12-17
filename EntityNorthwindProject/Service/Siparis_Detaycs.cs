using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNorthwindProject.Service
{
    class Siparis_Detaycs
    {
        public static void Insert(List<SIPARIS_DETAY> SiparisDetayList)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            foreach (SIPARIS_DETAY item in SiparisDetayList)
            {
                Entities.SIPARIS_DETAY.Add(item);
            }
       
            Entities.SaveChanges();
        }



        public static void Update(SIPARIS_DETAY SipDetay)

        {

            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniSipDetay = Entities.SIPARIS_DETAY.Where(x => x.ID == SipDetay.ID).FirstOrDefault();
            if (YeniSipDetay != null)
            {
                YeniSipDetay.SIPARIS_ID = SipDetay.SIPARIS_ID;
                YeniSipDetay.URUN_ID = SipDetay.URUN_ID;
                YeniSipDetay.FIYAT = SipDetay.FIYAT;
                YeniSipDetay.ADET = SipDetay.ADET;

                Entities.SaveChanges();

            }
        }



        public static void SIL(SIPARIS_DETAY SipDetay)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniSipDetay = Entities.SIPARIS_DETAY.Where(x => x.ID == SipDetay.ID).FirstOrDefault();
            if (YeniSipDetay != null)
            {
                YeniSipDetay.IS_FLAG = 0;
                Entities.SaveChanges();
            }
            //Entities.PERSONELLER.Remove(personelcs);
            //Entities.SaveChanges();
        }

        public static List<View_SIPARIS_DETAY_LIST> LISTELE()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_SIPARIS_DETAY_LIST> SIPARIS_DETAY_LIST = Entities.View_SIPARIS_DETAY_LIST.ToList();
            return SIPARIS_DETAY_LIST;
        }

        public static List<View_SIPARIS_DETAY_LIST> LISTELE_COM()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_SIPARIS_DETAY_LIST> SIPARIS_DETAY_LIST = Entities.View_SIPARIS_DETAY_LIST.ToList();
            return SIPARIS_DETAY_LIST;
        }
    }
}
