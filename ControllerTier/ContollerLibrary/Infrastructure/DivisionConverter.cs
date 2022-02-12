using ConnectToDataLibrary.Models;
using ControllerLibrary.Models.Divisions;
using System;


namespace ContollerLibrary.Infrastructure
{
    static class DivisionConverter
    {
        public static BaseDivision CreateComponent(DivisionModel model, BaseDivision parant)  
        {
            return (TypeComponent)model.TypeModel switch
            {
                TypeComponent.Department => new Department()
                { Name = model.Name, UID = model.UID, ParantComponent = parant },
                TypeComponent.Institution => new Institution()
                { Name = model.Name, UID = model.UID, ParantComponent = parant },
                _ => throw new ArgumentException("Ошибка типа подразделения"),
            };
        }
        public static DivisionModel CreateModel(BaseDivision model) 
        {
            return model.TypeComponent switch
            {
                TypeComponent.Department => new DivisionModel()
                { UID = model.UID, Name = model.Name, TypeModel = (int)model.TypeComponent, UIDParant = model.ParantComponent.UID },
                TypeComponent.Institution => new DivisionModel()
                { UID = model.UID, Name = model.Name, TypeModel = (int)model.TypeComponent, UIDParant = model.ParantComponent.UID },
                _ => throw new ArgumentException("Ошибка типа подразделения"),
            };
        }
    }
}
