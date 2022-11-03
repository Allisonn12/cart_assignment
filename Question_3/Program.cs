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

        //static string user_first_name;
        //static string user_last_name;
        //static string user_email;
        //static int user_phone_numer;

        static void ShowUser(userClass user)
        {
            Console.WriteLine($"Name: {user.first_name}\tLast Name: " +
                $"{user.last_name}\tEmail: {user.email}" +
                $"Phone Number: {user.phone_number}");
        }

        static async Task<Uri> CreateCardAsync(userClass name)
        {
            userClass cls = new userClass();
            HttpResponseMessage response = await client.PostAsJsonAsync(
                 "https://api.trello.com/1/lists?name=Please_word&idBoard=6362271e643dc4008257dbe0&key=c739eb66ceb45a7b1cc5b7da913bef93&token=a53373ff08e73f72f8ae38bb54f482804b3c4ef8bb7a9d32b3654fe6d9fa109c", name);

            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        static async Task<userClass> GetUserAsync(string path)
        {
            //path = "https://api.trello.com/1/cards/{id}?key=c739eb66ceb45a7b1cc5b7da913bef93&token=a53373ff08e73f72f8ae38bb54f482804b3c4ef8bb7a9d32b3654fe6d9fa109c";
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
                $"https://api.trello.com/1/lists?name=Please_word&idBoard=6362271e643dc4008257dbe0&key=c739eb66ceb45a7b1cc5b7da913bef93&token=a53373ff08e73f72f8ae38bb54f482804b3c4ef8bb7a9d32b3654fe6d9fa109c", users);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated user from the response body.
            users = await response.Content.ReadAsAsync<userClass>();
            return users;
        }

        static async Task<HttpStatusCode> DeleteUserAsync(string id)
        {
            HttpResponseMessage response = await client.DeleteAsync(
                $"https://api.trello.com/1/lists?name=Please_word&idBoard=6362271e643dc4008257dbe0&key=c739eb66ceb45a7b1cc5b7da913bef93&token=a53373ff08e73f72f8ae38bb54f482804b3c4ef8bb7a9d32b3654fe6d9fa109c");
            return response.StatusCode;
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

                var url = await CreateCardAsync(users);
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