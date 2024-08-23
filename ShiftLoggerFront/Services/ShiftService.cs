using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;
using ShiftLoggerFront.Models;

namespace ShiftLoggerFront.Services
{
    internal class ShiftService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string BASE_URL = "https://localhost:7281";


        public static async Task GetShifts()
        {
            string endPoint = "/api/Shift";
            string requestUrl = $"{BASE_URL}{endPoint}";
            
            try
            {
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseData = await responseMessage.Content.ReadAsStringAsync();

                        var shiftList = JsonSerializer.Deserialize<List<Shift>>(responseData);

                        ShiftUserOutputs.ShowShifts(shiftList);

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

        public static async Task GetShiftById(int id)
        {
            string endPoint = "/api/Shift";
            string requestUrl = $"{BASE_URL}{endPoint}/{id}";

            try
            {
                using (HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUrl))
                {
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        string responseData = await responseMessage.Content.ReadAsStringAsync();

                        var shiftList = JsonSerializer.Deserialize<Shift>(responseData);

                        ShiftUserOutputs.ShowShift(shiftList);

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

        public static async Task PostShift(Shift shift)
        {
            string endPoint = "/api/Shift";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                //using StringContent jsonContent = new(
                //JsonSerializer.Serialize(shift), Encoding.UTF8, "multipart/form-data");

                var values = new Dictionary<string, string> {
                    { "shiftName", shift.shiftName },
                    { "startTime", shift.startTime},
                    { "endTime", shift.endTime} };
                var content = new FormUrlEncodedContent(values);

                //using HttpResponseMessage response = await httpClient.PostAsync(requestUrl, jsonContent);
                using HttpResponseMessage response = await httpClient.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Shift created\nDetails\n{responseContent}");
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

        public static async Task PutShift(int id, Shift shift)
        {
            string endPoint = "/api/Shift";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                var values = new Dictionary<string, string> 
                {
                    { "id", id.ToString()},
                    { "shiftName", shift.shiftName },
                    { "startTime", shift.startTime},
                    { "endTime", shift.endTime} 
                };

                var content = new FormUrlEncodedContent(values);

                using HttpResponseMessage response = await httpClient.PutAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Shift modified");
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

        public static async Task DeleteShift(int id)
        {
            string endPoint = $"/api/Shift/{id}";
            string requestUrl = $"{BASE_URL}{endPoint}";

            try
            {
                using HttpResponseMessage response = await httpClient.DeleteAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Shift Deleted");
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
