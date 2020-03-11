using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Resources;
using System.Windows.Documents;
using Prism.Commands;
using Prism.Mvvm;
using TestTask1.Models;

namespace TestTask1.ViewModels
{
    class MainViewModel : BindableBase
    {
        private ObservableCollection<Asset> _assets;
        private int _selectedTab;
        private int _assetType;
        private Money _editingMoney;
        private Building _editingBuilding;
        private Asset _editingOther;
        private int _selectedAssetIndex;
        public DelegateCommand AddCommand { get; set; }
        public DelegateCommand EditCommand { get; set; }
        public DelegateCommand DeleteCommand { get; set; }

        public ObservableCollection<Asset> Assets
        {
            get => _assets;
            set
            {
                _assets = value;
                RaisePropertyChanged("Assets");
            }
        }

        public Money EditingMoney
        {
            get => _editingMoney;
            set
            {
                _editingMoney = value;
                RaisePropertyChanged("EditingMoney");
            }
        }

        public Building EditingBuilding
        {
            get => _editingBuilding;
            set
            {
                _editingBuilding = value;
                RaisePropertyChanged("EditingBuilding");
            }
        }

        public Asset EditingOther
        {
            get => _editingOther;
            set
            {
                _editingOther = value;
                RaisePropertyChanged("EditingOther");
            }
        }


        public DelegateCommand AddAssetCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public int AssetType
        {
            get => _assetType;
            set
            {
                _assetType = value;
                RaisePropertyChanged("AssetType");
            }
        }

        public int SelectedTab
        {
            get => _selectedTab;
            set
            {
                _selectedTab = value;
                RaisePropertyChanged("SelectedTab");
            }
        }

        public int SelectedAssetIndex
        {
            get => _selectedAssetIndex;
            set
            {
                _selectedAssetIndex = value;
                RaisePropertyChanged();
            }
        }

        public MainViewModel()
        {
            Assets = new ObservableCollection<Asset>
            {
                new Money("Счет 5") {Mount = 5, Currency = "Euro", IsSaved = true},
                new Money("Счет 2") {Mount = 2225, Currency = "Rub"},
                new Money("Счет 35") {Mount = 35, Currency = "Euro"},
                new Money("Счет 52") {Mount = 5, Currency = "Euro"},
                new Money("Счет 15") {Mount = 655, Currency = "Dollar"},
                new Money("Счет 52") {Mount = 335, Currency = "Euro"},
                new Unreliabe("Гвозди") {AssessedValue = 1, InventoryNumber = 123, ResidualValue = 5, StartMount = 6},
                new Building("дом1") {Address = "Пушкина", ResidualValue = 0, AssessedValue = 1},
                new Money("счет 5") {Mount = 5, Currency = "Dollar", BankName = "EuroBank"}
            };


            EditingMoney = new Money("money");
            EditingBuilding = new Building("ул Пушкина дом Колотушкина");
            EditingOther = new Asset();


            AddAssetCommand = new DelegateCommand(() =>
            {
                switch ((AssetTypes) AssetType)
                {
                    case AssetTypes.Money:
                        if (EditingMoney.IsSaved)
                        {
                            RaisePropertyChanged("EditingMoney");
                            break;
                        }

                        var money = new Money(EditingMoney.Name)
                        {
                            IsSaved = true,
                            BankName = EditingMoney.BankName,
                            Name = EditingMoney.Name,
                            Currency = EditingMoney.Currency, Mount = EditingMoney.Mount
                        };
                        Assets.Add(money);
                        break;
                    case AssetTypes.Buildings:
                        var building = new Unreliabe(EditingBuilding.Name)
                        {
                            IsSaved = true,
                            BankName = EditingBuilding.BankName,
                            Name = EditingBuilding.Name,
                            AssessedValue = EditingBuilding.AssessedValue,
                            ResidualValue = EditingBuilding.ResidualValue,
                        };
                        Assets.Add(building);
                        break;
                    case AssetTypes.Other:
                        var other = new Asset()
                        {
                            IsSaved = true,
                            BankName = EditingOther.BankName,
                            Name = EditingOther.Name,
                            Value = EditingOther.Value
                        };
                        Assets.Add(other);
                        break;
                    default:
                        break;
                }
            });

            DeleteCommand = new DelegateCommand(() => { Assets.RemoveAt(SelectedAssetIndex); });

            EditCommand = new DelegateCommand(() =>
            {
                var selectedIndex = SelectedAssetIndex;
                var asset = Assets.ElementAt(selectedIndex);
                Assets.Remove(asset);

                switch (asset)
                {
                    case Money money:
                        money.Name = EditingMoney.Name;
                        money.Currency = EditingMoney.Currency;
                        money.Mount = EditingMoney.Mount;
                        money.BankName = EditingMoney.BankName;
                        Assets.Insert(selectedIndex, money);

                        break;
                    case Building building:
                        building.Name = EditingBuilding.Name;
                        building.Address = EditingBuilding.Address;
                        building.ResidualValue = EditingBuilding.ResidualValue;
                        building.AssessedValue = EditingBuilding.AssessedValue;
                        building.BankName = EditingBuilding.BankName;
                        Assets.Insert(selectedIndex, EditingBuilding);
                        break;
                }

                RaisePropertyChanged("Assets");
                Assets = Assets;
            });
        }
    }
}