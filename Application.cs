using System;

public class Application
{

	public static Player j1 = new Player();
	public static Bot b1 = new Bot();
	
	public void fonctionPrincipale ()
	{
		//DEBUT de votre programme
			while(true)
			{
				if(tirageAuSort() == j1.pseudo)
				{
					Console.WriteLine(j1.pseudo+" joue");
					if(TourPlayer())
					{
						break;
					}
				}
				else
				{
					Console.WriteLine(b1.nomBot+" joue");
					if(TourBot())
					{
						break;
					}
				}
			}

		//FIN de votre programme
	}

	//DECLAREZ VOS FONCTIONS EN DESSOUS DE CETTE LIGNE

	string tirageAuSort()
	{
		var random = new Random();
		int choix = random.Next(1,3);

		if(choix == 1)
		{
			return j1.pseudo;
		}
		else
		{
			return b1.nomBot;
		}
	}
	int lancerDes(string nomJoueur)
	{
		var random = new Random();
		int de = random.Next(1,7) + random.Next(1,7);

		Console.WriteLine($"{nomJoueur} a lancé les Dés et a obtenu {de}");
		return de;
	}

	bool TourPlayer()
	{
		Console.WriteLine($"{j1.pseudo}, appuyez sur 'Entrée' pour lancer les dés");
		string entre = Utilisateur.saisirTexte();

		int hitStrength = lancerDes(j1.pseudo);
		Console.WriteLine($"{j1.pseudo} lance les dés... {hitStrength}");
		Console.WriteLine($"{j1.pseudo} assène un coup sur le bot avec une force de {hitStrength}");
		b1.santeBot = b1.santeBot - hitStrength;
		Console.WriteLine($"{j1.pseudo} - {j1.santeJoueur}");
		Console.WriteLine($"{b1.nomBot} - {b1.santeBot}");

		if(b1.santeBot <= 0)
		{
			Console.WriteLine(j1.pseudo+" a gagné");
			return true;
		}
		return false;
	}

	bool TourBot()
	{
		int hitStrength = lancerDes(b1.nomBot);
		Console.WriteLine($"{b1.nomBot} lance les dés... {hitStrength}");
		Console.WriteLine($"{b1.nomBot} assène un coup sur le joueur avec une force de {hitStrength}");
		j1.santeJoueur = j1.santeJoueur - hitStrength;
		Console.WriteLine($"{j1.pseudo} - {j1.santeJoueur}");
		Console.WriteLine($"{b1.nomBot} - {b1.santeBot}");

		if(j1.santeJoueur <= 0)
		{
			Console.WriteLine(b1.nomBot+" a gagné");
			return true;
		}
		return false;
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


