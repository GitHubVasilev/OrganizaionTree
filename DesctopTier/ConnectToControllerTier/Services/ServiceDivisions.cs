using ConnectToControllerTier.Errors;
using ConnectToControllerTier.Interfaces;
using ConnectToControllerTier.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace ConnectToControllerTier.Services
{
    public class ServiceDivisions : IServiceDivisions
    {
        public ResponseModel Create(DivisionDTO division)
        {
            HttpClient httpClient = new();
            string json = $"\'{JsonConvert.SerializeObject(division)}\'";
            StringContent data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = httpClient.PostAsync($"{Properties.Resources.ServiceDivisions}", data).Result;

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new HttpResponseException() { ErrorModels = JsonConvert.DeserializeObject<List<ErrorModel>>(response.Content.ReadAsStringAsync().Result) };
            }

            return new ResponseModel(response.StatusCode, response.ReasonPhrase);
        }

        public ResponseModel Update(DivisionDTO division)
        {
            HttpClient httpClient = new();
            string json = $"\'{JsonConvert.SerializeObject(division)}\'";
            StringContent data = new(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync($"{Properties.Resources.ServiceDivisions}/{division.UID}", data).Result;

            if (response.StatusCode == HttpStatusCode.BadRequest) 
            {
                throw new HttpResponseException() { ErrorModels=JsonConvert.DeserializeObject<List<ErrorModel>>(response.Content.ReadAsStringAsync().Result) };
            }

            return new ResponseModel(response.StatusCode, response.ReasonPhrase);
        }

        public ResponseModel Delete(Guid UID)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Properties.Resources.ServiceDivisions}/{UID}");
            request.Method = "DELETE";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            ResponseModel modelResponse = new(response.StatusCode, response.StatusDescription);
            response.Close();

            return modelResponse;

        }

        public DivisionDTO Get(Guid UID)
        {
            DivisionDTO result;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Properties.Resources.ServiceDivisions}/{UID}");
            request.ContentType = "application/json";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string stringStream = streamReader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<DivisionDTO>(stringStream);
                }
            }
            else
            {
                result = new DivisionDTO();
            }

            return result;
        }
    }
}
