using System.Data;
using System.Data.SqlClient;

namespace carterAPI.Models
{
    public class DAL
    {
        // Get all Users
        public Response getAllUsers(SqlConnection con)
        {
            Response resp = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_customer_info", con);
            DataTable dt = new DataTable();
            List<Endpoint> point = new List<Endpoint>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Endpoint list_point = new Endpoint();
                    list_point.cust_id = Convert.ToInt32(dt.Rows[i]["cust_id"]);
                    list_point.first_name = Convert.ToString(dt.Rows[i]["first_name"]);
                    list_point.last_name = Convert.ToString(dt.Rows[i]["last_name"]);
                    list_point.email = Convert.ToString(dt.Rows[i]["email"]);
                    list_point.phone_number = Convert.ToString(dt.Rows[i]["phone_number"]);

                    point.Add(list_point);
                }
            }

            if (point.Count > 0)
            {
                resp.StatusCode = 200;
                resp.StatusMessage = "Data found";
                resp.list_point = point;
            }
            else
            {
                resp.StatusCode = 404;
                resp.StatusMessage = "Data not found";
                resp.list_point = null;
            }


            return resp;
        }

        // Get user By ID
        public Response getUserById(SqlConnection con, int id)
        {
            Response resp = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_customer_info WHERE cust_id='"+id+"' ", con);
            DataTable dt = new DataTable();
            Endpoint point = new Endpoint();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                    Endpoint list_point = new Endpoint();
                    list_point.cust_id = Convert.ToInt32(dt.Rows[0]["cust_id"]);
                    list_point.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
                    list_point.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
                    list_point.phone_number = Convert.ToString(dt.Rows[0]["phone_number"]);
                    resp.StatusCode = 200;
                    resp.StatusMessage = "Data found";
                    resp.end_point = list_point;
            }
            else
            {
                resp.StatusCode = 404;
                resp.StatusMessage = "Data not found";
                resp.end_point = null;
            }


            return resp;
        }

        // Create new user
        public Response addNewUser(SqlConnection con, Endpoint endpoint) // Create object to take values from the Endpoint class
        {
            Response resp = new Response();// Call the response class
            SqlCommand cmd = new SqlCommand("INSERT INTO tbl_customer_info(first_name, last_name, email, phone_number) " +
                "VALUES('"+endpoint.first_name+"','"+endpoint.last_name+"','"+endpoint.email+"','"+endpoint.phone_number+"')", con);
            con.Open(); // Open connection
            int i = cmd.ExecuteNonQuery(); // Exec query
            con.Close(); // Close connection to prevent data leak
            if (i > 0) // If user was added, return 200 status code
            {
                 resp.StatusCode = 200;
                 resp.StatusMessage = "User added successfully";
            }
            else
            { // Else return errer
                resp.StatusCode = 404;
                resp.StatusMessage = "Unexpected error occured. Please try again!!!";
            }




            return resp;
        }
        // Add new car
        public Response addNewCar(SqlConnection con, carEndpoint endpoint) 
        {
            Response resp = new Response();
            SqlCommand cmd = new 
                SqlCommand("INSERT INTO tbl_car_info(car_name, car_model, car_image, year_released, " +
                "no_of_liters, transmission, price, monthly_installment, insurance, warrenty, good_features, " +
                "bad_features) " +
                "VALUES('"
                +endpoint.car_name
                +"','"+endpoint.car_model
                +"','"+endpoint.car_image
                +"','"+endpoint.year_released
                +"','"+endpoint.no_of_liters
                +"','"+endpoint.transmission
                +"','"+endpoint.price
                +"','"+endpoint.monthly_installment
                + "','"+endpoint.insurance
                + "','"+endpoint.warrenty
                +"','"+endpoint.good_features
                + "','" +endpoint.bad_features
                +"')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                 resp.StatusCode = 200;
                 resp.StatusMessage = "Car added successfully";
            }
            else
            {
                resp.StatusCode = 400;
                resp.StatusMessage = "Unexpected error occured. Please try again!!!";
            }


            return resp;
        }
        
        // Get car by ID
        public Response getCarById(SqlConnection con, int id)
        {
            Response resp = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_car_info WHERE car_id='" + id + "' ", con);
            DataTable dt = new DataTable();
            Endpoint point = new Endpoint();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                carEndpoint list_point = new carEndpoint();
                list_point.car_id = Convert.ToInt32(dt.Rows[0]["car_id"]);
                list_point.car_name = Convert.ToString(dt.Rows[0]["car_name"]);
                list_point.car_model = Convert.ToString(dt.Rows[0]["car_model"]);
                list_point.car_image = Convert.ToString(dt.Rows[0]["car_image"]);
                list_point.year_released = Convert.ToInt32(dt.Rows[0]["year_released"]);
                list_point.no_of_liters = Convert.ToInt32(dt.Rows[0]["no_of_liters"]);
                list_point.transmission = Convert.ToString(dt.Rows[0]["transmission"]);
                list_point.price = Convert.ToDecimal(dt.Rows[0]["price"]);
                list_point.monthly_installment = Convert.ToDecimal(dt.Rows[0]["monthly_installment"]);
                list_point.insurance = Convert.ToInt32(dt.Rows[0]["insurance"]);
                list_point.warrenty = Convert.ToInt32(dt.Rows[0]["warrenty"]);
                list_point.good_features = Convert.ToString(dt.Rows[0]["good_features"]);
                list_point.bad_features = Convert.ToString(dt.Rows[0]["bad_features"]);
                resp.StatusCode = 200;
                resp.StatusMessage = "Data found";
                resp.car_point = list_point;
            }
            else
            {
                resp.StatusCode = 404;
                resp.StatusMessage = "Data not found";
                resp.end_point = null;
            }


            return resp;
        }

        // Get All cars
        public Response getAllCars(SqlConnection con)
        {
            Response resp = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_car_info", con);
            DataTable dt = new DataTable();
            List<carEndpoint> point = new List<carEndpoint>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    carEndpoint list_point = new carEndpoint();
                    list_point.car_id = Convert.ToInt32(dt.Rows[i]["car_id"]);
                    list_point.car_name = Convert.ToString(dt.Rows[i]["car_name"]);
                    list_point.car_model = Convert.ToString(dt.Rows[i]["car_model"]);
                    list_point.car_image = Convert.ToString(dt.Rows[i]["car_image"]);
                    list_point.year_released = Convert.ToInt32(dt.Rows[i]["year_released"]);
                    list_point.no_of_liters = Convert.ToDecimal(dt.Rows[i]["no_of_liters"]);
                    list_point.transmission = Convert.ToString(dt.Rows[i]["transmission"]);
                    list_point.price = Convert.ToDecimal(dt.Rows[i]["price"]);
                    list_point.monthly_installment = Convert.ToDecimal(dt.Rows[i]["monthly_installment"]);
                    list_point.insurance = Convert.ToInt32(dt.Rows[i]["insurance"]);
                    list_point.warrenty = Convert.ToInt32(dt.Rows[i]["warrenty"]);
                    list_point.good_features = Convert.ToString(dt.Rows[i]["good_features"]);
                    list_point.bad_features = Convert.ToString(dt.Rows[i]["bad_features"]);

                    point.Add(list_point);
                }
            }

            if (point.Count > 0)
            {
                resp.StatusCode = 200;
                resp.StatusMessage = "Data found";
                resp.car_Endpoint = point;
            }
            else
            {
                resp.StatusCode = 404;
                resp.StatusMessage = "Data not found";
                resp.list_point = null;
            }


            return resp;
        }


        // Add new purchase
        public Response addNewPurchase(SqlConnection con, purchasesEndpoint endpoint)
        {
            Response resp = new Response();
            SqlCommand cmd = new
                SqlCommand("INSERT INTO tbl_purchases(cust_id, car_id) " +
                "VALUES('" + endpoint.cust_id
                + "','" + endpoint.car_id
                + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i > 0)
            {
                resp.StatusCode = 200;
                resp.StatusMessage = "New purchase added successfully";
            }
            else
            {
                resp.StatusCode = 400;
                resp.StatusMessage = "Unexpected error occured. Please try again!!!";
            }


            return resp;
        }
        // Get Purchase by ID
        public Response getPurchaseId(SqlConnection con, int id)
        {
            Response resp = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT p.*, ci.*, c.* FROM tbl_purchases p " +
                "LEFT JOIN tbl_customer_info ci ON ci.cust_id = p.cust_id " +
                "LEFT JOIN tbl_car_info c ON c.car_id = p.car_id WHERE p.purchase_id='" + id + "' ", con);
            DataTable dt = new DataTable();
            Endpoint point = new Endpoint();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Endpoint poi = new Endpoint();
                carEndpoint list_point = new carEndpoint();
                carEndpoint car = new carEndpoint();
                poi.cust_id = Convert.ToInt32(dt.Rows[0]["cust_id"]);
                poi.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
                poi.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
                poi.email = Convert.ToString(dt.Rows[0]["email"]);
                poi.phone_number = Convert.ToString(dt.Rows[0]["phone_number"]);
                list_point.car_id = Convert.ToInt32(dt.Rows[0]["car_id"]);
                list_point.car_name = Convert.ToString(dt.Rows[0]["car_name"]);
                list_point.car_model = Convert.ToString(dt.Rows[0]["car_model"]);
                list_point.car_image = Convert.ToString(dt.Rows[0]["car_image"]);
                list_point.year_released = Convert.ToInt32(dt.Rows[0]["year_released"]);
                list_point.no_of_liters = Convert.ToInt32(dt.Rows[0]["no_of_liters"]);
                list_point.transmission = Convert.ToString(dt.Rows[0]["transmission"]);
                list_point.price = Convert.ToDecimal(dt.Rows[0]["price"]);
                list_point.monthly_installment = Convert.ToDecimal(dt.Rows[0]["monthly_installment"]);
                list_point.insurance = Convert.ToInt32(dt.Rows[0]["insurance"]);
                list_point.warrenty = Convert.ToInt32(dt.Rows[0]["warrenty"]);
                list_point.good_features = Convert.ToString(dt.Rows[0]["good_features"]);
                list_point.bad_features = Convert.ToString(dt.Rows[0]["bad_features"]);
                resp.StatusCode = 200;
                resp.StatusMessage = "Data found";
                resp.car_point = list_point; 
                resp.end_point = poi;
            }
            else
            {
                resp.StatusCode = 404;
                resp.StatusMessage = "Data not found";
                resp.end_point = null;
            }


            return resp;
        }


        // Get all purchases
        public Response getAllPurchases(SqlConnection con)
        {
            Response resp = new Response();
            SqlDataAdapter da = new SqlDataAdapter("SELECT p.*, ci.*, c.* FROM tbl_purchases p " +
                "LEFT JOIN tbl_customer_info ci ON ci.cust_id = p.cust_id " +
                "LEFT JOIN tbl_car_info c ON c.car_id = p.car_id", con);
            DataTable dt = new DataTable();
            Endpoint point = new Endpoint();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Endpoint poi = new Endpoint();
                carEndpoint list_point = new carEndpoint();
                carEndpoint car = new carEndpoint();
                poi.cust_id = Convert.ToInt32(dt.Rows[0]["cust_id"]);
                poi.first_name = Convert.ToString(dt.Rows[0]["first_name"]);
                poi.last_name = Convert.ToString(dt.Rows[0]["last_name"]);
                poi.email = Convert.ToString(dt.Rows[0]["email"]);
                poi.phone_number = Convert.ToString(dt.Rows[0]["phone_number"]);
                list_point.car_id = Convert.ToInt32(dt.Rows[0]["car_id"]);
                list_point.car_name = Convert.ToString(dt.Rows[0]["car_name"]);
                list_point.car_model = Convert.ToString(dt.Rows[0]["car_model"]);
                list_point.car_image = Convert.ToString(dt.Rows[0]["car_image"]);
                list_point.year_released = Convert.ToInt32(dt.Rows[0]["year_released"]);
                list_point.no_of_liters = Convert.ToInt32(dt.Rows[0]["no_of_liters"]);
                list_point.transmission = Convert.ToString(dt.Rows[0]["transmission"]);
                list_point.price = Convert.ToDecimal(dt.Rows[0]["price"]);
                list_point.monthly_installment = Convert.ToDecimal(dt.Rows[0]["monthly_installment"]);
                list_point.insurance = Convert.ToInt32(dt.Rows[0]["insurance"]);
                list_point.warrenty = Convert.ToInt32(dt.Rows[0]["warrenty"]);
                list_point.good_features = Convert.ToString(dt.Rows[0]["good_features"]);
                list_point.bad_features = Convert.ToString(dt.Rows[0]["bad_features"]);
                resp.StatusCode = 200;
                resp.StatusMessage = "Data found";
                resp.car_point = list_point;
                resp.end_point = poi;
            }
            else
            {
                resp.StatusCode = 404;
                resp.StatusMessage = "Data not found";
                resp.end_point = null;
            }


            return resp;
        }

        
        // 
//         public Response storedProcedure(SqlConnection con, int dealer_id)
//         {
//             Random random = new Random();
//             int ran = random.Next(999999);
//             Response resp = new Response();
//             SqlDataAdapter da = new SqlDataAdapter("CREATE PROCEDURE getDealership"+ran+
//                 " @DealerID nvarchar(255) AS " +
//                 "SELECT test_deler.Dealership_Name, dealer_sales.SaleAmount " +
//                 "FROM SQL_Test_Dealers test_deler " +
//                 "INNER JOIN SQL_Test_Dealer_Sales dealer_sales ON test_deler.DealerID = dealer_sales.DealerID " +
//                 "WHERE test_deler.DealerID = @DealerID; " +
//                 "EXEC getDealership"+ran+" @DealerID = '"+dealer_id+"' ", con);
//             DataTable dt = new DataTable();
//             storedProcedure point = new storedProcedure();
//             da.Fill(dt);
//             if (dt.Rows.Count > 0)
//             {
//                 storedProcedure list_point = new storedProcedure();
//                 list_point.DealerID = Convert.ToInt32(dt.Rows[0]["DealerID"]);
//                 list_point.DateOfSale = Convert.ToDateTime(dt.Rows[0]["DateOfSale"]);
//                 list_point.SalesAmount = Convert.ToDecimal(dt.Rows[0]["SalesAmount"]);
//                 list_point.Dealership_name = Convert.ToString(dt.Rows[0]["Dealership_Name"]);
//                 resp.StatusCode = 200;
//                 resp.StatusMessage = "Data found";
//                 resp.storedProcedure = list_point;
//             }
//             else
//             {
//                 resp.StatusCode = 404;
//                 resp.StatusMessage = "Data not found";
//                 resp.end_point = null;
//             }


//             return resp;
//         }


    }
}
