using AnimalShelter.Controllers;
using AnimalShelter.Controllers.Data;
using AnimalShelter.Views.Dashboard;
using AnimalShelterWPF.Models;
using LiveCharts;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace AnimalShelterWPF.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {
        private int idAppointment;
        public int IdAppointment
        {
            get => idAppointment;
            set => SetProperty(ref idAppointment, value);
        }

        private string name;
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        private TimeOnly? date;
        public TimeOnly? Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private int idPet;
        public int IdPet
        {
            get => idPet;
            set => SetProperty(ref idPet, value);
        }

        private string veterinary;
        public string Veterinary
        {
            get => veterinary;
            set => SetProperty(ref veterinary, value);
        }

        private ObservableCollection<Appointment> appointments;
        public ObservableCollection<Appointment> Appointments
        {
            get => appointments;
            set
            {
                if (SetProperty(ref appointments, value))
                {
                    _filteredAppointments = CollectionViewSource.GetDefaultView(appointments);
                    _filteredAppointments.Filter = FilterAppointments;
                }
            }
        }

        private ICollectionView _filteredAppointments;
        public ICollectionView FilteredAppointments => _filteredAppointments;

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (SetProperty(ref _searchText, value))
                {
                    _filteredAppointments.Refresh();
                }
            }
        }

        private bool FilterAppointments(object obj)
        {
            if (obj is Appointment appointment)
            {
                if (DateTime.TryParse(appointment.Date, out DateTime appointmentDate))
                {
                    return appointmentDate >= DateTime.Now;
                }
            }
            return false;
        }

        public AppointmentViewModel()
        {
            appointments = new ObservableCollection<Appointment>();
            _filteredAppointments = CollectionViewSource.GetDefaultView(appointments);
            _filteredAppointments.Filter = FilterAppointments;
            LineSeriesValues = new ChartValues<double>();
            LoadAppointments();

            LoadAppointments();
        }


        public void LoadAppointments()
        {
            using (var context = new ApplicationContext())
            {
                List<Appointment> appointmentList = context.Appointments.Include(p=>p.IdPetNavigation).ToList();
                Appointments = new ObservableCollection<Appointment>(appointmentList);
            }


        }

        private ChartValues<double> _lineSeriesValues;

        public ChartValues<double> LineSeriesValues
        {
            get { return _lineSeriesValues; }
            set
            {
                _lineSeriesValues = value;
                OnPropertyChanged(nameof(LineSeriesValues));
            }
        }

        private void ExecuteSearch(object parameter)
        {
            _filteredAppointments.Refresh();
        }

    }
}
