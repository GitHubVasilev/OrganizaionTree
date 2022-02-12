using ConnectToControllerTier.Interfaces;
using ConnectToControllerTier.Models.TreeDTO;
using ConnectToControllerTier.Properties;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace ConnectToControllerTier.Services
{
    public class ServiceOrganization : IServiceOrganization
    {

        public TreeOrganizationDTO GetTree() 
        {
            TreeOrganizationDTO result;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"{Resources.ServiceOrganization}");
            request.ContentType = "application/json";
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    string stringStream = streamReader.ReadToEnd();
                    result = JsonConvert.DeserializeObject<TreeOrganizationDTO>(stringStream);
                }
            }
            else 
            {
                result = new TreeOrganizationDTO();
            }

            return result;
        }
    }
}
