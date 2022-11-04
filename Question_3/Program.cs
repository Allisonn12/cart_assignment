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

        
        static void ShowUser(userClass user)
        {
            Console.WriteLine($"Name: {user.first_name}\tLast Name: " +
                $"{user.last_name}\tEmail: {user.email}\t" +
                $"Phone Number: {user.phone_number}");
        }

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

        static async Task<userClass> GetUserAsync(string path)
        {
            userClass user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<userClass>();
            }
            return user;
        }

        static async Task<userClass> UpdateUserAsync(userClass users)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://api.trello.com/1/lists?idBoard=5a4b3c4cbe0188ca9c0b2058&key=6eb508bda626ff893db446eff50d0066&token=ae4a73cb0e40c46f6e642f5f7429394534b35e3b5a4c7c21438e5389eec20497&name=" + users.first_name + " " + users.last_name, users);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated user from the response body.
            users = await response.Content.ReadAsAsync<userClass>();
            return users;
        }

        static async Task<HttpStatusCode> DeleteUserAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://api.trello.com/1/lists?name=New_Registration&idBoard=5a4b3c4cbe0188ca9c0b2058&key=6eb508bda626ff893db446eff50d0066&token=ae4a73cb0e40c46f6e642f5f7429394534b35e3b5a4c7c21438e5389eec20497");
            return response.StatusCode;
        }

        static void Main()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("https://api.trello.com/1/members/me/boards?key=6eb508bda626ff893db446eff50d0066&token=ae4a73cb0e40c46f6e642f5f7429394534b35e3b5a4c7c21438e5389eec20497");
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
                Console.WriteLine($"Created at {url}");

                // Get the user
                users = await GetUserAsync(url.PathAndQuery);
                ShowUser(users);

                // Update the user
                Console.WriteLine("Updating user...");
                users.phone_number = 80;
                await UpdateUserAsync(users);

                // Get the updated user
                users = await GetUserAsync(url.PathAndQuery);
                ShowUser(users);

                // Delete the user
                var statusCode = await DeleteUserAsync(users.id);
                Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }





    }
}
