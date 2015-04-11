using System.Linq;
using Litmus.Domain.Entity;
using Litmus.Domain.Facade;
using Litmus.Web.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Globalization;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Litmus.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string TenantIdClaimType = "http://schemas.microsoft.com/identity/claims/tenantid";
        private const string LoginUrl = "https://login.windows.net/{0}";
        private const string GraphUrl = "https://graph.windows.net";
        private const string GraphUserUrl = "https://graph.windows.net/{0}/users/{1}?api-version=2013-04-05";
        private static readonly string AppPrincipalId = ConfigurationManager.AppSettings["ida:ClientID"];
        private static readonly string AppKey = ConfigurationManager.AppSettings["ida:Password"];

        private readonly IDomainFacade _facade;

        public HomeController(IDomainFacade facade)
        {
            _facade = facade;
        }

        [Authorize]
        public ActionResult Index()
        {
            var user = _facade.AllUser().FirstOrDefault(x => x.Name == User.Identity.Name);
            if(user==null) {
                var model = new User {
                    Name = User.Identity.Name,
                    IsDeleted = false
                };
                _facade.AddUser(model);
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public async Task<ActionResult> UserProfile()
        {
            string tenantId = ClaimsPrincipal.Current.FindFirst(TenantIdClaimType).Value;

            // Get a token for calling the Windows Azure Active Directory Graph
            AuthenticationContext authContext = new AuthenticationContext(String.Format(CultureInfo.InvariantCulture, LoginUrl, tenantId));
            ClientCredential credential = new ClientCredential(AppPrincipalId, AppKey);
            AuthenticationResult assertionCredential = authContext.AcquireToken(GraphUrl, credential);
            string authHeader = assertionCredential.CreateAuthorizationHeader();
            string requestUrl = String.Format(
                CultureInfo.InvariantCulture,
                GraphUserUrl,
                HttpUtility.UrlEncode(tenantId),
                HttpUtility.UrlEncode(User.Identity.Name));

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            request.Headers.TryAddWithoutValidation("Authorization", authHeader);
            HttpResponseMessage response = await client.SendAsync(request);
            string responseString = await response.Content.ReadAsStringAsync();
            UserProfile profile = JsonConvert.DeserializeObject<UserProfile>(responseString);

            return Json(profile,JsonRequestBehavior.AllowGet);
        }
    }
}