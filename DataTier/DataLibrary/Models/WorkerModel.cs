using System;

namespace DataLibrary.Models
{
    /// <summary>
    /// Модель сотрудника
    /// </summary>
    public class WorkerModel
    {
        /// <summary>
        /// Идентификатор работника
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// Идентификатор отдела к которому прикреплен сотрудник
        /// </summary>
        public Guid Department { get; set; }

        /// <summary>
        /// Оклад
        /// </summary>
        public decimal PaymentRate { get; set; }

        /// <summary>
        /// Отработанное время
        /// </summary>
        public int WorkingTime { get; set; }

        /// <summary>
        /// Тип модели для определения в контроллере
        /// </summary>
        public int TypeModel { get; set; }
    }
}
