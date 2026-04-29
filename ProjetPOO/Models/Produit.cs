using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetPOO.Interfaces;

namespace ProjetPOO.Models
{
    public abstract class Produit : IVendable, ISlogannable, IDescriptible
    {
        public string Nom { get; protected set; }
        public double Prix { get; protected set; }
        public int Quantite { get; private set; }
        public string Slogan { get; private set; }

        protected Produit(string nom, double prix, int quantite, string slogan)
        {
            Nom = nom;
            Prix = prix;
            Quantite = quantite;
            Slogan = slogan;
        }

        public abstract string Description();

        public string AfficherSlogan() => $"{Nom} : \"{Slogan}\"";

        public bool Acheter()
        {
            if(Quantite <= 0) return false;
            Quantite--;
            return true;
        }

        public override string ToString()
            => $"[{Description()}] {Nom} - {Prix:0.00}eu (stock restant: {Quantite})";
    }

}
