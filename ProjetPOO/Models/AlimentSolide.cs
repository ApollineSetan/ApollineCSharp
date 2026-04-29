using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPOO.Models
{
    public abstract class AlimentSolide : Produit
    {
        protected AlimentSolide(string nom, double prix, int quantite, string slogan)
            : base(nom, prix, quantite, slogan) { }
        public override string Description() => "Aliment solide";
    }

    public class BarreChocolatee : AlimentSolide
    {
        public BarreChocolatee(string nom, double prix, int quantite, string slogan)
            : base(nom, prix, quantite, slogan) { }
    }

    public class Biscuit : AlimentSolide
    {
        public Biscuit(string nom, double prix, int quantite, string slogan)
            : base(nom, prix, quantite, slogan) { }
    }

    public class Chips : AlimentSolide
    {
        public Chips(string nom, double prix, int quantite, string slogan)
            : base(nom, prix, quantite, slogan) { }
    }

    public class Bonbon : AlimentSolide
    {
        public Bonbon(string nom, double prix, int quantite, string slogan)
            : base(nom, prix, quantite, slogan) { }
    }
}
