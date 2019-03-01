using alytalomob.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace alytalomob.Controllers
{
    public class LampoTilaController : Controller
    {
        // GET: Sauna
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetList()
        {
            AlyTaloEntities entities = new AlyTaloEntities();
            var model = (from v in entities.HuoneLampo
                             //orderby p.HuoneID descending
                         select new
                         {
                             v.HuoneID,
                             v.Huone_Nimi,
                             v.LampoNyt,
                             v.LampoPaalla,
                             v.LampoOn,
                             v.LampoOff,
                             v.Tila
                         }).ToList();

            string json = JsonConvert.SerializeObject(model);
            entities.Dispose();
            //välimuistin hallinta
            Response.Expires = -1;
            Response.CacheControl = "no-cache";

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LampoOff(string id)
        {
            AlyTaloEntities entities = new AlyTaloEntities();

            bool OK = false;
            HuoneLampo dbItem = (from s in entities.HuoneLampo
                            where s.HuoneID.ToString() == id
                            select s).FirstOrDefault();

            if (dbItem != null)
            {
                dbItem.LampoNyt = 20;
                dbItem.Tila = "OFF";

                entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muodossa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }
        public ActionResult LampoON(string id)
        {
            AlyTaloEntities entities = new AlyTaloEntities();

            bool OK = false;
            HuoneLampo dbItem = (from s in entities.HuoneLampo
                            where s.HuoneID.ToString() == id
                            select s).FirstOrDefault();

            if (dbItem != null)
            {

                dbItem.Tila = "ON";

                entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muodossa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }

        public ActionResult LampoMiinus(string id)
        {
            AlyTaloEntities entities = new AlyTaloEntities();

            bool OK = false;
            HuoneLampo dbItem = (from s in entities.HuoneLampo
                            where s.HuoneID.ToString() == id
                            select s).FirstOrDefault();

            if (dbItem != null)
            {
                dbItem.Tila = "ON";
                dbItem.LampoNyt = dbItem.LampoNyt - 5;

                if (dbItem.LampoNyt > 19 && dbItem.LampoNyt < 91)

                    entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muodossa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }
        public ActionResult HuonePlus(string id)
        {
            AlyTaloEntities entities = new AlyTaloEntities();

            bool OK = false;
            HuoneLampo dbItem = (from s in entities.HuoneLampo
                            where s.HuoneID.ToString() == id
                            select s).FirstOrDefault();

            if (dbItem != null)
            {
                dbItem.Tila = "ON";
                dbItem.LampoNyt = dbItem.LampoNyt + 5;

                if (dbItem.LampoNyt > 19 && dbItem.LampoNyt < 91)

                    entities.SaveChanges();
                OK = true;
            }

            //entiteettiolion vapauttaminen
            entities.Dispose();

            // palautetaan 'json' muodossa
            return Json(OK, JsonRequestBehavior.AllowGet);

        }

    }
}