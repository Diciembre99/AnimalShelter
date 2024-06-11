using AnimalShelter.Controllers.Data;
using AnimalShelter.Views.Dashboard;
using AnimalShelterWPF.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Controllers
{
    class CatalogeController :ViewModelBase
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<UserCataloge> cataloges;
        public ObservableCollection<UserCataloge> Cataloges
        {
            get => cataloges;
            set => SetProperty(ref cataloges, value);
        }

        public CatalogeController()
        {
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new ApplicationContext())
            {
                
                var catalogs = context.UserCataloges.ToList();

                Cataloges = new ObservableCollection<UserCataloge>(catalogs);
            }
        }
    }
}
