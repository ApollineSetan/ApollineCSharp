using ProjetPOO;
using ProjetPOO.Factories;

public class Program
{
    public static void Main()
    {
        var distributeur = DistributeurFactory.Creer();

        while(true)
        {
            distributeur.AfficherProduits();
            Console.Write("\nVotre choix (entrez 0 si vous culpabilisez et souhaitez quitter) : ");

            if(!int.TryParse(Console.ReadLine(), out int choix)) continue;
            if(choix == 0) break;

            distributeur.Choisir(choix);
        }

        Console.WriteLine("\nÀ bientôt !");
    }
}