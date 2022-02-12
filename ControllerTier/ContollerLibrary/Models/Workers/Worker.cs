
namespace ControllerLibrary.Models.Workers
{
    /// <summary>
    /// класс Рабочего
    /// </summary>
    public class Worker : BaseWorker
    {
        /// <summary>
        /// Рабочие время работника
        /// </summary>
        public int WorkingTime { get; set; }

        public Worker() : base()
        {
            TypeComponent = ConnectToDataLibrary.Models.TypeComponent.Worker;
        }

        /// <summary>
        /// Рассчитывает заработную плату
        /// </summary>
        /// <returns>заработная плата</returns>
        protected override decimal CalculationSalary()
        {
            return PaymentRate * WorkingTime;
        }
    }
}
