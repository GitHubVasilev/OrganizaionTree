using ConnectToControllerTier.Models.TreeDTO;
using System.Collections.ObjectModel;
using View_WPF.Interfaces;
using View_WPF.ViewModels.Base;

namespace View_WPF.ViewModels.TreeOrganization
{
    public class TreeOrganiztionVM : BaseViewModel
    {
        private TreeOrganizationDTO _model;

        public TreeOrganiztionVM(TreeOrganizationDTO model = null)
        {
            _model = model ?? new();
            Update();
        }

        private void Update()
        {
            Components = new ObservableCollection<IComponentVM>();
            SubDivisions = new ObservableCollection<DivisionComponentVM>();

            foreach (DivisionComponent division in _model.DivisionComponents)
            {
                IComponentVM component = new DivisionComponentVM(division);
                SubDivisions.Add(component as DivisionComponentVM);
                Components.Add(component);
            }
            foreach (WorkerComponent worker in _model.WorkerComponents)
            {
                Components.Add(new WorkerComponentVM(worker));
            }

            OnPropertyChanged(nameof(Components));
            OnPropertyChanged(nameof(SubDivisions));
        }
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
