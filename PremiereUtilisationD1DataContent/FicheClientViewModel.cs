using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PremiereUtilisationD1DataContext
{
    public class FicheClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string str = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(str));
            }
        }

        private ObservableCollection<Client> fiches;

        public ObservableCollection<Client> Fiches
        {
            get
            {
                return fiches;
            }

            set
            {
                if(value != fiches)
                { 
                fiches = value;
                NotifyPropertyChanged();
               } 
            }
        }


        private Client ficheSelectionnee;

        public Client FicheSelectionnee
        {
            get
            {
                return ficheSelectionnee;
            }

            set
            {
                if (value != ficheSelectionnee)
                {
                    ficheSelectionnee = value;
                    NotifyPropertyChanged();
                }
            }
        }

        

        public FicheClientViewModel()
        {
            //initialisation\/creation d'une liste de fiches client
            Fiches = new ObservableCollection<Client>();

            //initialisation\/creation d'une fiche client par defaut
            FicheSelectionnee = new Client()
            {
                Nom = "Dupont",
                Prenom = "Pierre",
                Age = 32,
                Sexe = "M",
            };

            //ajout du nouveau client a la Liste de Fiches Client
            Fiches.Add(FicheSelectionnee);

        }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                        //RAZ 
/// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //creation de la commande RAZ Client + val par defaut un client d'une fiche client
        private ICommand remiseAZeroDeLaFicheSelectionnee = new RelayCommand<Client>((client)=> {
            client.Nom = "";
            client.Prenom = "";
            client.Age = 0;
            client.Sexe = "";
        });

        //cette Command sera abonnée/affectée au bouton RAZ !!!!
        public ICommand RemiseAZeroDeLaFicheSelectionnee
        {
            get
            {
                //efface le client en parametre
                return remiseAZeroDeLaFicheSelectionnee;
            }

        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //AJOUT D UNE FICHE CLIENT
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private ICommand ajoutDuneFicheClient;

        public ICommand AjoutDuneFicheClient
        {
            get
            {
                if(ajoutDuneFicheClient == null)
                {
                    //ajoute la fiche en parametre
                    ajoutDuneFicheClient = new RelayCommand<object>((obj) => Fiches.Add(new Client()));
                }
                return ajoutDuneFicheClient;
            }

        }

       
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////  RETRAIT D UNE FICHE CLIENT 
        //////////////////////////////////////////////////////////////////////////////
        private ICommand retraitDuneFicheClient;

        public ICommand RetraitDuneFicheClient
        {
            get
            {
                if(retraitDuneFicheClient == null)
                {
                    //retire la fiche en parametre
                    retraitDuneFicheClient = new RelayCommand<Client>((client) => Fiches.Remove(client));
                }
                return retraitDuneFicheClient;
            }

        }

        

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////// EDITION D UNE FICHE CLIENT //////
        ////////////////////////////////////////////////////////////////////////////////////////////
        private ICommand editerUneFicheClient;

        public ICommand EditerUneFicheClient
        {
            get
            {
                if (editerUneFicheClient == null)
                {
                    //selectionne la fiche en parametre
                    editerUneFicheClient = new RelayCommand<Client>((client) => FicheSelectionnee = client);
                }
                return editerUneFicheClient;
            }
            
        }
    }

}
