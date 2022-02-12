using DataLibrary.Interfaces;
using DataLibrary.Models;
using DataLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM_DataTier.Repositories
{
    /// <summary>
    /// Класс для работы с контекстом данных департаментов
    /// </summary>
    public class DivisionRepository : IRepository<DivisionModel>
    {
        private readonly IContext context;

        public DivisionRepository(IContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Добавляет в контекст данных новую запись
        /// </summary>
        public void Create(DivisionModel item)
        {
            context.Departments.Add(item);
        }

        /// <summary>
        /// Удаляет элемент первый найденный элемент из контекста данных. 
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentOutOfRangeException">Если запись не найдена</exception>
        public void Delete(Guid item)
        {
            DivisionModel findModel = context.Departments.First(m => m.UID == item);

            if (findModel == null) { throw new ArgumentOutOfRangeException("Запись не найдена"); }

            context.Departments.Remove(findModel);

        }

        /// <summary>
        /// Возвращает первый найденный элемент в контексте данных
        /// </summary>
        /// <param name="UID">идентификатор модели в поле UID</param>
        /// <returns>Найденный элемент</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если запись с UID не найдена</exception>
        public DivisionModel Get(Guid UID)
        {
            DivisionModel findModel = context.Departments.First(m => m.UID == UID);

            return findModel ?? throw new ArgumentOutOfRangeException("Запись не найдена");
        }

        /// <summary>
        /// Получить все данные
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DivisionModel> GetAll()
        {
            return context.Departments;
        }

        /// <summary>
        /// Ищет запись в источнике данных и заменяет её
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentOutOfRangeException">Если запись не найдена</exception>
        public void Update(Guid UID, DivisionModel item)
        {
            int indexModel = context.Departments.FindIndex(m => m.UID == UID);

            if (indexModel == -1) { throw new ArgumentOutOfRangeException("Запись не найдена"); }

            context.Departments[indexModel] = item;
        }
    }
}
