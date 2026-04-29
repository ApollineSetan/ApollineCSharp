using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using ProjetPOO.Models;

namespace ProjetPOO.Factories
{
    public static class DistributeurFactory
    {
        public static Distributeur Creer()
        {
            var distributeur = new Distributeur();

            distributeur.AjouterProduit(new BarreChocolatee("Mars", 1.20, 5, "Travail, repos et jeu !"));
            distributeur.AjouterProduit(new BarreChocolatee("Twix", 1.20, 5, "Pause Twix !"));
            distributeur.AjouterProduit(new Biscuit("Madeleines", 1.90, 8, "Le goût de l'enfance !"));
            distributeur.AjouterProduit(new Biscuit("Cookie", 1.50, 6, "Croustillant à souhait !"));
            distributeur.AjouterProduit(new Chips("Chips Nature", 1.10, 7, "Impossible de s'arrêter !"));
            distributeur.AjouterProduit(new Bonbon("Dragibus", 1.70, 10, "La vie en couleurs !"));
            distributeur.AjouterProduit(new BoissonFroide("Coca-Cola", 1.50, 10, 330, "Taste the feeling !"));
            distributeur.AjouterProduit(new BoissonFroide("Eau", 0.80, 15, 500, "La pureté à l'état naturel !"));
            distributeur.AjouterProduit(new BoissonChaude("Café", 0.50, 20, 200, "L'énergie dans ta tasse !"));
            distributeur.AjouterProduit(new BoissonChaude("Chocolat Chaud", 0.50, 15, 200, "La chaleur en une gorgée !"));

            return distributeur;
        }
    }
}

