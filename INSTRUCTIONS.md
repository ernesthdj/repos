# 🍰 SweetBalance - Instructions d'ouverture dans Visual Studio

## 📋 Structure du projet WPF

Votre application **SweetBalance** est maintenant une véritable application WPF avec une structure complète :

```
SweetBalance/
├── SweetBalance.sln              ← Fichier solution à ouvrir dans Visual Studio
│
└── SweetBalance/                 ← Projet WPF
    ├── SweetBalance.csproj       ← Fichier projet WPF
    │
    ├── App.xaml                  ← Point d'entrée de l'application
    ├── App.xaml.cs
    │
    ├── Properties/               ← Dossier Properties WPF ✅
    │   ├── AssemblyInfo.cs       ← Métadonnées de l'assembly
    │   ├── Resources.Designer.cs
    │   ├── Resources.resx        ← Fichier de ressources
    │   ├── Settings.Designer.cs
    │   └── Settings.settings     ← Paramètres d'application
    │
    ├── Models/                   ← Modèles de données
    │   ├── Stock.cs
    │   ├── Recipe.cs
    │   ├── Quote.cs
    │   ├── Order.cs
    │   └── Settings.cs
    │
    ├── ViewModels/               ← Logique métier MVVM
    │   ├── Base/
    │   │   └── ObservableObject.cs
    │   ├── MainViewModel.cs
    │   ├── StockViewModel.cs
    │   └── ... (autres ViewModels)
    │
    ├── Views/                    ← Interfaces utilisateur XAML
    │   ├── MainWindow.xaml
    │   ├── MainWindow.xaml.cs
    │   ├── StockView.xaml
    │   └── ... (autres Views)
    │
    ├── Helpers/                  ← Classes utilitaires
    │   └── RelayCommand.cs
    │
    └── Resources/                ← Ressources de style
        └── Styles.xaml
```

## 🚀 Comment ouvrir le projet dans Visual Studio 2022

### Option 1 : Ouvrir le fichier .sln

1. Ouvrez **Visual Studio 2022**
2. Cliquez sur **"Ouvrir un projet ou une solution"**
3. Naviguez vers le dossier du repo et sélectionnez : `SweetBalance.sln`
4. Cliquez sur **"Ouvrir"**

### Option 2 : Ouvrir le dossier

1. Ouvrez **Visual Studio 2022**
2. Cliquez sur **"Ouvrir un dossier"**
3. Sélectionnez le dossier `SweetBalance/`
4. Visual Studio détectera automatiquement le projet WPF

## ▶️ Comment compiler et exécuter

### Dans Visual Studio :

1. Appuyez sur **F5** ou cliquez sur le bouton **"Démarrer"** (▶️)
2. Visual Studio va :
   - Restaurer les packages NuGet automatiquement
   - Compiler le projet
   - Lancer l'application WPF

### En ligne de commande :

Si vous avez le .NET 6 SDK installé :

```bash
cd SweetBalance

# Restaurer les packages
dotnet restore

# Compiler
dotnet build

# Exécuter
dotnet run
```

## 🎯 Fonctionnalités actuelles

### ✅ Module Stocks (100% fonctionnel)

Le module de gestion des stocks est **entièrement implémenté** avec :

- Ajout d'ingrédients avec formulaire
- Modification d'ingrédients existants
- Suppression avec confirmation
- Boutons +/- pour ajuster les quantités
- Alertes visuelles pour stocks faibles (affichage en rouge)
- Calcul automatique de la valeur totale du stock
- Validation des données (nom obligatoire, prix > 0)

### 🔧 Modules en développement

Ces modules ont leur structure de base mais affichent "Module en cours de développement" :

- **Recettes** : Catalogue de recettes avec calcul des coûts
- **Devis** : Création et gestion de devis clients
- **Commandes** : Suivi des commandes
- **Production** : Planning de production
- **Statistiques** : Analyse de l'activité
- **Paramètres** : Configuration de l'application

## 🏗️ Architecture MVVM

Le projet suit strictement le pattern **Model-View-ViewModel** :

- **Models** : Classes de données pures (Stock, Recipe, etc.)
- **ViewModels** : Logique métier + INotifyPropertyChanged
- **Views** : XAML uniquement pour l'interface
- **DataBinding** : Liaison bidirectionnelle entre View et ViewModel

## 🎨 Technologies utilisées

- **.NET 6.0** - Framework moderne
- **WPF** (Windows Presentation Foundation)
- **C# 10**
- **XAML** - Markup pour l'interface
- **MVVM** - Pattern d'architecture

## 📦 Prérequis

- **Windows 10** ou supérieur
- **Visual Studio 2022** (Community, Professional ou Enterprise)
  - Avec la charge de travail "Développement .NET Desktop"
- **.NET 6.0 SDK** (inclus avec Visual Studio 2022)

## ✨ Points clés du code

### Navigation entre modules

La navigation est gérée par le `MainViewModel` qui expose des commandes :

```csharp
NavigateToStocksCommand
NavigateToRecipesCommand
NavigateToQuotesCommand
// etc.
```

### Liaison des données (Data Binding)

Toutes les vues utilisent le DataBinding XAML :

```xaml
<TextBox Text="{Binding CurrentStock.Nom, UpdateSourceTrigger=PropertyChanged}"/>
<Button Command="{Binding SaveCommand}"/>
```

### Notifications de changement

Les ViewModels héritent de `ObservableObject` qui implémente `INotifyPropertyChanged` :

```csharp
public decimal ValeurTotale
{
    get { ... }
}

OnPropertyChanged(nameof(ValeurTotale));
```

## 🐛 Résolution de problèmes

### Le projet ne compile pas

1. Vérifiez que vous avez **.NET 6 SDK** installé
2. Dans Visual Studio : clic droit sur la solution → **"Restaurer les packages NuGet"**
3. Menu **Générer** → **"Regénérer la solution"**

### L'application ne démarre pas

1. Vérifiez que le projet de démarrage est bien **SweetBalance**
2. Clic droit sur le projet → **"Définir comme projet de démarrage"**

### Erreur de namespace

Si vous renommez le projet :
1. Mettez à jour tous les namespaces dans les fichiers .cs
2. Mettez à jour les déclarations `xmlns:local` dans les fichiers .xaml

## 📚 Ressources

- [Documentation WPF Microsoft](https://docs.microsoft.com/fr-fr/dotnet/desktop/wpf/)
- [Pattern MVVM](https://docs.microsoft.com/fr-fr/dotnet/architecture/maui/mvvm)
- [.NET 6 Documentation](https://docs.microsoft.com/fr-fr/dotnet/core/whats-new/dotnet-6)

---

**Note** : Ce projet a été converti depuis une application React vers WPF en conservant la même architecture modulaire et les mêmes fonctionnalités.

**Bon développement ! 🚀**
