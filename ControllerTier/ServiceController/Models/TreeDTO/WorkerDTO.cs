using ConnectToDataLibrary.Models;
using System;

namespace ServiceController.Models.TreeDTO
{
    public class WorkerDTO
    {
        public Guid UID { get; set; }

        public decimal Salary { get; set; }

        public TypeComponent TypeComponent { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }

        public decimal PaymentRate { get; set; }
    }
}
