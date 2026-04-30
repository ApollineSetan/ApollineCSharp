using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Webp;

#region Version séquentielle (sans optimisation)
// Ce code : 4927 ms en séquentiel avec 4 images × 3 résolutions = 12 fichiers générés

//var dossierSource = "images";
//var dossierDestination = "images-optimisees";
//var resolutions = new[] { 1080, 720, 480 };
//Directory.CreateDirectory(dossierDestination);

//var chrono = System.Diagnostics.Stopwatch.StartNew();

//foreach (var fichier in Directory.GetFiles(dossierSource))
//{
//    var nomFichier = Path.GetFileNameWithoutExtension(fichier);

//    foreach (var hauteur in resolutions)
//    {
//        using var image = Image.Load(fichier);
//        image.Mutate(x => x.Resize(0, hauteur));

//        var sortie = Path.Combine(dossierDestination, $"{nomFichier}_{hauteur}p.webp");
//        image.Save(sortie, new WebpEncoder());

//        Console.WriteLine($"Image optimisée : {sortie}");
//    }
//}

//chrono.Stop();
//Console.WriteLine($"\nTemps séquentiel : {chrono.ElapsedMilliseconds} ms");
#endregion

#region Version parallèle (avec optimisation)
// Version optimisée : 
// Ce code : 2837 ms en parallèle, presque 2x plus rapide

var dossierSource = "images";
var dossierDestination = "images-optimisees";
var resolutions = new[] { 1080, 720, 480 };
var chronoParallele = System.Diagnostics.Stopwatch.StartNew();

Parallel.ForEach(Directory.GetFiles(dossierSource), fichier =>
{
    var nomFichier = Path.GetFileNameWithoutExtension(fichier);

    foreach(var hauteur in resolutions)
    {
        using var image = Image.Load(fichier);
        image.Mutate(x => x.Resize(0, hauteur));

        var sortie = Path.Combine(dossierDestination, $"{nomFichier}_{hauteur}p.webp");
        image.Save(sortie, new WebpEncoder());

        Console.WriteLine($"Image optimisée : {sortie}");
    }
});

chronoParallele.Stop();
Console.WriteLine($"\nTemps parallèle : {chronoParallele.ElapsedMilliseconds} ms");
#endregion