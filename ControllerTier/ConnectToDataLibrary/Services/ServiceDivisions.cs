using ConnectToDataLibrary.Interfaces;
using ConnectToDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using ConnectToDataLibrary.Properties;
using System.Text;
using System.Net.Http.Headers;

namespace ConnectToDataLibrary.Services
{
    public class ServiceDivisions : IService<DivisionModel>, IServiceEvents<DivisionModel>
    {
        public event IServiceEvents<DivisionModel>.AddModel AddEvent;
        public event IServiceEvents<DivisionModel>.RemoveModel RemoveEvent;
        public event IServiceEvents<DivisionModel>.UpdateModel UpdateEvent;

        private readonly HttpClient _httpClient;

        public ServiceDivisions()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Resources.DepartmentDataAPIBaseUri);
            _httpClient.DefaultRequestHeaders.Add("Accept", "*/*");
        }

        public void Delete(Guid uid)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, $"api/Divisions/{uid}");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            RemoveEvent?.Invoke(uid);
        }

        public DivisionModel Get(Guid uid)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"api/Divisions/{uid}");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<DivisionModel>(response.Content.ReadAsStringAsync().Result);
        }

        public IEnumerable<DivisionModel> GetAll()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"api/Divisions");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<IEnumerable<DivisionModel>>(response.Content.ReadAsStringAsync().Result);
        }

        public void Set(DivisionModel model)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, $"api/Divisions");
            request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            AddEvent?.Invoke(model);
        }

        public void Update(Guid uid, DivisionModel model)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, $"api/Divisions/{uid}");
            request.Content = request.Content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.SendAsync(request).Result;
            UpdateEvent?.Invoke(uid, model);
        }
    }
}
