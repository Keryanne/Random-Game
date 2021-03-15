using System;
class Bot
{
    private int strength;
    private int health = 100;

    public Bot(int s) {
        this.strength = s;
        Console.WriteLine("Un Bot vient vous affronter");
        this.display();
    }

    public Bot() : this(1) {
        
    }

    public int getStrength() {
        return this.strength;
    }

    public void receiveDamage(int damage) {
		this.health = this.health - Math.Min(this.health, damage);
	}

    public bool isAlive() {
        return this.health > 0;
    }

    public void display()
	{
		Console.WriteLine("Bot - santé {0}% - Force {1}", this.health, this.strength);
	}

    public void attackPlayer(Player player) {
		if (this.health > 0 && player.isAlive()) {
			var generator = new Random();
			int hitStrength = generator.Next(1, 11) * this.strength;
			Console.WriteLine($"Le Bot vous frappe avec une force de {hitStrength}");
			// player.health = player.health - hitStrength;
            player.receiveDamage(hitStrength);
		}
		
	}
}