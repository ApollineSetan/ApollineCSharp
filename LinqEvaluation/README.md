# Exercice : conversion de films

Recherche, tri et export XML d'une liste de films en C# pour mettre en pratique LINQ.

---

## Architecture

ProjetConversionLinqEvaluation/
└── Program.cs
DataSources/
└── Collections/
├── Film.cs
└── ListFilmsData.cs

---

## Fonctionnalités

1. Recherche par titre (insensible à la casse)
2. Tri par titre ou par année de sortie
3. Affichage des résultats dans la console
4. Export XML avec choix des champs

---

## LINQ utilisé

### .Where()
Filtre les films dont le titre contient la recherche de l'utilisateur.

### .OrderBy()
Trie les résultats selon le choix de l'utilisateur — par titre ou par année.

### from ... select (syntaxe requête)
Projette chaque film en élément XML avec XAttribute.

---

## Exemple de sortie XML

<Films>
  <Film Id="17" Titre="Gladiator" Année="2000" />
</Films>