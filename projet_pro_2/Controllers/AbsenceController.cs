using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using projet_pro_2.Models;
using projet_pro_2.bddmanager;

namespace projet_pro_2.Controllers
{
    public class AbsenceController : Controller
    {
        private BddManager bddManager = BddManager.GetInstance("votre_chaine_de_connexion");

        public ActionResult Index()
        {
            var absences = bddManager.ReqSelect("SELECT * FROM absence").Select(row => new Absence
            {
                idpersonnel = (int)row[0],
                datedebut = (DateTime)row[1],
                datefin = (DateTime)row[2],
                idmotif = (int)row[3]
            }).ToList();

            return View(absences);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int idpersonnel, DateTime datedebut, DateTime datefin, int idmotif)
        {
            string query = "INSERT INTO absence (idpersonnel, datedebut, datefin, idmotif) VALUES (@idpersonnel, @datedebut, @datefin, @idmotif)";
            var parameters = new Dictionary<string, object>
    {
        {"@idpersonnel", idpersonnel},
        {"@datedebut", datedebut},
        {"@datefin", datefin},
        {"@idmotif", idmotif}
    };
            bddManager.ReqUpdate(query, parameters);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int idpersonnel, DateTime datedebut)
        {
            string query = "DELETE FROM absence WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut";
            var parameters = new Dictionary<string, object>
    {
        {"@idpersonnel", idpersonnel},
        {"@datedebut", datedebut}
    };
            bddManager.ReqUpdate(query, parameters);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int idpersonnel, DateTime datedebut)
        {
            var absence = bddManager.ReqSelect("SELECT * FROM absence WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut", new Dictionary<string, object> { { "@idpersonnel", idpersonnel }, { "@datedebut", datedebut } })
                                   .Select(row => new Absence
                                   {
                                       idpersonnel = (int)row[0],
                                       datedebut = (DateTime)row[1],
                                       datefin = (DateTime)row[2],
                                       idmotif = (int)row[3]
                                   }).FirstOrDefault();

            return View(absence);
        }

        [HttpPost]
        public ActionResult Edit(int idpersonnel, DateTime datedebut, DateTime datefin, int idmotif)
        {
            string query = "UPDATE absence SET datefin = @datefin, idmotif = @idmotif WHERE idpersonnel = @idpersonnel AND datedebut = @datedebut";
            var parameters = new Dictionary<string, object>
    {
        {"@idpersonnel", idpersonnel},
        {"@datedebut", datedebut},
        {"@datefin", datefin},
        {"@idmotif", idmotif}
    };
            bddManager.ReqUpdate(query, parameters);
            return RedirectToAction("Index");
        }



    }
}
