using ConnectToDataLibrary.Models;
using ContollerLibrary.Interfaces;
using ControllerLibrary.Models.Workers;
using ServiceController.Models.TreeDTO;
using System;

namespace ServiceController.Fuctories
{
    public class WorkerFactory
    {
        public WorkerDTO CreateViewModel(BaseWorker model) 
        {
            return new WorkerDTO
            {
                UID = model.UID,
                Salary = model.Salary,
                TypeComponent = model.TypeComponent,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Birthday = model.Birthday,
                PaymentRate = model.PaymentRate,
            };
        }
        public IComponentOrganization CreateModel(WorkerDTO dto) 
        {
            switch (dto.TypeComponent) 
            {
                case TypeComponent.Worker:
                    return new Worker()
                    {
                        UID = dto.UID,
                        Firstname = dto.Firstname,
                        Lastname = dto.Lastname,
                        Birthday = dto.Birthday,
                        PaymentRate = dto.PaymentRate
                    };
                case TypeComponent.Intern:
                    return new Intern()
                    {
                        UID = dto.UID,
                        Firstname = dto.Firstname,
                        Lastname = dto.Lastname,
                        Birthday = dto.Birthday,
                        PaymentRate = dto.PaymentRate
                    };
                case TypeComponent.Manager:
                    return new Intern()
                    {
                        UID = dto.UID,
                        Firstname = dto.Firstname,
                        Lastname = dto.Lastname,
                        Birthday = dto.Birthday,
                        PaymentRate = dto.PaymentRate
                    };
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
