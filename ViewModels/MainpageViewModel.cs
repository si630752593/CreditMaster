using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CreditMaster.Services;
using System.Data.SqlTypes;
using CommunityToolkit.Mvvm.Collections;
using System.Collections.ObjectModel;
using CreditMaster.Models;
using System.Linq.Expressions;

namespace CreditMaster.ViewModels
{
    public partial class MainpageViewModel : ObservableObject
    {
        private IAcstuentStorage _AcstuentStorage;
        private ITokenService _TokenService;
        public MainpageViewModel(ITokenService tokenService)
        {
            _TokenService = tokenService;
        }

        public MainpageViewModel(IAcstuentStorage acstuentStorage)
        {
            _AcstuentStorage = acstuentStorage;
        }
        public ObservableCollection<Acstudent> Acstuents { get; } =new ();

        public ObservableCollection<Acstudent> Acstuents2 =
            new ObservableCollection<Acstudent>(); //每次都会拿到新的对象

        private RelayCommand _initalizecommand;
        public RelayCommand InitalizeCommand =>
           _initalizecommand ??= new RelayCommand( execute: async () => {
               await _AcstuentStorage.Intialize(); });

        private RelayCommand _addcommand;
        public RelayCommand AddCommand =>
           _addcommand ??= new RelayCommand(execute: async () => {
              await _AcstuentStorage.AddAsync(new Acstudent {
                    acName = "sadsd",
              });
           });

        private RelayCommand _listcommand;
        public RelayCommand ListCommand =>
           _listcommand ??= new RelayCommand(execute: async () => {
            var list = await _AcstuentStorage.ListAsync();
            foreach (var item in list) {
                   Acstuents.Add(item);
               }
           });

        private string _json;
        public string Json {
            get => _json;
            set => SetProperty(ref _json, value);
        }

        private RelayCommand _loadJson;

        public RelayCommand LoadJson => _loadJson ??= new RelayCommand(execute: async () =>
        {
            Json = await _TokenService.GetTokenAsync();
        });

        public Expression<Func <Acstudent, bool>> Where  
        {
            get => _where;
            set => SetProperty{ref _where, value };
        }
    }
}
 