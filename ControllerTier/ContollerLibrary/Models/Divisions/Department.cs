

namespace ControllerLibrary.Models.Divisions
{
    public class Department: BaseDivision
    {
        public Department() : base()
        {
            TypeComponent = ConnectToDataLibrary.Models.TypeComponent.Department;
        }
    }
}
