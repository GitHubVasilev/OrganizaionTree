

namespace ControllerLibrary.Models.Divisions
{
    public class Institution : BaseDivision
    {
        public Institution() : base()
        {
            TypeComponent = ConnectToDataLibrary.Models.TypeComponent.Institution;
        }
    }
}
