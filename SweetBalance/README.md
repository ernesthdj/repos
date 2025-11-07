# 🍰 SweetBalance - Application WPF MVVM

Application de gestion de pâtisserie développée en C# avec WPF et architecture MVVM.

## 📋 Description

SweetBalance est une application de bureau complète pour la gestion d'une activité de pâtisserie. Elle permet de gérer :

- 📦 **Stocks** : Gestion des ingrédients avec alertes de stock faible
- 🍰 **Recettes** : Catalogue de recettes avec calcul des coûts
- 💰 **Devis** : Création et gestion de devis clients
- 📅 **Commandes** : Suivi des commandes en cours
- ✅ **Production** : Planning de production
- 📊 **Statistiques** : Analyse de l'activité
- ⚙️ **Paramètres** : Configuration de l'application

## 🏗️ Architecture

Le projet suit le pattern **MVVM (Model-View-ViewModel)** :

```
SweetBalance/
├── Models/              # Modèles de données
│   ├── Stock.cs
│   ├── Recipe.cs
│   ├── Quote.cs
│   ├── Order.cs
│   └── Settings.cs
│
├── ViewModels/          # Logique métier
│   ├── Base/
│   │   └── ObservableObject.cs
│   ├── MainViewModel.cs
│   ├── StockViewModel.cs
│   └── ...
│
├── Views/               # Interfaces utilisateur (XAML)
│   ├── MainWindow.xaml
│   ├── StockView.xaml
│   └── ...
│
├── Helpers/             # Classes utilitaires
│   └── RelayCommand.cs
│
└── Resources/           # Ressources (styles, etc.)
    └── Styles.xaml
```

## 🚀 Prérequis

- .NET 6.0 SDK ou supérieur
- Visual Studio 2022 ou Visual Studio Code
- Windows 10 ou supérieur

## 💻 Installation

1. Cloner le repository :
```bash
git clone <url-du-repo>
cd SweetBalance
```

2. Restaurer les packages NuGet :
```bash
dotnet restore
```

3. Compiler le projet :
```bash
dotnet build
```

4. Exécuter l'application :
```bash
dotnet run
```

## 📦 Fonctionnalités implémentées

### Module Stocks (Complet)

- ✅ Ajout/modification/suppression d'ingrédients
- ✅ Gestion des quantités en stock
- ✅ Alertes pour stocks faibles
- ✅ Calcul de la valeur totale du stock
- ✅ Interface intuitive avec formulaire modal

### Modules en développement

Les modules suivants affichent actuellement un message "Module en cours de développement" :

- Recettes
- Devis
- Commandes
- Production
- Statistiques
- Paramètres

## 🎨 Design

L'application utilise un design moderne avec :

- Dégradés rose/violet
- Cartes avec ombres
- Navigation latérale
- Animations fluides
- Emojis pour une meilleure expérience utilisateur

## 🔧 Technologies utilisées

- **C# 10** : Langage de programmation
- **WPF** : Framework d'interface utilisateur
- **.NET 6.0** : Framework de développement
- **XAML** : Langage de balisage pour l'UI
- **MVVM** : Pattern d'architecture

## 📝 Structure des données

### Stock
```csharp
public class Stock
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public decimal PrixUnitaire { get; set; }
    public string Unite { get; set; }
    public decimal StockActuel { get; set; }
    public decimal StockMin { get; set; }
}
```

## 🎯 Roadmap

- [x] Structure MVVM de base
- [x] Module de gestion des stocks
- [ ] Module de gestion des recettes
- [ ] Module de gestion des devis
- [ ] Module de gestion des commandes
- [ ] Module de production
- [ ] Module de statistiques
- [ ] Sauvegarde des données (base de données ou fichiers)
- [ ] Export PDF des devis
- [ ] Impression des commandes

## 🤝 Contribution

Les contributions sont les bienvenues ! N'hésitez pas à ouvrir une issue ou une pull request.

## 📄 Licence

Ce projet est développé à des fins éducatives et professionnelles.

## 👨‍💻 Auteur

Converti depuis une application React vers WPF MVVM.

---

**Note** : Cette application est une conversion d'une application React vers WPF en utilisant le pattern MVVM. Le module Stocks est entièrement fonctionnel, les autres modules sont à développer selon vos besoins.
