using System;


namespace ConnectToControllerTier.Models
{
    public class DivisionDTO
    {
        public Guid UID { get; set; }

        public TypeDivision TypeComponent { get; set; }

        public string Name { get; set; }

        public Guid UIDParant { get; set; }
    }
}
