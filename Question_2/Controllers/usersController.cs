using carterAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace carterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        private readonly IConfiguration _config;
        Models.Endpoint endpoint1 = new Models.Endpoint();
        List<Models.Endpoint> _endpoint = new List<Models.Endpoint>();

        public usersController(IConfiguration config)
        {
             _config = config;
            _clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

        }
        [HttpGet, Route("getAllUsers")]
        // Select * users
        public Response getAllUsers()
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.getAllUsers(con);
            return resp; 
        }

        [HttpGet, Route("getUserById/{id}")]
        // Select * users using an ID
        public Response getUserById(int id)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.getUserById(con, id);
            return resp;
        }

        [HttpPost, Route("addNewUser")]
        // Insert new user
        public Response addNewUser(Models.Endpoint endpoint)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.addNewUser(con, endpoint); 

            return resp;
        }


        [HttpPost, Route("addNewCar")]
        // Add new car
        public Response addNewCar(Models.carEndpoint endpoint)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.addNewCar(con, endpoint);

            return resp;
        }

        [HttpGet, Route("getCarById/{id}")]
        // Get car by id
        public Response getCarById(int id)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.getCarById(con, id);
            return resp;
        }

        [HttpGet, Route("getAllCars")]
        // Select * cars
        public Response getAllCars()
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.getAllCars(con);
            return resp;
        }


        [HttpPost, Route("addNewPurchase")]
        // Add new purchase
        public Response addNewPurchase(Models.purchasesEndpoint endpoint)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.addNewPurchase(con, endpoint);

            return resp;
        }

        [HttpGet, Route("getPurchaseId/{id}")]
        // Get purchase by id
        public Response getPurchaseId(int id)
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.getPurchaseId(con, id);
            return resp;
        }
        

       [HttpGet, Route("getAllPurchases")]
        // Get All purchases
        public Response getAllPurchases()
        {
            SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
            Response resp = new Response();
            DAL dal = new DAL();
            resp = dal.getAllPurchases(con);
            return resp;
        }


//         [HttpGet, Route("storedProcedureId/{id}")]
//         public Response storedProcedure(int id)
//         {
//             SqlConnection con = new SqlConnection(_config.GetConnectionString("DefulatConnection").ToString());
//             Response resp = new Response();
//             DAL dal = new DAL();
//             resp = dal.storedProcedure(con, id);
//             return resp;
//         }
   
        [HttpPost, Route("createTrilloCard")]
        public async Task<List<Models.Endpoint>> createCard(string name)
        {
            _endpoint = new List<Models.Endpoint>();
            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://api.trello.com/1/cards?idList=6362271e643dc4008257dbe7&key=c739eb66ceb45a7b1cc5b7da913bef93&token=a53373ff08e73f72f8ae38bb54f482804b3c4ef8bb7a9d32b3654fe6d9fa109c&name="+name))
                {
                    String apiRes = await response.Content.ReadAsStringAsync();
                    _endpoint = JsonConvert.DeserializeObject<List<Models.Endpoint>>(apiRes);
                }
            }

            return _endpoint;
        }




    }
}
