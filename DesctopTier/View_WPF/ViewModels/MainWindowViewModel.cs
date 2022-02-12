using ConnectToControllerTier.Interfaces;
using ConnectToControllerTier.Models;
using System;
using System.Windows;
using View_WPF.Infrastructure;
using View_WPF.Interfaces;
using View_WPF.ViewModels.Base;
using View_WPF.ViewModels.TreeOrganization;

namespace View_WPF.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IServiceDivisions _serviceDivisions;
        private readonly IServiceWorkers _serviceWorkers;
        private readonly IServiceOrganization _serviceOrganization;
        private readonly IDialogs _dialogs;

        public MainWindowViewModel(IServiceOrganization serviceOrganization, IServiceDivisions serviceDivisions, IServiceWorkers serviceWorkers, IDialogs dialogs)
        {
            _serviceOrganization = serviceOrganization;
            _serviceDivisions = serviceDivisions;
            _serviceWorkers = serviceWorkers;
            _dialogs = dialogs;
            UpdateTree();
        }

        private string _title;

        public string Title 
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private IComponentVM _selectedItemInTree;

        public IComponentVM SelectedItemInTree 
        {
            get => _selectedItemInTree;
            set
            {
                _selectedItemInTree = value;
                if (_selectedItemInTree != null) { Title = _selectedItemInTree.Name; }
                OnPropertyChanged(nameof(SelectedItemInTree));
            }
        }

        private TreeOrganiztionVM _tree;

        public TreeOrganiztionVM Tree
        {
            get => _tree;
            set
            {
                _tree = value;
                OnPropertyChanged(nameof(Tree));
            }
        }

        private IComponentVM _selectedComponentInDivision;

        public IComponentVM SelectedComponentInDivision
        {
            get => _selectedComponentInDivision;
            set
            {
                _selectedComponentInDivision = value;
                OnPropertyChanged(nameof(SelectedItemInTree));
            }
        }

        private RelayCommand _deleteComponent;
        
        public RelayCommand DeleteComponent 
        {
            get => _deleteComponent ?? (_deleteComponent = new RelayCommand(obj =>
                 {
                     string caption = "Внимание";
                     string text = "Вы действительно хотите удалить элемент?";
                     MessageBoxResult messageBox = MessageBox.Show(text, caption, MessageBoxButton.YesNo, MessageBoxImage.Warning);
                     if (messageBox == MessageBoxResult.Yes)
                     {
                         if (SelectedComponentInDivision.GetType().Name.Equals(nameof(DivisionComponentVM)))
                         {
                             ResponseModel response = _serviceDivisions.Delete(SelectedComponentInDivision.UID);

                             if (response.CodeResponse != System.Net.HttpStatusCode.OK)
                             {
                                 MessageBox.Show(
                                     response.DescriptionResponse,
                                     response.CodeResponse.ToString(),
                                     MessageBoxButton.OK,
                                     MessageBoxImage.Information);
                             }
                         }
                         else if (SelectedComponentInDivision.GetType().Name.Equals(nameof(WorkerComponentVM)))
                         {
                             ResponseModel response = _serviceWorkers.Delete(SelectedComponentInDivision.UID);
                             if (response.CodeResponse != System.Net.HttpStatusCode.OK) 
                             {
                                 MessageBox.Show(
                                     response.DescriptionResponse, 
                                     response.CodeResponse.ToString(),
                                     MessageBoxButton.OK,
                                     MessageBoxImage.Information);
                             }
                         }
                         UpdateTree();
                     }
                 }));
        }

        private RelayCommand _contextMenuDataGrid;

        public RelayCommand ContextMenuDataGrid
        {
            get => _contextMenuDataGrid ?? (_contextMenuDataGrid = new RelayCommand(obj =>
            {
                IDialog dialog;
                if (SelectedComponentInDivision.GetType() == typeof(WorkerComponentVM))
                {
                    dialog = _dialogs.GetDialogPropertyWorker();
                }
                else if (SelectedComponentInDivision.GetType() == typeof(DivisionComponentVM))
                {
                    dialog = _dialogs.GetDialogPropertyDivision();
                }
                else 
                {
                    throw new NotImplementedException("Не выбрано диалоговое окно");
                }

                dialog.OpenWindow();

                if (dialog.ResultDialog) { UpdateTree(); }
            }));
        }

        private RelayCommand _addWorker;

        public RelayCommand AddWorker 
        {
            get => _addWorker ??= new RelayCommand(obj =>
                {
                    IDialog dialog = _dialogs.GetDialogCreateWorker();
                    dialog.OpenWindow();
                    if (dialog.ResultDialog) { UpdateTree(); }
                });
        }

        private RelayCommand _addDivision;

        public RelayCommand AddDivision
        {
            get => _addDivision ??= new RelayCommand(obj =>
            {
                IDialog dialog = _dialogs.GetDialogCreateDivision();
                dialog.OpenWindow();

                if (dialog.ResultDialog) { UpdateTree(); }
            });
        }

        private void UpdateTree()
        {
            Tree = new TreeOrganiztionVM(_serviceOrganization.GetTree());
            SelectedItemInTree = Tree.Components[0];
            SelectedComponentInDivision = Tree.Components[0];
            Title = Tree.Components[0].Name;
        }
    }
}