using ContollerLibrary.Interfaces;
using ControllerLibrary.Models.Divisions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CRM_Controller.Models.Divisions
{
    public class TreeOrganization : ITree
    {
        public List<IComponentOrganization> ComponentsOrganization { get; }

        public TreeOrganization()
        {
            ComponentsOrganization = new List<IComponentOrganization>();
        }

        /// <summary>
        /// Производит поиск по дереву по UID
        /// </summary>
        /// <param name="UID">Идентификационный номер искомого элемента</param>
        /// <returns>Найденный компонент дерева. Если Компонент не найден, вовзращает значение по-умолчанию для данного типа</returns>
        public IComponentOrganization Search(Guid UID)
        {
            Stack<BaseDivision> stackComponents = new();
            IComponentOrganization foundComponent;

            foundComponent = ComponentsOrganization.Find(m => m.UID == UID);
            if (foundComponent != default) return foundComponent;

            foreach (BaseDivision component in ComponentsOrganization.Where(m => m.IsComposite)) 
            {
                stackComponents.Push(component);
            }

            while (stackComponents.Count > 0) 
            {
                BaseDivision currentComponent = stackComponents.Pop();

                foundComponent = currentComponent.ComponentsOrganization.Find(m => m.UID == UID);
                if (foundComponent != null) return foundComponent;

                foreach (BaseDivision component in currentComponent.ComponentsOrganization.Where(m => m.IsComposite))
                {
                    stackComponents.Push(component);
                }
            }
            return default;
        }

    }
}
