using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using projet_pro_2.Models;
using projet_pro_2.bddmanager;

namespace projet_pro_2.Controllers
{
    public class PersonnelController : Controller
    {
        private BddManager bddManager = BddManager.GetInstance("votre_chaine_de_connexion");

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nom, string prenom, string tel, string mail, int idservice)
        {
            string query = "INSERT INTO personnel (nom, prenom, tel, mail, idservice) VALUES (@Nom, @Prenom, @Tel, @Mail, @idservice)";
            var parameters = new Dictionary<string, object>
            {
                {"@Nom", nom},
                {"@Prenom", prenom},
                {"@Tel", tel},
                {"@Mail", mail},
                {"@idservice", idservice}
            };
            bddManager.ReqUpdate(query, parameters);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            string query = "DELETE FROM personnel WHERE idpersonnel = @Id";
            var parameters = new Dictionary<string, object>
    {
        {"@Id", id}
    };
            bddManager.ReqUpdate(query, parameters);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var personnel = bddManager.ReqSelect("SELECT * FROM personnel WHERE idpersonnel = @Id", new Dictionary<string, object> { { "@Id", id } })
                                       .Select(row => new Personnel
                                       {
                                           idpersonnel = (int)row[0],
                                           nom = row[1].ToString(),
                                           prenom = row[2].ToString(),
                                           tel = row[3].ToString(),
                                           mail = row[4].ToString(),
                                           idservice = Convert.ToInt32(row[5])
                                       }).FirstOrDefault();

            return View(personnel);
        }

        [HttpPost]
        public ActionResult Edit(int id, string nom, string prenom, string tel, string mail, int idservice)
        {
            string query = "UPDATE personnel SET nom = @Nom, prenom = @Prenom, tel = @Tel, mail = @Mail, idservice = @idservice WHERE idpersonnel = @Id";
            var parameters = new Dictionary<string, object>
    {
        {"@Id", id},
        {"@Nom", nom},
        {"@Prenom", prenom},
        {"@Tel", tel},
        {"@Mail", mail},
        {"@idservice", idservice}
    };
            bddManager.ReqUpdate(query, parameters);
            return RedirectToAction("Index");
        }


    }
}
