using System.Collections.Generic;
using System;
using DataLibrary.Models;
using DataLibrary.Interfaces;

namespace DataLibrary.Repositories
{
    /// <summary>
    /// Контекст случайно сгенерированных данных
    /// </summary>
    public class MockContext : IContext
    {
        public List<DivisionModel> Departments => _departments;
        public List<WorkerModel> Workers => _workers;

        static List<DivisionModel> _departments { get; set; }
        static List<WorkerModel> _workers { get; set; }
        private static readonly Random _random = new();

        static MockContext()
        {
            _departments = new List<DivisionModel>();
            _workers = new List<WorkerModel>();
            GenerateRandomRepository();
        }

        /// <summary>
        /// Генерирует случайные данные для объекта
        /// </summary>
        private static void GenerateRandomRepository()
        {

            // количество подразделений
            int countDepartment = _random.Next(1, 10);
            // глубина вложенности для подразделения
            int depthDepartment = _random.Next(1, 5);
            // количество сотрудников в подразделении
            int countWorkerInDepartment = _random.Next(3, 10);

            // Создание репозиторя верхнего уровня(Организация)
            DivisionModel mainDepartment = new()
            {
                Name = "Horns and Hooves",
                UID = Guid.NewGuid(),
                UIDParant = Guid.Empty,
                TypeModel = 201
            };

            // Создание департаментов
            for (int i = 0; i < countDepartment; i++)
            {
                DivisionModel department = new()
                {
                    UID = Guid.NewGuid(),
                    UIDParant = mainDepartment.UID,
                    Name = $"Имя_Департамента_{_random.Next()}",
                    TypeModel = 202
                };

                _departments.Add(department);

                // вызов рекурсивного метода для создания вложенных департаментов
                GenerationDepartment(depthDepartment, department.UID);
            }

            // Создание сотрудников для подразделений
            foreach (DivisionModel department in _departments)
            {
                for (int i = 0; i < countWorkerInDepartment; i++)
                {
                    WorkerModel worker = new()
                    {
                        Birthday = new DateTime(_random.Next(1980, DateTime.Now.Year - 18), _random.Next(1, 12), _random.Next(1, 28)),
                        Department = department.UID,
                        UID = Guid.NewGuid(),
                        Firstname = $"Имя_сотрудника_{_random.Next()}",
                        Lastname = $"Фамилия_сотрудника_{_random.Next()}",
                        PaymentRate = _random.Next(100, 30000),
                        WorkingTime = _random.Next(160, 200),
                    };

                    int TypeModel = _random.Next(101, 104);
                    worker.TypeModel = TypeModel;

                    _workers.Add(worker);
                }
            }

            _departments.Add(mainDepartment);

        }

        /// <summary>
        /// Рекрсиваня функция создания департаментов
        /// </summary>
        /// <param name="depth">глубина вложенности департаментов</param>
        /// <param name="guidDepartmentParant">Идентификатор родительского департамента</param>
        static void GenerationDepartment(int depth, Guid guidDepartmentParant)
        {
            if (depth <= 0) { return; }
            else
            {
                DivisionModel department = new()
                {
                    UID = Guid.NewGuid(),
                    UIDParant = guidDepartmentParant,
                    Name = $"Имя_Департамента_{_random.Next()}",
                    TypeModel = 202
                };
                _departments.Add(department);

                GenerationDepartment(--depth, department.UID);
            }
        }
    }
}
