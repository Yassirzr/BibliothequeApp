using System;
using System.Collections.Generic;
using System.IO;



namespace BibliothequeApp
{
    public class Bibliotheque
    {
        // Liste qui contient tous les documents
        private List<Document> documents = new List<Document>();

        // Ajouter un document
        public void AjouterDocument(Document doc)
        {
            documents.Add(doc);
        }

        // Afficher tous les documents
        public void AfficherTous()
        {
            if (documents.Count == 0)
            {
                Console.WriteLine("La bibliothèque est vide.");
                return;
            }

            foreach (var doc in documents)
            {
                doc.AfficherDetails();
            }
        }

        // Rechercher par mot-clé
        public void Rechercher(string motCle)
        {
            bool trouve = false;

            foreach (var doc in documents)
            {
                if (doc.Titre.Contains(motCle, StringComparison.OrdinalIgnoreCase) ||
                    doc.Auteur.Contains(motCle, StringComparison.OrdinalIgnoreCase))
                {
                    doc.AfficherDetails();
                    trouve = true;
                }
            }

            if (!trouve)
            {
                Console.WriteLine("Aucun document trouvé !");
            }
        }

        // Supprimer par ID
        public void Supprimer(Guid id)
        {
            Document docASupprimer = null;

            foreach (var doc in documents)
            {
                if (doc.Id == id)
                {
                    docASupprimer = doc;
                    break;
                }
            }

            if (docASupprimer != null)
            {
                documents.Remove(docASupprimer);
                Console.WriteLine("Document supprimé avec succès.");
            }
            else
            {
                Console.WriteLine("Document non trouvé.");
            }
        }
        // Sauvegarder les documents dans un fichier texte
        public void Sauvegarder(string cheminFichier)
        {
            try
            {using (var writer = new StreamWriter(cheminFichier))
                {foreach (var doc in documents)
                    { writer.WriteLine($"{doc.GetType().Name};{doc.Id};{doc.Titre};{doc.Auteur};{doc.Annee}");
                    }
                }
                Console.WriteLine("Sauvegarde effectuée avec succès !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la sauvegarde : " + ex.Message);
            }
        }
        // Charger les documents depuis un fichier texte
        public void Charger(string cheminFichier)
        {
            try
            {
                if (!File.Exists(cheminFichier))
                {
                    Console.WriteLine("Fichier introuvable.");
                    return;
                }

                documents.Clear();
                var lignes = File.ReadAllLines(cheminFichier);

                foreach (var ligne in lignes)
                {
                    var parts = ligne.Split(';');
                    if (parts.Length < 5) continue;

                    string type = parts[0];
                    Guid id = Guid.Parse(parts[1]);
                    string titre = parts[2];
                    string auteur = parts[3];
                    int annee = int.Parse(parts[4]);

                    Document doc = null;

                    if (type == "Livre")
                        doc = new Livre(id, titre, auteur, annee, 0); 
                    else if (type == "Magazine")
                        doc = new Magazine(id, titre, auteur, annee, 0);
                    else if (type == "DocumentPDF")
                        doc = new DocumentPDF(id, titre, auteur, annee, 0);

                    documents.Add(doc);
                }

                Console.WriteLine("Chargement effectué avec succès !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors du chargement : " + ex.Message);
            }
        }

    }

}

