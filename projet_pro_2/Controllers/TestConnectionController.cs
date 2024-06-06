using System.Web.Mvc;
using projet_pro_2.bddmanager;

namespace projet_pro_2.Controllers
{
    /// <summary>
    /// Contrôleur pour tester la connexion à la base de données.
    /// </summary>
    public class TestConnectionController : Controller
    {
        /// <summary>
        /// Action pour tester la connexion à la base de données.
        /// </summary>
        /// <returns>Retourne la vue avec le message de connexion.</returns>
        public ActionResult Index()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string message;

            try
            {
                BddManager bddManager = BddManager.GetInstance(connectionString);
                message = "Connexion réussie à la base de données MySQL.";
            }
            catch (System.Exception ex)
            {
                message = "Erreur de connexion : " + ex.Message;
            }

            ViewBag.Message = message;
            return View();
        }
    }
}
