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
    public class PropertyDivisionVM : BaseViewModel
    {
        private readonly IServiceDivisions _serviceDivision;

        public PropertyDivisionVM(IServiceDivisions service)
        {
            _serviceDivision = service;
            _division_VM = new();
        }

        private DivisionVM _division_VM;

        public DivisionVM Division_VM
        {
            get => _division_VM;
            set
            {
                _division_VM = value;
                OnPropertyChanged(nameof(Division_VM));
            }
        }

        private RelayCommand _searchAndSetModel;

        public RelayCommand SearchAndSetModel
        {
            get => _searchAndSetModel ?? (_searchAndSetModel = new RelayCommand(obj =>
            {
                Division_VM = new DivisionVM(_serviceDivision.Get(new Guid(obj.ToString())));
            }));
        }

        private RelayCommand _update;

        public RelayCommand Update
        {
            get => _update ?? (_update = new RelayCommand(obj =>
            {
                try
                {
                    _serviceDivision.Update(Division_VM.GetBaseModel());
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
            }, _ => !Division_VM.HasErrors));
        }
    }
}
