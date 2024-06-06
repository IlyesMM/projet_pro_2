using System.Linq;
using System.Web.Mvc;
using projet_pro_2.Models;
using projet_pro_2.bddmanager;

namespace projet_pro_2.Controllers
{
    public class AccountController : Controller
    {
        private BddManager bddManager = BddManager.GetInstance("votre_chaine_de_connexion");

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            string query = "SELECT * FROM responsable WHERE login = @login AND pwd = SHA2(@pwd, 256)";
            var parameters = new Dictionary<string, object>
            {
                {"@login", login},
                {"@pwd", password}
            };
            var result = bddManager.ReqSelect(query, parameters);

            if (result.Any())
            {
                Session["User"] = login;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Login ou mot de passe incorrect.";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
