using System;
using BibliothequeApp;

Bibliotheque biblio = new Bibliotheque();


bool quitter = false;

while (!quitter)
{
    Console.WriteLine("\n--- MENU BIBLIOTHÈQUE ---");
    Console.WriteLine("1. Ajouter un document");
    Console.WriteLine("2. Afficher tous les documents");
    Console.WriteLine("3. Rechercher un document");
    Console.WriteLine("4. Supprimer un document");
    Console.WriteLine("5. Sauvegarder dans un fichier");
    Console.WriteLine("6. Charger depuis un fichier");
    Console.WriteLine("7. Quitter");

    Console.Write("Choix : ");
    string choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            Console.WriteLine("Type de document ? (1 = Livre, 2 = Magazine, 3 = PDF)");
            string type = Console.ReadLine();

            Console.Write("Titre : ");
            string titre = Console.ReadLine();

            Console.Write("Auteur : ");
            string auteur = Console.ReadLine();

            Console.Write("Année : ");
            int annee = int.Parse(Console.ReadLine());

            Guid id = Guid.NewGuid();

            if (type == "1")
            {
                Console.Write("Nombre de pages : ");
                int pages = int.Parse(Console.ReadLine());
                biblio.AjouterDocument(new Livre(id, titre, auteur, annee, pages));
            }
            else if (type == "2")
            {
                Console.Write("Numéro du magazine : ");
                int num = int.Parse(Console.ReadLine());
                biblio.AjouterDocument(new Magazine(id, titre, auteur, annee, num));
            }
            else if (type == "3")
            {
                Console.Write("Taille en Mo : ");
                double taille = double.Parse(Console.ReadLine());
                biblio.AjouterDocument(new DocumentPDF(id, titre, auteur, annee, taille));
            }
            else
            {
                Console.WriteLine("Type invalide !");
            }

            Console.WriteLine("Document ajouté avec succès !");

            break;

        case "2":
            biblio.AfficherTous();

            break;

        case "3":
            Console.Write("Mot-clé : ");
            string mot = Console.ReadLine();

            biblio.Rechercher(mot);

            break;

        case "4":
            Console.Write("ID du document à supprimer : ");
            string idStr = Console.ReadLine();

            if (Guid.TryParse(idStr, out Guid idSup))
            {
                biblio.Supprimer(idSup);
            }
            else
            {
                Console.WriteLine("ID invalide !");
            }

            break;

        case "5":
            Console.Write("Nom du fichier de sauvegarde : ");
            string fichier = Console.ReadLine();

            biblio.Sauvegarder(fichier);

            break;

        case "6":
            Console.Write("Nom du fichier à charger : ");
            string fichierC = Console.ReadLine();

            biblio.Charger(fichierC);

            break;

        case "7":
            quitter = true;
            break;

        default:
            Console.WriteLine("Choix invalide !");
            break;
    }
}

Console.WriteLine("Programme terminé.");
