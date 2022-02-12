using ConnectToDataLibrary.Models;
using ContollerLibrary.Interfaces;
using System;

namespace ControllerLibrary.Models.Workers
{
    /// <summary>
    /// Класс базового представления Сотрудника
    /// </summary>
    public abstract class BaseWorker : IComponentOrganization
    {

        public BaseWorker()
        {
            UID = new Guid();
        }
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        public Guid UID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthday { get; set; }
        public decimal PaymentRate { get; set; }
        public decimal Salary { get => CalculationSalary(); }
        public IComponentOrganization ParantComponent { get; set; }
        public TypeComponent TypeComponent { get; protected set; }
        public bool IsComposite => false;

        /// <summary>
        /// Метод расчета заработной платы
        /// </summary>
        /// <returns></returns>
        protected abstract decimal CalculationSalary();

        public void Add(IComponentOrganization component)
        {
            throw new NotImplementedException();
        }

        public void Remove(IComponentOrganization component)
        {
            throw new NotImplementedException();
        }
    }
}
