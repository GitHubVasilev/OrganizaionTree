using System;

namespace ConnectToControllerTier.Models
{
    public class WorkerDTO
    {
        public Guid UID { get; set; }

        public TypeWorker TypeComponent { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public DateTime Birthday { get; set; }

        public decimal PaymentRate { get; set; }

        public Guid Department { get; set; }
    }
}
