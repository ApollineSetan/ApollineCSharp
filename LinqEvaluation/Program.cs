using DataSources;
using System.Xml.Linq;

var films = ListFilmsData.ListFilms;

Console.WriteLine("Cherchez un film en tapant des caractères");
var recherche = Console.ReadLine();

// Filtrage
var résultats = films
    .Where(f => f.Titre.Contains(recherche, StringComparison.InvariantCultureIgnoreCase));

// puis le tri
Console.WriteLine("Voulez-vous trier par titre dans l'ordre alphabétique (tapez '1') ou par date de sortie (tapez '2')");
var choixTri = Console.ReadLine();

résultats = choixTri == "1"
    ? résultats.OrderBy(f => f.Titre)
    : résultats.OrderBy(f => f.Année);

// affichage des résultats
Console.WriteLine("\n=== Résultats ===");
foreach(var film in résultats)
{
    Console.WriteLine($"{film.Id} : {film.Titre} ({film.Année})");
}

// bonus avec choix des champs à exporter
Console.WriteLine("\nQuels champs souhaitez-vous exporter ?");
Console.WriteLine("1 : Id, Titre, Année (tout)");
Console.WriteLine("2 : Titre et Année uniquement");
Console.WriteLine("3 : Titre uniquement");
var choixChamps = Console.ReadLine();

XElement xml = new XElement("Films",
    from film in résultats
    select new XElement("Film",
        choixChamps == "1" ? new object[]
        {
            new XAttribute("Id", film.Id),
            new XAttribute("Titre", film.Titre),
            new XAttribute("Année", film.Année)
        }
        : choixChamps == "2" ? new object[]
        {
            new XAttribute("Titre", film.Titre),
            new XAttribute("Année", film.Année)
        }
        : new object[]
        {
            new XAttribute("Titre", film.Titre)
        }
    )
);

// sauvegarde du XML
xml.Save("ResultatsFilms.xml");
Console.WriteLine("\nRésultats exportés vers 'ResultatsFilms.xml'");