# Distributeur Automatique — ProjetPOO

Simulation console d'un distributeur automatique en C#, 
conçue pour mettre en pratique les concepts avancés de la POO.

---

## Architecture

ProjetPOO/
├── Interfaces/
│   ├── IVendable.cs
│   ├── ISlogannable.cs
│   └── IDescriptible.cs
├── Models/
│   ├── Produit.cs
│   ├── AlimentSolide.cs
│   └── AlimentLiquide.cs
├── Factories/
│   └── DistributeurFactory.cs
├── Distributeur.cs
└── Program.cs

---

## Concepts POO utilisés

### Abstraction
`Produit` est une classe abstraite — on ne peut pas faire `new Produit()`.
Elle définit la structure commune à tous les produits sans représenter 
un produit concret. `AlimentSolide` et `AlimentLiquide` sont également 
abstraites pour la même raison.

### Héritage
Hiérarchie à 3 niveaux :

Produit (abstraite)
├── AlimentSolide (abstraite)
│   ├── BarreChocolatee
│   ├── Biscuit
│   ├── Chips
│   └── Bonbon
└── AlimentLiquide (abstraite)
├── BoissonFroide
└── BoissonChaude

Chaque niveau hérite des propriétés et méthodes du niveau supérieur 
via `: base(...)`.

### Polymorphisme
`Description()` est définie `abstract` dans `Produit`, puis implémentée 
dans `AlimentSolide` et `AlimentLiquide`. Quand `ToString()` appelle 
`Description()`, il ne sait pas s'il parle à un solide ou un liquide  
d'où le polymorphisme.

```csharp
// Produit.cs
public override string ToString()
    => $"[{Description()}] {Nom} - {Prix:0.00}eu (stock restant: {Quantite})";
// Description() sera résolue dynamiquement à l'exécution
```

### Encapsulation
Les propriétés sont protégées par des accesseurs qui sont contrôlés :
- `Quantite` est `private set` , seule la méthode `Acheter()` peut la modifier
- `Nom`, `Prix`, `Slogan` sont `protected set` , modifiables uniquement 
  par les classes filles

### Interfaces
Trois interfaces définissent les contrats du projet :

`IVendable` Tout produit a un prix, une quantité, et peut être acheté
`ISlogannable` Tout produit peut afficher son slogan
`IDescriptible` Tout produit peut se décrire

`Produit` implémente les trois. Dans `Distributeur`, on exploite 
explicitement l'interface :
```csharp
if (produit is ISlogannable s)
    Console.WriteLine(s.AfficherSlogan());
```
Cela signifie que `Distributeur` dépend du contrat et non 
de la classe concrète.

### Composition
`Distributeur` n'hérite de rien — il **possède** une `List<Produit>`.
C'est la composition : "un distributeur a des produits".

```csharp
private readonly List<Produit> _produits = new List<Produit>();
```

### Pattern Factory
`DistributeurFactory` est une classe statique dont le seul rôle est 
de créer et peupler le distributeur. Cela sépare la logique de 
création de la logique métier — `Program.cs` n'a pas à connaître 
les détails de l'initialisation.

---

## Améliorations possibles

- **Catégories** — afficher les produits groupés par type 
  (solides / liquides)
- **Persistence** — sauvegarder les stocks dans un fichier JSON 
  entre deux sessions
- **Principe SOLID** — `Distributeur` pourrait dépendre d'une 
  interface `IDistributeur` plutôt que de la classe concrète
- **Tests unitaires** — tester `Acheter()` avec des cas limites 
  (stock à 0, index invalide)