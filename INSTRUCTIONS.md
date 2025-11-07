# 🍰 SweetBalance - Application WPF .NET Framework 4.7.2

## ✅ C'EST UN VRAI PROJET WPF !

Ce projet est maintenant un **véritable projet WPF .NET Framework 4.7.2** avec le format de fichier .csproj traditionnel XML complet, exactement comme Visual Studio le crée.

### 🎯 Caractéristiques du projet WPF

- **Type de projet** : WPF Application (.NET Framework)
- **Framework cible** : .NET Framework 4.7.2
- **Format .csproj** : XML traditionnel (pas SDK-style)
- **ProjectTypeGuids** : `{60dc8134-eba5-43b8-bcc9-bb4bc16c2548}` (GUID officiel WPF)

## 📋 Structure du projet

```
repos/
├── SweetBalance.sln              ← Fichier solution à ouvrir ✅
│
└── SweetBalance/                 ← Projet WPF .NET Framework
    ├── SweetBalance.csproj       ← Format XML WPF complet ✅
    ├── App.config                ← Configuration .NET Framework ✅
    │
    ├── App.xaml                  ← Point d'entrée WPF
    ├── App.xaml.cs
    │
    ├── Properties/               ← Propriétés WPF standard
    │   ├── AssemblyInfo.cs
    │   ├── Resources.resx
    │   └── Settings.settings
    │
    ├── Models/                   ← 5 modèles métier
    ├── ViewModels/               ← 8 ViewModels MVVM
    ├── Views/                    ← 7 vues XAML
    ├── Helpers/                  ← RelayCommand
    └── Resources/                ← Styles XAML
```

## 🚀 Ouvrir dans Visual Studio 2022

### Méthode recommandée :

1. Lancez **Visual Studio 2022**
2. Menu **Fichier** → **Ouvrir** → **Projet/Solution**
3. Naviguez vers le dossier et sélectionnez : **`SweetBalance.sln`**
4. Cliquez sur **Ouvrir**
5. Le projet WPF s'ouvre dans Visual Studio !

### Pour compiler et exécuter :

- Appuyez sur **F5** (ou **Ctrl+F5** pour sans débogage)
- Ou cliquez sur le bouton **▶️ Démarrer**

Visual Studio va automatiquement :
- Restaurer les packages NuGet (si nécessaire)
- Compiler le projet WPF
- Lancer l'application Windows

## 🔍 Vérification du type de projet

Pour vérifier que c'est bien un projet WPF, ouvrez `SweetBalance.csproj` :

```xml
<Project ToolsVersion="15.0" xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFrameworkVersion>v4.7.2</TargetFrameworkVersion>

    <!-- GUID officiel pour les projets WPF -->
    <ProjectTypeGuids>{60dc8134-eba5-43b8-bcc9-bb4bc16c2548};{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}</ProjectTypeGuids>
  </PropertyGroup>

  <ItemGroup>
    <!-- Références WPF obligatoires -->
    <Reference Include="System.Xaml" />
    <Reference Include="WindowsBase" />
    <Reference Include="PresentationCore" />
    <Reference Include="PresentationFramework" />
  </ItemGroup>
</Project>
```

## ✨ Fonctionnalités

### Module Stocks (100% fonctionnel)

- ✅ Interface WPF moderne
- ✅ Gestion complète des ingrédients (CRUD)
- ✅ Ajustement des quantités avec boutons +/-
- ✅ Alertes visuelles pour stocks faibles
- ✅ Calcul de valeur totale en temps réel
- ✅ Formulaire modal avec validation
- ✅ Design rose/violet avec dégradés

### Modules à développer

Structure MVVM prête pour :
- Recettes
- Devis
- Commandes
- Production
- Statistiques
- Paramètres

## 🏗️ Architecture MVVM

```
Models (Données)
   ↓
ViewModels (Logique + INotifyPropertyChanged)
   ↓
Views (XAML + Data Binding)
```

### Exemple de binding WPF :

**XAML (View):**
```xml
<TextBox Text="{Binding CurrentStock.Nom, UpdateSourceTrigger=PropertyChanged}"/>
<Button Command="{Binding SaveCommand}" Content="Enregistrer"/>
```

**C# (ViewModel):**
```csharp
public class StockViewModel : ObservableObject
{
    private Stock _currentStock;

    public Stock CurrentStock
    {
        get => _currentStock;
        set => SetProperty(ref _currentStock, value);
    }

    public ICommand SaveCommand { get; }
}
```

## 📦 Prérequis

- **Windows 10/11**
- **Visual Studio 2022** (Community, Professional ou Enterprise)
  - Avec la charge de travail **"Développement .NET Desktop"**
- **.NET Framework 4.7.2 Developer Pack**
  - Inclus avec Visual Studio 2022

## 🎯 Technologies

| Technologie | Version | Usage |
|-------------|---------|-------|
| WPF | .NET Framework 4.7.2 | Interface utilisateur |
| C# | 7.3+ | Langage de programmation |
| XAML | - | Markup pour l'UI |
| MVVM | - | Pattern d'architecture |

## 🔧 Compilation en ligne de commande

Si vous avez MSBuild :

```cmd
cd SweetBalance

REM Restaurer les packages NuGet
nuget restore

REM Compiler
msbuild SweetBalance.csproj /p:Configuration=Release

REM Exécuter
bin\Release\SweetBalance.exe
```

## 📝 Points importants

### C'est bien un projet WPF parce que :

1. ✅ **ProjectTypeGuids** contient `{60dc8134-eba5-43b8-bcc9-bb4bc16c2548}` (GUID WPF)
2. ✅ **Références WPF** : System.Xaml, WindowsBase, PresentationCore, PresentationFramework
3. ✅ **OutputType** : WinExe (application Windows)
4. ✅ **Format .csproj** : XML complet traditionnel
5. ✅ **App.xaml** : Point d'entrée WPF
6. ✅ **App.config** : Configuration .NET Framework
7. ✅ **Fichiers XAML** : Interfaces utilisateur WPF

### Différence avec un projet C# console :

| Projet WPF | Projet Console C# |
|-----------|------------------|
| ProjectTypeGuids WPF | Pas de ProjectTypeGuids |
| Références WPF | Pas de références WPF |
| App.xaml | Program.cs |
| OutputType: WinExe | OutputType: Exe |
| Interface graphique XAML | Interface console texte |

## 🐛 Dépannage

### Erreur "Type de projet non supporté"

→ Installez la charge de travail "Développement .NET Desktop" dans Visual Studio

### Erreur ".NET Framework 4.7.2 non trouvé"

→ Installez le .NET Framework 4.7.2 Developer Pack depuis le Visual Studio Installer

### Erreur de compilation XAML

→ Vérifiez que les fichiers .xaml ont bien la propriété "Build Action: Page"

## 📚 Ressources

- [Documentation WPF officielle Microsoft](https://docs.microsoft.com/fr-fr/dotnet/desktop/wpf/)
- [Pattern MVVM](https://docs.microsoft.com/fr-fr/dotnet/architecture/maui/mvvm)
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/download/dotnet-framework/net472)

---

## ✅ Checklist de vérification

Votre projet est un vrai projet WPF si :

- [x] Le fichier .csproj contient `ProjectTypeGuids` avec le GUID WPF
- [x] Il y a des références à `PresentationFramework`, `PresentationCore`, `WindowsBase`
- [x] Il y a un fichier `App.xaml` avec `Application` comme élément racine
- [x] Il y a un fichier `App.config` pour .NET Framework
- [x] Les fichiers `.xaml` utilisent des contrôles WPF (Window, UserControl, etc.)
- [x] Le projet s'ouvre correctement dans Visual Studio comme "Application WPF"

**Toutes ces conditions sont remplies ✅**

---

**Note** : Ce projet a été converti depuis React vers WPF .NET Framework en conservant l'architecture MVVM et les fonctionnalités.

**Bon développement ! 🚀**
