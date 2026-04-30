using ProjetPOO.Interfaces;
using ProjetPOO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPOO
{
    public class Distributeur
    {
        private readonly List<Produit> _produits = new List<Produit>();
        public Distributeur() { }
        public void AjouterProduit(Produit p) => _produits.Add(p);

        public void AfficherProduits()
        {
            Console.WriteLine("\n╔══════════════════════════════╗");
            Console.WriteLine("║       DISTRIBUTEUR           ║");
            Console.WriteLine("╚══════════════════════════════╝");
            for(int i = 0; i < _produits.Count; i++)
                Console.WriteLine($"  [{i + 1}] {_produits[i]}");
        }

        public void Choisir(int index)
        {
            if(index < 1 || index > _produits.Count)
            {
                Console.WriteLine("Choix invalide.");
                return;
            }
            var produit = _produits[index - 1];
            if(produit.Acheter())
            {
                if(produit is ISlogannable s)
                    Console.WriteLine(s.AfficherSlogan());
                Console.WriteLine($"{produit.Prix:0.00}eu débités. Merci !");
            }
            else
            {
                Console.WriteLine($"Arf... Rupture de stock pour {produit.Nom} !");
            }
        }
    }
}