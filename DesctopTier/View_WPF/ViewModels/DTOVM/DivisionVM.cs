using ConnectToControllerTier.Models;
using System;
using System.ComponentModel.DataAnnotations;
using View_WPF.ViewModels.Base;

namespace View_WPF.ViewModels.DTOVM
{
    public class DivisionVM : ValidationBaseViewModel
    {
        public DivisionVM(DivisionDTO model = null)
        {
            DivisionDTO _model = model ?? new();
            UID = _model.UID;
            Name = _model.Name;
            TypeComponent = (int)_model.TypeComponent;
            UIDParant = _model.UIDParant;
        }

        public DivisionDTO GetBaseModel()
        {
            DivisionDTO model = new DivisionDTO();
            model.UID = UID;
            model.UIDParant = UIDParant;
            model.Name = Name;
            model.TypeComponent = (TypeDivision)TypeComponent;
            return model;
        }

        private Guid _uid;

        public Guid UID
        {
            get => _uid;
            set => Set(ref _uid, value);
        }

        private int _typeComponent;

        public int TypeComponent
        {
            get => _typeComponent;
            set => Set(ref _typeComponent, value);
        }

        private string _name;

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }

        private Guid _uidParant;

        public Guid UIDParant
        {
            get => _uidParant;
            set => Set(ref _uidParant, value);
        }
    }
}
