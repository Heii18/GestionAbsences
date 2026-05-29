# Application de Gestion des Absences - BTS SIO Bloc 2

>  **https://www.youtube.com/watch?v=K5zS_tnf_8E**

---

## Présentation du Projet
Ce projet s'inscrit dans le cadre de l'évaluation du **Bloc 2 (Conception et développement d'applications)** du **BTS SIO**. L'objectif est de fournir une application lourde (Windows Forms) permettant la gestion complète du personnel d'une structure (MediaTek86) ainsi que le suivi rigoureux de leurs absences (congés, maladies, motifs familiaux, etc.).

L'application respecte les critères d'ergonomie, de sécurité d'accès et d'intégrité relationnelle exigés par le référentiel du CNED.

---

## Fonctionnalités Principales
* **Authentification Sécurisée :** Contrôle d'accès pour les responsables (mots de passe hachés en SHA-256 stockés en base de données).
* **Gestion du Personnel (CRUD) :** Affichage, ajout, modification et suppression des membres du personnel rattachés à un service spécifique (Administratif, Médiation culturelle, Prêt).
* **Gestion des Absences (CRUD) :** Suivi par membre du personnel (Date de début, Date de fin, Motif de l'absence).
* **Intégrité des Données :** Gestion stricte des clés primaires composées (`idpersonnel`, `datedebut`) et des contraintes d'intégrité référentielle.

---

## Architecture Technique & Stack
* **Langage :** C# (.NET Framework / Windows Forms)
* **Base de données :** MySQL (Moteur de stockage : MyISAM / InnoDB)
* **Architecture logicielle :** Motif **MVC (Modèle-Vue-Contrôleur)** / Architecture multi-couches garantissant une séparation claire entre l'interface utilisateur, la logique métier et l'accès aux données (`BddManager.cs`).

---

## Configuration de la Base de Données
Le script SQL (`gestionabsences.sql`) situé à la racine du projet inclut la création automatique de l'environnement nécessaire ainsi que les droits d'accès.

### Informations de Connexion Applicatives :
* **Nom de la base :** `gestionabsences`
* **Utilisateur SQL dédié :** `admin`
* **Mot de passe SQL :** `admin2026`

 *Le script SQL applique automatiquement l'instruction `GRANT ALL PRIVILEGES` sur la base de données pour cet utilisateur, assurant une étanchéité parfaite de l'environnement de test.*

---

## Déploiement & Installation
L'application a été empaquetée et publiée via l'outil de déploiement **ClickOnce** de Visual Studio.
* **Fichier d'installation :** `setup.exe` (génère l'installation automatique du client lourd sur le poste utilisateur).
* **Gestion des versions :** Prise en charge automatique des mises à jour lors de la publication de nouvelles versions.

---

## Compétences Validées (Référentiel Bloc 2)
1.  **Gérer le patrimoine applicatif :** Exploitation, correction de bogues (méthodes d'ouverture/clôture de connexion dans `BddManager.cs`) et optimisation de code existant.
2.  **Développer des composants applicatifs :** Implémentation des requêtes préparées SQL et liaison dynamique des objets métiers aux contrôles graphiques (`ComboBox`, `DataGridView`).
3.  **Concevoir et développer une application :** Respect des maquettes et du modèle conceptuel de données (MCD).
