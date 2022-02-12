using System;

namespace ConnectToControllerTier.Models.TreeDTO
{
    public class WorkerComponent
    {
        public Guid UID { get; set; }

        public decimal Salary { get; set; }

        public TypeWorker TypeComponent { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }

        public decimal PaymentRate { get; set; }
    }
}
