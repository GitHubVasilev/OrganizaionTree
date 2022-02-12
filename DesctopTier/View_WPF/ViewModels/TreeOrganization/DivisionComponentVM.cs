using ConnectToControllerTier.Models;
using ConnectToControllerTier.Models.TreeDTO;
using System;
using System.Collections.ObjectModel;
using View_WPF.Interfaces;
using View_WPF.ViewModels.Base;

namespace View_WPF.ViewModels.TreeOrganization
{
    public class DivisionComponentVM : BaseViewModel, IComponentVM
    {
        private DivisionComponent _model;

        public DivisionComponentVM(DivisionComponent model)
        {
            _model = model ?? new();
            Update();
        }

        private void Update() 
        {
            Components = new ObservableCollection<IComponentVM>();
            SubDivisions = new ObservableCollection<DivisionComponentVM>();

            foreach (DivisionComponent division in _model.DivisionsDTO) 
            {
                IComponentVM component = new DivisionComponentVM(division);
                SubDivisions.Add(component as DivisionComponentVM);
                Components.Add(component);
            }
            foreach (WorkerComponent worker in _model.WorkersDTO) 
            {
                Components.Add(new WorkerComponentVM(worker));
            }

            OnPropertyChanged(nameof(Components));
            OnPropertyChanged(nameof(SubDivisions));
        }

        public DivisionComponent GetBaseModel() => _model;

        public Guid UID
        {
            get => _model.UID;
            set
            {
                _model.UID = value;
                OnPropertyChanged(nameof(UID));
            }
        }

        public int TypeComponent
        {
            get => (int)_model.TypeComponent;
            set
            {
                _model.TypeComponent = (TypeDivision)value;
                OnPropertyChanged(nameof(TypeComponent));
            }
        }

        public string Name
        {
            get => _model.Name;
            set
            {
                _model.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public bool IsComposite => true;

        private ObservableCollection<IComponentVM> _components;

        public ObservableCollection<IComponentVM> Components 
        {
            get => _components;
            set 
            {
                _components = value;
                OnPropertyChanged(nameof(Components));
            }
        }

        private ObservableCollection<DivisionComponentVM> _subDivisions;
        public ObservableCollection<DivisionComponentVM> SubDivisions
        {
            get => _subDivisions;
            set
            {
                _subDivisions = value;
                OnPropertyChanged(nameof(SubDivisions));
            }
        }
    }
}
