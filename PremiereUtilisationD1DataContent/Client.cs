using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereUtilisationD1DataContext
{
    public class Client : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private string sexe;
        private int age;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                if(value != nom) { 


                nom = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nom"));

                    /* ancienne façon de faire pour indiquer aux autre methode dependant de PropertyChanged
                     quelle propriete a été changée.*/
                    /*if(PropertyChanged != null){
                     * PropertyChanged(this, PropertyChangedEventArgs("Nom"));
                }*/
                }
            }
        }

        public string Prenom
        {
            get
            {
                return prenom;
            }

            set
            {
                if (value != prenom)
                {
                    prenom = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prenom"));
                }
            }
        }

        public string Sexe
        {
            get
            {
                return sexe;
            }

            set
            {
                if (value != sexe)
                {
                    sexe = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sexe"));
                }
            }
        }

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                if (value != age)
                {
                    age = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Age"));
                }
            }
        }
    }
}
