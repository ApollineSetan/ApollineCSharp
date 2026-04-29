using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPOO.Models
{
    public abstract class AlimentLiquide : Produit
    {
        public int Volume { get; protected set; }

        protected AlimentLiquide(string nom, double prix, int quantite, int volume, string slogan)
            : base(nom, prix, quantite, slogan)
        {
            Volume = volume;
        }
        public override string Description() => $"Boisson ({Volume}mL)";
    }

    public class BoissonFroide : AlimentLiquide
    {
        public BoissonFroide(string nom, double prix, int quantite, int volume, string slogan)
            : base(nom, prix, quantite, volume, slogan) { }
    }

    public class BoissonChaude : AlimentLiquide
    {
        public BoissonChaude(string nom, double prix, int quantite, int volume, string slogan)
            : base(nom, prix, quantite, volume, slogan) { }
    }
}
