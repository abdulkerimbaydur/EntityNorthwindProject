
using EntityNorthwindProject.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityNorthwindProject.Service
{
    public class Personelcs
    {
       
        public static void Insert(PERSONELLER personelcs)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            Entities.PERSONELLER.Add(personelcs);
            Entities.SaveChanges();
        }



        public static void Update(PERSONELLER personelcs)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniPersonel = Entities.PERSONELLER.Where(x => x.ID == personelcs.ID).FirstOrDefault();
            if (YeniPersonel !=null)
            {
                YeniPersonel.TCKN = personelcs.TCKN;
                YeniPersonel.AD = personelcs.AD;
                YeniPersonel.SOYAD = personelcs.SOYAD;
                YeniPersonel.CINSIYET = personelcs.CINSIYET;
                YeniPersonel.DOGUM_YERI = personelcs.DOGUM_YERI;
                Entities.SaveChanges();

            }
        }



        public static void SIL(PERSONELLER personelcs)
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            var YeniPersonel = Entities.PERSONELLER.Where(x => x.ID == personelcs.ID).FirstOrDefault();
            if (YeniPersonel !=null)
            {
                YeniPersonel.IS_FLAG = 0;
                Entities.SaveChanges();
            }
            //Entities.PERSONELLER.Remove(personelcs);
            //Entities.SaveChanges();
        }

        public static List<View_PERSONEL_LIST> LISTELE()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_PERSONEL_LIST> PERSONEL_LIST = Entities.View_PERSONEL_LIST.ToList();
            return PERSONEL_LIST;


            //string sql = "SELECT * FROM View_PERSONEL_LIST";
            //return Provider.GetQueryDataTable(sql);
        }

        public static List<View_PERSONEL_LIST> LISTELEPER()
        {
            NorthwindTR_DbEntities Entities = new NorthwindTR_DbEntities();
            List<View_PERSONEL_LIST> PERSONEL_LIST = Entities.View_PERSONEL_LIST.ToList();
            return PERSONEL_LIST;
        }

    }
}
