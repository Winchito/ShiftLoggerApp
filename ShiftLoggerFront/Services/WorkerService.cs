using System.Text.Json;
using ShiftLoggerFront.Models;

namespace ShiftLoggerFront.Services
{
    internal class WorkerService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string BASE_URL = "https://localhost:7281";


        public static async Task GetWorkers()
        {
            string endPoint = "/api/Workers";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseData = await responseMessage.Content.ReadAsStringAsync();

                        var workerList = JsonSerializer.Deserialize<List<Worker>>(responseData);

                        WorkerUserOutputs.ShowWorkers(workerList);

                    }
                    else
                    {
                        Console.WriteLine("There was an error retrieving data!");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public static async Task GetWorkerById(int id)
        {
            string endPoint = "/api/Workers";
            string requestUrl = $"{BASE_URL}{endPoint}/{id}";

            try
            {
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseData = await responseMessage.Content.ReadAsStringAsync();

                        var workerList = JsonSerializer.Deserialize<Worker>(responseData);

                        WorkerUserOutputs.ShowWorker(workerList);

                    }
                    else
                    {
                        Console.WriteLine("There was an error retrieving data!");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

        public static async Task PostWorker(Worker worker)
        {
            string endPoint = "/api/Workers";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
               
                var values = new Dictionary<string, string> {
                    { "firstName", worker.firstName},
                    { "lastName", worker.lastName} };

                var content = new FormUrlEncodedContent(values);
                
                using HttpResponseMessage response = await httpClient.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Worker created\nDetails\n{responseContent}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static async Task PutWorker(int id, Worker worker)
        {
            string endPoint = "/api/Workers";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                var values = new Dictionary<string, string> {
                    { "id", id.ToString()},
                    { "firstName", worker.firstName},
                    { "lastName", worker.lastName} };

                var content = new FormUrlEncodedContent(values);

                using HttpResponseMessage response = await httpClient.PutAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Worker modified");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static async Task DeleteWorker(int id)
        {
            string endPoint = $"/api/Workers/{id}";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                using HttpResponseMessage response = await httpClient.DeleteAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Worker Deleted");
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}

