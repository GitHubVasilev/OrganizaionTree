using ConnectToDataLibrary.Models;
using ControllerLibrary.Models.Divisions;
using ControllerLibrary.Models.Workers;
using System;

namespace ContollerLibrary.Infrastructure
{
    static class WorkerConverter
    {
        public static BaseWorker CreateComponent(WorkerModel model, BaseDivision parant) 
        {
            return (TypeComponent)model.TypeModel switch
            {
                TypeComponent.Intern => new Intern() 
                { UID = model.UID, PaymentRate = model.PaymentRate, Lastname = model.Lastname, Firstname = model.Firstname, Birthday = model.Birthday, ParantComponent = parant },
                TypeComponent.Manager => new Manager() 
                { UID = model.UID, PaymentRate = model.PaymentRate, Lastname = model.Lastname, Firstname = model.Firstname, Birthday = model.Birthday, ParantComponent = parant },
                TypeComponent.Worker => new Worker()
                { UID = model.UID, PaymentRate = model.PaymentRate, Lastname = model.Lastname, Firstname = model.Firstname, Birthday = model.Birthday, WorkingTime = model.WorkingTime, ParantComponent = parant },
                _ => throw new ArgumentException("Ошибка типа работника"),
            };
        }

        public static WorkerModel CreateModel(BaseWorker worker) 
        {
            return worker.TypeComponent switch
            {
                TypeComponent.Intern => new WorkerModel()
                { UID = worker.UID, Department = worker.ParantComponent.UID, Firstname = worker.Firstname, Lastname = worker.Lastname, Birthday = worker.Birthday, PaymentRate = worker.PaymentRate },
                TypeComponent.Manager => new WorkerModel()
                { UID = worker.UID, Department = worker.ParantComponent.UID, Firstname = worker.Firstname, Lastname = worker.Lastname, Birthday = worker.Birthday, PaymentRate = worker.PaymentRate },
                TypeComponent.Worker => new WorkerModel()
                {
                    UID = worker.UID,
                    Department = worker.ParantComponent.UID, 
                    Firstname = worker.Firstname, 
                    Lastname = worker.Lastname, 
                    Birthday = worker.Birthday,
                    PaymentRate = worker.PaymentRate,
                    WorkingTime = (worker as Worker).WorkingTime
                },
                _ => throw new ArgumentException("Ошибка типа работника"),
            };
        }
    }
}
