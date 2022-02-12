
namespace ControllerLibrary.Models.Workers
{
    /// <summary>
    /// Класс интерна
    /// </summary>
    public class Intern : BaseWorker
    {
        public Intern() : base()
        {
            TypeComponent = ConnectToDataLibrary.Models.TypeComponent.Intern;
        }

        protected override decimal CalculationSalary()
        {
            return PaymentRate;
        }
    }
}
