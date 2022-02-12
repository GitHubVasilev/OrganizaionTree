using ConnectToDataLibrary.Interfaces;
using ConnectToDataLibrary.Models;
using ConnectToDataLibrary.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace ConnectToDataLibrary.Services
{
    public class ServiceWorkers : IService<WorkerModel>, IServiceEvents<WorkerModel>
    {
        public event IServiceEvents<WorkerModel>.AddModel AddEvent;
        public event IServiceEvents<WorkerModel>.RemoveModel RemoveEvent;
        public event IServiceEvents<WorkerModel>.UpdateModel UpdateEvent;

        private readonly HttpClient _httpClient;

        public ServiceWorkers()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Resources.WorkersDataAPIBaseUri);
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
        }

        public void Delete(Guid uid)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"api/Workers/{uid}");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            RemoveEvent?.Invoke(uid);
        }

        public WorkerModel Get(Guid uid)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"api/Workers/{uid}");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<WorkerModel>(response.Content.ReadAsStringAsync().Result);
        }

        public IEnumerable<WorkerModel> GetAll()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"api/Workers");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<WorkerModel>>(response.Content.ReadAsStringAsync().Result);
        }

        public void Set(WorkerModel model)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"api/Workers");
            request.Content = request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            AddEvent?.Invoke(model);
        }

        public void Update(Guid uid, WorkerModel model)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"api/Workers/{uid}");
            request.Content = request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response =  _httpClient.SendAsync(request).Result;
            UpdateEvent?.Invoke(uid, model);
        }
    }
}
