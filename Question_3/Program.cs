using Microsoft.AspNetCore.Http;
using RestSharp;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using tr.Model;
using unirest_net.http;

namespace HttpClientSample
{
    

    class Program
    {
        static HttpClient client = new HttpClient();

        


        static async Task<Uri> CreateCardAsync(userClass name, string user_name, string user_lname, string user_email, int user_phone_number)
        {
            userClass cls = new userClass();
            HttpResponseMessage response = await client.PostAsJsonAsync(
                 "https://api.trello.com/1/lists?name=New_card&idBoard=5a4b3c4cbe0188ca9c0b2058&key=6eb508bda626ff893db446eff50d0066&token=ae4a73cb0e40c46f6e642f5f7429394534b35e3b5a4c7c21438e5389eec20497", name);

            user_name = cls.first_name;
            user_lname = cls.last_name;
            user_email = cls.email;
            user_phone_number = cls.phone_number;

            string phone = Convert.ToString(user_phone_number);
            string[] arr = { user_name, user_lname, user_email, phone};

            for (int i = 0; i < arr.Length; i++)
            {
                HttpResponseMessage resp = await client.PostAsJsonAsync(
                     "https://api.trello.com/1/cards?idList=634bfc7a3e039d0031f4dac4&key=6eb508bda626ff893db446eff50d0066&token=ae4a73cb0e40c46f6e642f5f7429394534b35e3b5a4c7c21438e5389eec20497", arr[i]);

            }



        
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        
        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://api.trello.com/1/members/me/boards?key=c739eb66ceb45a7b1cc5b7da913bef93&token=a53373ff08e73f72f8ae38bb54f482804b3c4ef8bb7a9d32b3654fe6d9fa109c");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Create a new user
                userClass users = new userClass
                {
                    first_name = "Allison",
                    last_name = "Masemola",
                    email = "allison.masemola@gmail.com",
                    phone_number = 0815215211
                };

                string userName = users.first_name;
                string userLName = users.last_name ;
                string userEmail = users.email;
                int pNum = users.phone_number;

                var url = await CreateCardAsync(users, userName, userLName, userEmail, pNum);
                Console.WriteLine($"Registration was successful");

                

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }





    }
}
