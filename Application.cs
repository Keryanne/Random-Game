﻿using System;

public class Application
{
    ConsoleManager console = new ConsoleManager();

    public void fonctionPrincipale ()
    {
        //DEBUT de votre programme
        console.println("Quel est votre pseudo ?");
        string username = Utilisateur.saisirTexte();
        Player p1 = new Player(username);

        int nbBotsVaincus = 0;
        do {	
            Bot b1 = new Bot((nbBotsVaincus + 1) * 2);
            p1.rest();
            fight(p1, b1);
            if (p1.isAlive()) {
                nbBotsVaincus++;
            }
        } while (p1.isAlive());
        console.println($"Vous avez vaincu {nbBotsVaincus} avant de succomber");
        //FIN de votre programme
    }

    //DECLAREZ VOS FONCTIONS EN DESSOUS DE CETTE LIGNE
	
    void fight(Player p1, Bot b1) {
        console.println("Lancer les dés pour savoir qui attaque en premier");
        int dicesValue = p1.rollDices();
        while (b1.isAlive() && p1.isAlive()) {
            if (dicesValue % 2 == 0) {
                p1.chooseNextMove(b1);
                b1.attackPlayer(p1);
            } else {
                b1.attackPlayer(p1);
                p1.chooseNextMove(b1);
            }
			
            b1.display();
            p1.display();
        }
		
        if (p1.isAlive()) {
            console.println("Vous avez gagné! GG!");
            p1.didWinBot(b1);
            if (console.askYesNo("Une nouvelle arme est disponible. Voulez-vous la récupérer ?")) {
                p1.pickUpWeapon(new Weapon("Bombe banane", 20, 50));
            }
        } else {
            console.println("Vous avez été vaincu par le Bot :(");
        }
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