using System;
using System.Collections.Generic;

namespace ConnectToControllerTier.Models.TreeDTO
{
    public class DivisionComponent
    {
        public Guid UID { get; set; }

        public TypeDivision TypeComponent { get; set; }

        public string Name { get; set; }

        public List<DivisionComponent> DivisionsDTO { get; set; }

        public List<WorkerComponent> WorkersDTO { get; set; }
    }
}
