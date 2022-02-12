using ConnectToControllerTier.Errors;
using ConnectToControllerTier.Interfaces;
using ConnectToControllerTier.Models;
using System;
using System.Text;
using System.Windows;
using View_WPF.Infrastructure;
using View_WPF.ViewModels.Base;
using View_WPF.ViewModels.DTOVM;

namespace View_WPF.ViewModels
{
    public class CreateDivisionVM : BaseViewModel
    {
        private readonly IServiceDivisions _serviceDivisions;

        public CreateDivisionVM(IServiceDivisions serviceDivisions)
        {
            _serviceDivisions = serviceDivisions;
            DivisionViewModel = new();
        }

        private DivisionVM _divisionVM;

        public DivisionVM DivisionViewModel
        {
            get => _divisionVM;
            set
            {
                _divisionVM = value;
                _divisionVM.UID = Guid.NewGuid();
                OnPropertyChanged(nameof(DivisionViewModel));
            }
        }

        private RelayCommand _setUIDParantComponent;

        public RelayCommand SetUIDParantComponent
        {
            get => _setUIDParantComponent ??= new RelayCommand(obj =>
             {
                 if (obj == null)
                 {
                     DivisionViewModel.UIDParant = Guid.Empty;
                     return;
                 }
                 DivisionViewModel.UIDParant = (Guid)obj;
             });
        }

        private RelayCommand _createDivision;

        public RelayCommand CreateDivision 
        {
            get => _createDivision ?? (_createDivision = new RelayCommand(obj => 
            {
                try
                {
                    _serviceDivisions.Create(DivisionViewModel.GetBaseModel());
                }
                catch (HttpResponseException ex)
                {
                    StringBuilder messageError = new();

                    foreach (ErrorModel model in ex.ErrorModels)
                    {
                        messageError.Append($"{model.MemberName} : {model.Message}\n");
                    }

                    MessageBox.Show(messageError.ToString(), ex.GetType().ToString(),  MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }, _ => !DivisionViewModel.HasErrors));
        }
    }
}
