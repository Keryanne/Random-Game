using System;
class Player
{
    private string nickname;
    private int strength = 1;
    private int health = 100;
	private Weapon weapon = new Weapon("Batte de Baseball", 1, 100);
	
	private ConsoleManager console = new ConsoleManager();

	public void receiveDamage(int damage) {
		this.health = this.health - Math.Min(this.health, damage);
	}

	public Player(string nickname) {
		this.nickname = nickname;
	}

    public bool isAlive() {
        return this.health > 0;
    }
    public void rest() {
		if (health < 100) {
			int healthGain = rollDices() * 5;
			this.health = Math.Min(100, this.health + healthGain);
			console.println(nickname + " a pu se soigner, sa santé est maintenant de " + health + "%");
		}
    }
    public void didWinBot(Bot botVaincu) {
        this.strength = this.strength + botVaincu.getStrength();
    }
    public void display() 
	{
		console.println($"{this.nickname} - santé {this.health}% - Force {this.strength}");
	}

	public void pickUpWeapon(Weapon newWeapon) {
		this.weapon = newWeapon;
	}

	public void chooseNextMove(Bot bot) {
		if (bot.isAlive() && this.isAlive()) {
			int userChoice = 1;
			if (health < 60) {
				userChoice = console.requestUserPick("Tapez 1 pour attaquer ou 2 pour vous soigner à la place", 1, 2);
			}
			switch(userChoice) {
				case 1:
					attackBot(bot);
					break;
				case 2:
					rest();
					break;
				default:
					break;
			}
		}
	}

    public void attackBot(Bot bot) {	
		
		var generator = new Random();
		if (generator.Next(1,101) < weapon.getAccuracy()) {
			int hitStrength = rollDices() * (this.strength + this.weapon.getPower());
			console.println(nickname + " a frappé le Bot avec une force de " + hitStrength);
			bot.receiveDamage(hitStrength);
		} else {
			console.println(nickname + " a manqué son tir");
		}
		
	}

    public int rollDices() {
		console.confirm("Appuyez sur entrée pour lancer les dés");
		int dicesValue;
		var generator = new Random();
		dicesValue = generator.Next(1, 7) + generator.Next(1, 7);
		console.println(this.nickname + " a lancé les dés et obtenu " + dicesValue);
		return dicesValue;
	}
}