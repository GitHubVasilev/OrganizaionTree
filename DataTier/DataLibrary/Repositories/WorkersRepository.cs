using DataLibrary.Interfaces;
using DataLibrary.Models;
using DataLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM_DataTier.Repositories
{
    /// <summary>
    /// Класс для работы с контекстом данных сотрудников
    /// </summary>
    public class WorkersRepository : IRepository<WorkerModel>
    {
        private readonly IContext context;

        public WorkersRepository(IContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Добавляет в контекст данных новую запись
        /// </summary>
        public void Create(WorkerModel item)
        {
            context.Workers.Add(item);
        }

        /// <summary>
        /// Удаляет первую найденную запись
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentOutOfRangeException">Если запись не найдена</exception>
        public void Delete(Guid item)
        {
            WorkerModel findModel = context.Workers.First(m => m.UID == item);

            if (findModel == null) { throw new ArgumentOutOfRangeException("Запись не найдена"); }

            context.Workers.Remove(findModel);
        }

        /// <summary>
        /// Возвращает первый найденный элемент в контексте данных
        /// </summary>
        /// <param name="UID">идентификатор модели в поле UID</param>
        /// <returns>Найденный элемент</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если запись с UID не найдена</exception>
        public WorkerModel Get(Guid UID)
        {
            WorkerModel findModel = context.Workers.First(m => m.UID == UID);

            return findModel ?? throw new ArgumentOutOfRangeException("Запись не найдена");
        }

        /// <summary>
        /// Получить все данные
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WorkerModel> GetAll()
        {
            return context.Workers;
        }

        /// <summary>
        /// Ищет запись в источнике данных и заменяет её
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentOutOfRangeException">Если запись не найдена</exception>
        public void Update(Guid UID, WorkerModel item)
        {
            int indexModel = context.Workers.FindIndex(m => m.UID == UID);

            if (indexModel == -1) { throw new ArgumentOutOfRangeException("Запись не найдена"); }

            context.Workers[indexModel] = item;
        }
    }
}
