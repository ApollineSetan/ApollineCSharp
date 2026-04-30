using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Webp;
using Newtonsoft.Json;
using OptimisationImagesV1;

#region Téléchargement des images
var json = File.ReadAllText("images.json");
var images = JsonConvert.DeserializeObject<List<ImageSource>>(json);


var dossierDestination = "images-telechargees";
Directory.CreateDirectory(dossierDestination);

using var httpClient = new HttpClient();

foreach (var image in images)
{
    Console.WriteLine($"Téléchargement de l'image : {image.Nom}");
    var bytes = await httpClient.GetByteArrayAsync(image.Url);
    var cheminLocal = Path.Combine(dossierDestination, $"{image.Nom}.jpg");
    await File.WriteAllBytesAsync(cheminLocal, bytes);
    Console.WriteLine($"Image téléchargée : {image.Nom}");
}
#endregion

#region Version séquentielle (sans optimisation)
//var dossierConverti = "images-converties";
//Directory.CreateDirectory(dossierConverti);
//var resolutions = new[] { 1080, 720, 480 };

//var chrono = System.Diagnostics.Stopwatch.StartNew();

//foreach (var fichier in Directory.GetFiles(dossierDestination))
//{
//    var nomFichier = Path.GetFileNameWithoutExtension(fichier);

//    foreach(var hauteur in resolutions)
//    {
//        using var image = Image.Load(fichier);
//        image.Mutate(x => x.Resize(0, hauteur));
//        var sortie = Path.Combine(dossierConverti, $"{nomFichier}_{hauteur}.webp");
//        image.Save(sortie, new WebpEncoder());
//        Console.WriteLine($"Converti : {sortie}");
//    }
//}

//chrono.Stop();
//Console.WriteLine($"\nTemps séquentiel : {chrono.ElapsedMilliseconds} ms");
#endregion

#region Version parallèle (avec optimisation)
var dossierConverti = "images-converties";
Directory.CreateDirectory(dossierConverti);
var resolutions = new[] { 1080, 720, 480 };

var chronoParallele = System.Diagnostics.Stopwatch.StartNew();

Parallel.ForEach(Directory.GetFiles(dossierDestination), fichier =>
{
    var nomFichier = Path.GetFileNameWithoutExtension(fichier);
    foreach(var hauteur in resolutions)
    {
        using var image = Image.Load(fichier);
        image.Mutate(x => x.Resize(0, hauteur));
        var sortie = Path.Combine(dossierConverti, $"{nomFichier}_{hauteur}.webp");
        image.Save(sortie, new WebpEncoder());
        Console.WriteLine($"Converti : {sortie}");
    }
});

chronoParallele.Stop();
Console.WriteLine($"\nTemps parallèle : {chronoParallele.ElapsedMilliseconds} ms");
#endregion