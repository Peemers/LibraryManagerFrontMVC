# 📚 LibraryManager - Interface Web (MVC)

Ce projet est l'application front-end développée en **ASP.NET Core MVC**. Elle permet aux utilisateurs de naviguer dans le catalogue de la bibliothèque, de gérer leurs emprunts et aux administrateurs de piloter l'inventaire via une interface web moderne et réactive.

## 🏗️ Architecture du Projet

L'application suit le pattern **Model-View-Controller (MVC)** et communique avec l'API LibraryManager via des appels REST :

* **Controllers** (`Auth`, `Livre`) : Orchestrent la logique de navigation et traitent les formulaires.
* **Services** (`AuthService`, `LivreService`) : Encapsulent la logique de communication HTTP avec l'API.
* **Handlers** (`AuthTokenHandler`) : Intercepte les requêtes sortantes pour injecter automatiquement le token JWT.
* **Views** : Interfaces utilisateur dynamiques construites avec Razor et Bootstrap 5.
* **Dtos/Models** : Objets de transfert de données synchronisés avec les contrats de l'API.

## 🚀 Technologies Utilisées

* **Framework** : ASP.NET Core MVC 8.0 / 10.0
* **UI** : Bootstrap 5, Razor Pages, jQuery
* **Gestion d'Authentification** : Cookie-based authentication (stockage sécurisé du token JWT)
* **Client HTTP** : IHttpClientFactory avec Typed Clients

## 🛠️ Installation et Configuration

1.  **Prérequis** :
    * Le projet [LibraryManager API] doit être opérationnel.
    * SDK .NET installé.

2.  **Configuration de l'URL API** :
    Dans `LibraryManagerFrontMvc/appsettings.json`, configurez l'URL de votre API :
    ```json
    "ApiSettings": {
      "BaseUrl": "https://localhost:7155/api/"
    }
    ```

3.  **Lancement** :
    ```bash
    dotnet run --project LibraryManagerFrontMvc
    ```

## 🖥️ Fonctionnalités implémentées

### 🔑 Authentification
* **Connexion / Inscription** : Gestion des sessions utilisateurs.
* **Sécurisation** : Utilisation d'un `AuthTokenHandler` qui ajoute le header `Authorization: Bearer <token>` à chaque requête vers l'API.
* **Déconnexion** : Suppression des cookies de session.

### 📖 Gestion des Livres
* **Catalogue** : Visualisation de tous les livres avec leur statut actuel (Disponible / Emprunté).
* **Administration (Admin only)** : Formulaire d'ajout de nouveaux livres avec validation.

### 👥 Profil & Rôles
* Gestion de l'affichage dynamique dans `_Layout.cshtml` : les options "Ajouter un livre" ou "Admin" n'apparaissent que si l'utilisateur possède le rôle adéquat.

## 📂 Structure des fichiers principaux

* `AuthTokenHandler.cs` : Élément clé pour la persistance de la connexion.
* `LivreService.cs` : Gère les appels aux endpoints `/api/Livre`.
* `_Layout.cshtml` : Structure globale et menu de navigation dynamique.

## 🛣️ Routes Principales

| Page | Route | Description |
| :--- | :--- | :--- |
| **Accueil / Livres** | `/Livre/Index` | Liste de tous les livres. |
| **Ajout Livre** | `/Livre/Create` | Formulaire de création (Admin). |
| **Connexion** | `/Auth/Login` | Formulaire de login. |
| **Inscription** | `/Auth/Register` | Création de compte. |

## 📄 Licence
Ce projet est sous licence MIT.
