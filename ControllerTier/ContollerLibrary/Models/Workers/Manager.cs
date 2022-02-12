using ControllerLibrary.Models.Divisions;
using System.Collections.Generic;
using ConnectToDataLibrary.Models;
using System.Linq;

namespace ControllerLibrary.Models.Workers
{
    /// <summary>
    /// класс Руководителя
    /// </summary>
    public class Manager : BaseWorker
    {
        private readonly decimal percentOfSumSalary;

        public Manager() : base()
        {
            this.percentOfSumSalary = 0.15M;
            TypeComponent = TypeComponent.Manager;
        }

        /// <summary>
        /// Расчитывает зароботную плату
        /// </summary>
        /// <returns>
        ///     заработная плата - процент от зарплат всех сотрудников(исключая руководителей) во всех вложенных подразделениях
        ///     если этот процент меньше, то вовзарает минимальный оклад (PaymentRate)
        /// </returns>
        protected override decimal CalculationSalary()
        {
            // счетчик зарплат всех подчиненных
            decimal sumSalary = 0;

            // стек вложенных подразделений
            Stack<BaseDivision> stackDepartments = new Stack<BaseDivision>();

            // давление в стек департамента в котором находится руководитель
            stackDepartments.Push(ParantComponent as BaseDivision);

            // обход стека
            while (stackDepartments.Count > 0)
            {
                // извлекает из стека подразделение
                BaseDivision currentDepartment = stackDepartments.Pop();

                // проверка подразделение на корректность данных
                if (!IsValidDivision(currentDepartment)) continue;

                foreach (BaseWorker worker in currentDepartment.ComponentsOrganization.Where(m => !m.IsComposite))
                {
                    if (worker.TypeComponent != TypeComponent.Manager)
                    {
                        // если элемент - это работник(не руководитель), то добавляет его зарплату к сумме зарплат
                        sumSalary += worker.Salary;
                    }
                }

                foreach (BaseDivision division in currentDepartment.ComponentsOrganization.Where(m => m.IsComposite)) 
                {
                    // если элемент - это подразделение, то добавляет его в стек
                    stackDepartments.Push(division);
                }

            }

            decimal result = sumSalary * percentOfSumSalary;

            // Если процент от всех зарплат меньше минимального оклада, то вовзращает минимальный оклад
            return result > PaymentRate ? result : PaymentRate;
        }

        /// <summary>
        /// Метод определяет, корректны ли данные в департамете для расчета зарплаты
        /// </summary>
        /// <param name="department">департамент для проверки</param>
        /// <returns></returns>
        private bool IsValidDivision(BaseDivision department)
        {
            if (department == null) return false;
            return true;
        }
    }
}
