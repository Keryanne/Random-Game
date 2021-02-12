using System;

public class Application
{
	public void fonctionPrincipale ()
	{
		//DEBUT de votre programme
		Bot bot = new Bot();
		Console.Write("Quel est votre pseudo ? ");
		String pseudo = Utilisateur.saisirTexte();

		bot.force = 1;
		int nbTour = 1;

		do
		{
			Console.WriteLine($"{pseudo}, appuyez sur 'Entrée' pour lancer les dés");
			string entre = Utilisateur.saisirTexte();
			int hitStrength = lancerDes(pseudo);
			Console.WriteLine($"{pseudo} lance les dés... {hitStrength}");
			Console.WriteLine($"{pseudo} assène un coup sur le bot avec une force de {hitStrength}");
			bot.sante = bot.sante - hitStrength;

			if(bot.sante >= 0)
			{
				Console.WriteLine($"Bot - Santé {bot.sante}%");
				Console.WriteLine($"Fin du tour {nbTour} \n");
			}
			else
			{
				Console.WriteLine($"Fin du tour {nbTour} \n");
			}

			nbTour++;

		}while(bot.sante >= 0);
				
		Console.WriteLine("Vous gagné la partie !");
		
		//FIN de votre programme
	}

	//DECLAREZ VOS FONCTIONS EN DESSOUS DE CETTE LIGNE

	int lancerDes(string nomJoueur)
	{
		var random = new Random();
		int de = random.Next(1,7) + random.Next(1,7);

		Console.WriteLine($"{nomJoueur} a lancé les Dés et a obtenu {de}");
		return de;
		
	}

	/* EXEMPLES DE PROCEDURES ET FONCTIONS :
	
		void uneProcedure(int param1, int param2)
		{
			Console.WriteLine(param1+param2);
		{
		
		int uneFonction(int param1, int param2)
		{
			int resultat = 0;
			resultat = param1 + param2;
			return resultat;
		}
		
		
		*/

	//NE PAS TOUCHER LE CODE EN DESSOUS DE CETTE LIGNE
}


