using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Eksamen2Semester.Annotations;
using Eksamen2Semester.Facade;
using Eksamen2Semester.Model;
using Eksamen2Semester.Singletonz;
using Eksamen2Semester.View;
using Eventmaker.Common;

namespace Eksamen2Semester.VM
{
    public class PersonSøgningVM : INotifyPropertyChanged
    {
        public Deltager SelecteDeltager
        {
            get { return _selecteDeltager; }
            set { _selecteDeltager = value; }
        }

        public ObservableCollection<Kursus> KursusOC { get; set; }
        public KursusOCSingleton KursusOcSingleton { get; set; }
        public List<Deltager> DeltagerListe { get; set; }
        public ObservableCollection<Deltager> ResultatAfPersonSøgningOC { get; set; }
        private string _tempSøgeinput;
        private Deltager _selecteDeltager;
        public RelayCommand NavigateForsideCommand { get; set; }
        public RelayCommand FindKurserCommand { get; set; }
        public string Søgeinput { get; set; }
        public string TempSøgeinput
        {
            get { return _tempSøgeinput; }
            set
            {
                Søgeinput = value;
                DeltagerSøg();
                _tempSøgeinput = value;
            }
        }

        public DeltaKatalogSingleton DeltaKatalogSingletonVM { get; set; }




        public PersonSøgningVM()
        {
            DeltaTilDB();

            KursusOcSingleton = KursusOCSingleton.Intance;
            NavigateForsideCommand = new RelayCommand(NavigateToForside);
            FindKurserCommand = new RelayCommand(DeltagetIKursus);
            DeltagerListe = GetDeltagerListe();
            ResultatAfPersonSøgningOC = new ObservableCollection<Deltager>();
            KursusOC = new ObservableCollection<Kursus>();
            SelecteDeltager = new Deltager();
            DeltaKatalogSingletonVM = DeltaKatalogSingleton.Deltagkatalogsingeltons;


        }

        public async void DeltaTilDB()
        {
            await DeltaFacade.GetDeltagere();
        }

        public void NavigateToForside()
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(Forside));

        }



        public void DeltagerSøg()
        {



            ResultatAfPersonSøgningOC.Clear();
            foreach (var deltager in from t in DeltaKatalogSingletonVM.Deltageres
                                     where t.Navn.Contains(Søgeinput) || t.Email.Contains(Søgeinput) || t.TelefonNr.Contains(Søgeinput)
                                     select t)
            {
                ResultatAfPersonSøgningOC.Add(deltager);
            }
        }








        public void DeltagetIKursus()
        {
            KursusOC.Clear();
            foreach (var kursus in from t in KursusOcSingleton.SingletonOCKursus
                                   where t.DeltagerListe.Contains(SelecteDeltager)
                                   select t)

            {
                KursusOC.Add(kursus);
            }
        }

        public List<Deltager> GetDeltagerListe()
        {
            List<Deltager> tempList = new List<Deltager>();
            foreach (var kursus in KursusOcSingleton.SingletonOCKursus)
            {
                foreach (var deltager in kursus.DeltagerListe)
                {
                    if (!tempList.Contains(deltager))
                    {
                        tempList.Add(deltager);
                    }
                }
            }

            return tempList;
            

        }

        #region PropertyChangedHelper

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}





