using System;

public class Application
{
	public void fonctionPrincipale ()
	{
		//DEBUT de votre programme


		do
		{

			if(TourPlayer() <= 0)
			{
				Console.WriteLine("Le joueur a gagné la partie !");
				break;
			}
			if(TourBot() <= 0)
			{
				Console.WriteLine("Le bot a gagné la partie !");
				break;
			}

		}while(TourPlayer() >= 0 && TourBot() >= 0);
				
		
		
		//FIN de votre programme
	}

	//DECLAREZ VOS FONCTIONS EN DESSOUS DE CETTE LIGNE

	void DonneeJoueur(Player j1)
	{
		j1.pseudo = "RomainG";
		j1.forceJoueur = 1;
	}

	void DonneeBot(Bot bot)
	{
		bot.nomBot = "RomainJoyeux";
		bot.forceBot = 1;
	}
	int lancerDes(string nomJoueur)
	{
		var random = new Random();
		int de = random.Next(1,7) + random.Next(1,7);

		Console.WriteLine($"{nomJoueur} a lancé les Dés et a obtenu {de}");
		return de;
	}

	int TourPlayer()
	{
		Player j1 = new Player();
		DonneeJoueur(j1);
		Console.WriteLine($"{j1.pseudo}, appuyez sur 'Entrée' pour lancer les dés");
		string entre = Utilisateur.saisirTexte();

		int hitStrength = lancerDes(j1.pseudo);
		Console.WriteLine($"{j1.pseudo} lance les dés... {hitStrength}");
		Console.WriteLine($"{j1.pseudo} assène un coup sur le bot avec une force de {hitStrength}");
		j1.santeJoueur = j1.santeJoueur - hitStrength;
		Console.WriteLine($"{j1.pseudo} - {j1.santeJoueur}");

		return j1.santeJoueur;
	}

	int TourBot()
	{
		Bot b1 = new Bot();
		DonneeBot(b1);

		int hitStrength = lancerDes(b1.nomBot);
		Console.WriteLine($"{b1.nomBot} lance les dés... {hitStrength}");
		Console.WriteLine($"{b1.nomBot} assène un coup sur le joueur avec une force de {hitStrength}");
		b1.santeBot = b1.santeBot - hitStrength;
		Console.WriteLine($"{b1.nomBot} - {b1.santeBot}"
		);

		return b1.santeBot;
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


