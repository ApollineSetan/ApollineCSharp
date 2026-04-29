namespace Calculatrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Entrez une opération :");
                string entree = Console.ReadLine();
                char[] operateurs = { '+', '-', '*', '/' };
                int positionOperateur = entree.IndexOfAny(operateurs);
                int a = int.Parse(entree.Substring(0, positionOperateur));
                int b = int.Parse(entree.Substring(positionOperateur + 1));
                char operateur = entree[positionOperateur];
                int resultat = operateur switch
                {
                    '+' => a + b,
                    '-' => a - b,
                    '*' => a * b,
                    '/' => a / b,
                };
                Console.WriteLine(resultat);
                Console.WriteLine("Voulez vous faire une autre opération ? (oui/non)");
                string reponseContinue = Console.ReadLine();
                if(reponseContinue != "oui")
                    break;
            }
        }
    }
}