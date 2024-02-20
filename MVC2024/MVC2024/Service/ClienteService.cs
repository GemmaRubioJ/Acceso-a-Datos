using MVC2024.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml.Linq;


namespace MVC2024.Service

{
    public class ClienteService
    {
        public List<ClienteModelo> ParseJson(string jsonData)
        {
            return JsonConvert.DeserializeObject<List<ClienteModelo>>(jsonData);
        
        }
    }
}

