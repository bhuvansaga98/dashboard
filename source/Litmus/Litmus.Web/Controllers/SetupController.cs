using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Litmus.Data;

namespace Litmus.Web.Controllers
{
    public class SetupController : Controller
    {
        public async Task<ActionResult> Upgrade()
        {
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Data.Migrations.Configuration>());
                using(var db = new DataContext())
                {
                    db.Database.Initialize(true);
                    await db.SaveChangesAsync();
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
            }
            catch(Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}