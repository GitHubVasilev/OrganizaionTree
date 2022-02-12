using ConnectToDataLibrary.Models;
using System;
using System.Collections.Generic;

namespace ServiceController.Models.TreeDTO
{
    public class DivisionDTO
    {
        public DivisionDTO()
        {
            DivisionsDTO = new List<DivisionDTO>();
            WorkersDTO = new List<WorkerDTO>();
        }

        public Guid UID { get; set; }

        public TypeComponent TypeComponent { get; set; }

        public string Name { get; set; }

        public List<DivisionDTO> DivisionsDTO { get; set; }

        public List<WorkerDTO> WorkersDTO { get; set; }
    }
}
