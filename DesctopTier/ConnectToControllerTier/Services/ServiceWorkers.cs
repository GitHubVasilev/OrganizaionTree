using ConnectToControllerTier.Errors;
using ConnectToControllerTier.Interfaces;
using ConnectToControllerTier.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;

namespace ConnectToControllerTier.Services
{
    public class ServiceWorkers : IServiceWorkers
    {
        public ResponseModel Create(WorkerDTO worker)
        {
            HttpClient httpClient = new();
            string json = $"\'{JsonConvert.SerializeObject(worker)}\'";
            StringContent data = new(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync($"{Properties.Resources.ServiceWorkers}", data).Result;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new HttpResponseException() { ErrorModels = JsonConvert.DeserializeObject<List<ErrorModel>>(response.Content.ReadAsStringAsync().Result) };
            }

            return new ResponseModel(response.StatusCode, response.ReasonPhrase);
        }

        public ResponseModel Update(WorkerDTO worker)
        {
            HttpClient httpClient = new HttpClient();
            string json = $"\'{JsonConvert.SerializeObject(worker)}\'";
            StringContent data = new(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PutAsync($"{Properties.Resources.ServiceWorkers}/{worker.UID}", data).Result;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new HttpResponseException() { ErrorModels = JsonConvert.DeserializeObject<List<ErrorModel>>(response.Content.ReadAsStringAsync().Result) };
            }

            return new ResponseModel(response.StatusCode, response.ReasonPhrase);
        }

        public ResponseModel Delete(Guid UID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Properties.Resources.ServiceWorkers}/{UID}");
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            ResponseModel responseModel = new ResponseModel(response.StatusCode, response.StatusDescription);
            response.Close();

            return responseModel;
        }

        public WorkerDTO Get(Guid UID)
        {
            WorkerDTO result;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Properties.Resources.ServiceWorkers}/{UID}");
            request.ContentType = "application/json";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string stringStream = streamReader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<WorkerDTO>(stringStream);
                }
            }
            else
            {
                result = new WorkerDTO();
            }


            return result;
        }
    }
}
