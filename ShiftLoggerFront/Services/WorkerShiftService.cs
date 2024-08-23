using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ShiftLoggerFront.Models;

namespace ShiftLoggerFront.Services
{
    internal class WorkerShiftService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string BASE_URL = "https://localhost:7281";


        public static async Task GetWorkerShifts()
        {
            string endPoint = "/api/WorkerShift";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseData = await responseMessage.Content.ReadAsStringAsync();

                        var workerShiftList = JsonSerializer.Deserialize<List<WorkerShift>>(responseData);

                        WorkerShiftUserOutputs.ShowWorkerShifts(workerShiftList);

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

        public static async Task GetWorkerShiftById(int id)
        {
            string endPoint = "/api/WorkerShift";
            string requestUrl = $"{BASE_URL}{endPoint}/{id}";

            try
            {
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseData = await responseMessage.Content.ReadAsStringAsync();

                        var workerShiftList = JsonSerializer.Deserialize<WorkerShift>(responseData);

                        WorkerShiftUserOutputs.ShowWorkerShift(workerShiftList);

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

        public static async Task PostWorkerShift(WorkerShift workerShift)
        {
            string endPoint = "/api/WorkerShift";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {

                var values = new Dictionary<string, string> {
                    { "workerId", workerShift.workerId.ToString()},
                    { "shiftId", workerShift.shiftId.ToString()} };

                var content = new FormUrlEncodedContent(values);

                using HttpResponseMessage response = await httpClient.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Worker Shift created\nDetails\n{responseContent}");
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}. Check the ID of Workers and Shifts!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static async Task PutWorkerShift(int id, WorkerShift workerShift)
        {
            string endPoint = "/api/WorkerShift";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                var values = new Dictionary<string, string> {
                    { "id", id.ToString()},
                    { "workerId", workerShift.workerId.ToString()},
                    { "shiftId", workerShift.shiftId.ToString()} };

                var content = new FormUrlEncodedContent(values);

                using HttpResponseMessage response = await httpClient.PutAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Worker Shift modified");
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

        public static async Task DeleteWorkerShift(int id)
        {
            string endPoint = $"/api/WorkerShift/{id}";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                using HttpResponseMessage response = await httpClient.DeleteAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Worker Shift Deleted");
                }
                else
                {
                    Console.WriteLine("Error! "+response.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static async Task GetWorkersShiftsDetails()
        {
            string endPoint = "/api/WorkerShift/GetWorkerShiftsDetails";
            string requestUrl = $"{BASE_URL}{endPoint}";

            using HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode) 
            {
                var responseData = await response.Content.ReadAsStringAsync();

                var workerShiftDetailList = JsonSerializer.Deserialize<List<WorkerShiftDetails>>(responseData);

                WorkerShiftUserOutputs.ShowWorkersDetailsShifts(workerShiftDetailList);

            }
        }

        public static async Task GetWorkerShiftDetailsById(int id)
        {
            string endPoint = "/api/WorkerShift/GetWorkerShiftDetails";
            string requestUrl = $"{BASE_URL}{endPoint}/{id}";

            try
            {
                using HttpResponseMessage response = await httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();

                    var workerShiftDetailList = JsonSerializer.Deserialize<List<WorkerShiftDetails>>(responseData);

                    WorkerShiftUserOutputs.ShowWorkersDetailsShifts(workerShiftDetailList);

                }
                else
                {
                    Console.WriteLine(response.StatusCode);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

