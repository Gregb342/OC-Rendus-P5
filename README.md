# OC-Rendus-P5 - ExpressVoitures

## Description du projet

ExpressVoitures est une application ASP.NET Core développée dans le cadre de la formation "Développeur d'application back-end .NET" du site OpenClassRooms.com

L'application correspond au projet 5 : Créez votre première application avec ASP .NET Core

Le but de cette application est de gérer un inventaire de voitures. 

L'application permet aux utilisateurs (administrateurs) de créer, modifier, et consulter les informations sur des véhicules, incluant des données sur les achats, les réparations, les ventes, et les médias associés. 

Ce projet respecte les principes de l'architecture MVC (Model-View-Controller) et s'appuie sur plusieurs services et repositories pour assurer la séparation des préoccupations.

## Fonctionnalités principales

- **Gestion des voitures** : Créer, éditer, supprimer et consulter des voitures.
- **Gestion des médias** : Attacher des médias (images, vidéos) à chaque voiture.
- **Suivi des transactions** : Gérer les achats, ventes et réparations des voitures.
- **Recherche et filtrage** : Rechercher des voitures par marque, modèle, finition, etc.
- **Utilisation d'ASP.NET Identity** : Authentification des administrateurs avec un compte préenregistré.
  
## Architecture

Le projet utilise une architecture basée sur le pattern **Repository-Service** et **MVC** avec les composants suivants :

- **Models** : Contiennent les entités représentant les données de l'application (par ex. : `Car`, `CarBrand`, `CarModel`, `Purchase`, etc.).
- **ViewModels** : Facilitent la présentation des données dans les vues.
- **Repositories** : Interagissent avec la base de données via Entity Framework Core (par ex. : `CarRepository`, `CarBrandRepository`).
- **Services** : Logique métier encapsulée dans des services (par ex. : `CarService`, `PurchaseService`, `SaleService`).
- **Controllers** : Gèrent les requêtes HTTP et orchestrent les interactions entre le service, les modèles et les vues.

## Prérequis

Avant de cloner et exécuter ce projet, assurez-vous d'avoir installé les éléments suivants :

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) ou toute autre base de données compatible avec Entity Framework Core.
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) (de préférence) ou tout autre IDE supportant .NET 6.

## Installation

1. Clonez le dépôt GitHub :
   ```bash
   git clone https://github.com/Gregb342/OC-Rendus-P5
   cd oc-rendus-p5```

2.  Il suffit de lancer le projet, via IIS Express sur Chrome, Edge ou Firefox, la base sera automatique créée et peuplée et vous pourrez utiliser tout de suite l'application en démonstration.

**NOTE** : Si vous souhaitez utiliser une autre base de donnée, la chaine de configuration se trouve dans appsettings.json

## Authentification

Le projet contient des données en seed qui se peuplent automatiquement dés le premier lancement du projet, y compris un login et un mot de passe admin :

**Login** : admin@express-voitures.com
**Mot de passe** : Admin@123

Ces éléments de connexion n'existent que dans un cadre de demonstration et doivent être supprimé et recréé de façon sécurisé si jamais l'application est utilisée dans un cadre réel un jour.

## Auteur 

Gregoire Bouteilier (c) 2024
