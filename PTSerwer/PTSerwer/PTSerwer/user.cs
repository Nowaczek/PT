using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTSerwer
{
    class user
    {
         public string imienazwisko { get; set; }
        public string index { get; set; }
        public string adres { get; set; }

        public user(string imie, string nazwisko, string index, string adres)
        {
            this.imienazwisko = imie + " " + nazwisko;
            this.index = index;
            this.adres = adres;
        }

        public void adresIP(string adres)
        {
            this.adres = adres;
        }
    }
    }

