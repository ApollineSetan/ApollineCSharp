# Contrôle : optimisation d'images (version V1)

Un ccript C# qui lit un fichier JSON contenant des URLs Unsplash, télécharge les images, puis génère pour chaque image plusiurs résolutions.

---

## Différence avec le MVP

Le MVP travaillait sur des images déjà présentes localement, La V1 va chercher les images directement depuis internet via des URLs
J'ai choisi la librairie ImageSharp pour manipuler des images en .NET.
Elle permet de redimensionner, convertir et exporter des images dans de nombreux formats.

---

## Architecture et dossiers/fichiers utilisés

```
├── images.json            → URLs des images à télécharger
├── images-telechargees/   → images téléchargées (jpg)
├── images-converties/     → images converties (webp)
├── ImageSource.cs         → modèle pour désérialiser le JSON
└── Program.cs
```

---

## Étapes du programme

1. Lecture du fichier images.json
2. Téléchargement de chaque image via HttpClient (async/await)
3. Conversion séquentielle en WebP aux 3 résolutions
4. Conversion parallèle en WebP aux 3 résolutions

---


## Deux versions (une non optimisée et une optimisée)

### Version non optimisée (séquentielle)

Les images sont converties une par une dans l'ordre, ce qui peut être lent pour un grand nombre d'images.
Chaque image attend que la précédente soit terminée avant de commencer.

```csharp
foreach (var fichier in Directory.GetFiles(dossierDestination))
{
    // traitement image par image
}
```

### Version optimisée (parallèle)

Les images sont converties en parallèle, sur plusieurs threads simultanément.
Le .NET runtime répartir automatiquement les tâches sur les cœurs du processeur.

```csharp
Parallel.ForEach(Directory.GetFiles(dossierDestination), fichier =>
{
    // plusieurs images traitées en même temps
});
```

L'ordre d'affichage n'est plus garanti et c'est normal, car plusieurs threads s'exécutent simultanément et chacun avance à son propre rythme.

## Résultats obtenus
Version : séquentielle | 3197 ms
Version : parallèle | 1950 ms