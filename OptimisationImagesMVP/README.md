# Contrôle : optimisation d'images (version MVP)

Un ccript C# qui parcourt un dossier d'images et génère pour chaque image plusieurs résolutions (1080p, 720p, 480p) au format WebP.

---

## Librairie utilisée : SixLabors.ImageSharp

J'ai choisi la librairie ImageSharp pour manipuler des images en .NET.
Elle permet de redimensionner, convertir et exporter des images dans de nombreux formats.

---

## Architecture et dossiers/fichiers utilisés

```
OptimisationImagesMVP/
├── images/          → images sources (jpg/png)
├── images-optimisees/ → images générées (webp)
└── Program.cs
```

---

## Deux versions (une non optimisée et une optimisée)

### Version non optimisée (séquentielle)

Les images sont traitées une par une, ce qui peut être lent pour un grand nombre d'images.
Chaque image attend que la précédente soit terminée avant de commencer.

```csharp
foreach (var fichier in Directory.GetFiles(dossierSource))
{
    // traitement image par image
}
```

### Version optimisée (parallèle)

Les images sont traitées en parallèle, sur plusieurs threads simultanément.
Le .NET runtime répartir automatiquement les tâches sur les cœurs du processeur.

```csharp
Parallel.ForEach(Directory.GetFiles(dossierSource), fichier =>
{
    // plusieurs images traitées en même temps
});
```

L'ordre d'affichage n'est plus garanti et c'est normal, car plusieurs threads s'exécutent simultanément et chacun avance à son propre rythme.

## Résultats obtenus
Version : séquentielle | 4927 ms
Version : parallèle | 2837 ms