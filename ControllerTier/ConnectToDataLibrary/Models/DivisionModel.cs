﻿using System;

namespace ConnectToDataLibrary.Models
{
    /// <summary>
    /// Модель подразделения
    /// </summary>
    public class DivisionModel
    {
        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        public Guid UID { get; set; }

        /// <summary>
        /// Идентификатор родительского подразделения
        /// </summary>
        public Guid UIDParant { get; set; }

        /// <summary>
        /// Название подразделения
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип модели для определения в контроллере
        /// </summary>
        public int TypeModel {get;set;}
    }
}
