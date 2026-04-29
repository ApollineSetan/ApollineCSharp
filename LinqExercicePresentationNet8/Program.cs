using DataSources;
using System.Xml.Linq;

#region Exercice 1 : Recherche groupée par artiste avec nom
//Console.WriteLine("Que recherchez vous");

//var recherche = Console.ReadLine();
//var listAlbums = ListAlbumsData.ListAlbums;
//var listArtists = ListArtistsData.ListArtists; 

//var jointure = listAlbums
//    .Where(a => a.Title.Contains(recherche, StringComparison.InvariantCultureIgnoreCase))
//    .Join(listArtists,
//        album => album.ArtistId,
//        artist => artist.ArtistId,
//        (album, artist) => new
//        {
//            artist = artist,
//            album = album
//        });

//var albumsGroupes = jointure
//    .OrderBy(x => x.artist.Name)
//    .GroupBy(x => x.artist);

//foreach(var groupe in albumsGroupes)
//{
//    Console.WriteLine($"Artiste : {groupe.Key.Name}");
//    foreach(var item in groupe)
//    {
//        Console.WriteLine($"Album n°{item.album.AlbumId} : {item.album.Title}");
//    }
//    Console.WriteLine();
//}
#endregion


#region Exercice 2 : Pagination
//var allAlbums = ListAlbumsData.ListAlbums;

//var albumsForDisplay = allAlbums
//    .OrderBy(album => album.AlbumId)
//    .Select(album => $"Album n°{album.AlbumId} : {album.Title}");

//int pageSize = 20;
//int page = 0;

//do
//{
//    var pageActuelle = albumsForDisplay
//        .Skip(page * pageSize)
//        .Take(pageSize);

//    foreach(var album in pageActuelle)
//    {
//        Console.WriteLine(album);
//    }

//    page++;
//    Console.WriteLine("Entrée' pour continuer");
//} while (Console.ReadLine() != null && page * pageSize < albumsForDisplay.Count());
#endregion


#region Exercice 3 : Recherche dans un fichier texte (LINQ to Text)
//Console.WriteLine("Quelle est ta recherche ?");
//var recherche = Console.ReadLine();

//var lignes = File.ReadAllLines("../../../../DataSources/Text/Albums.txt");

//var resultats = lignes
//    .Where(ligne => ligne.Contains(recherche, StringComparison.InvariantCultureIgnoreCase));

//foreach (var ligne in resultats)
//{
//    Console.WriteLine(ligne);
//}
#endregion


#region Exercice 4 : Recherche dans un fichier texte (LINQ to Text)
var allAlbums = ListAlbumsData.ListAlbums;

XElement xml = new XElement("Root",
    allAlbums.Select(album =>
        new XElement("Album",
            new XElement("AlbumId", album.AlbumId),
            new XElement("Title", album.Title)
        )
    )
);

Console.WriteLine(xml);
//xml.Save("../../../../DataSources/Text/Albums.xml"); s'il fallait sauvegarder dans un fichier
#endregion
