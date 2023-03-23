using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower
{
    public string Name;
    public int type, Price;
    public float range, Cooldown, CurrCooldown = 0;
    public Sprite Spr;

    public Tower(string Name, int type, float range, float cd, int Price, string path)
    {
        this.Name = Name;
        this.type = type;
        this.range = range;
        Cooldown = cd;
        this.Price = Price;
        Spr = Resources.Load<Sprite>(path);
    }
}

public class TowerProjectile
{
    public float speed;
    public int damage;
    public Sprite Spr;

    public TowerProjectile(float speed, int dmg, string path)
    {
        this.speed = speed;
        damage = dmg;
        Spr = Resources.Load<Sprite>(path);

    }
}

public class Enemy
{
    public float Health, Speed, StartSpeed;
    public Sprite spr;

    public Enemy(float health, float speed, string sprPath)
    {
        Health = health;
        StartSpeed = Speed = speed;
        spr = Resources.Load<Sprite>(sprPath);
    }

    public Enemy(Enemy other)
    {
        Health = other.Health;
        StartSpeed = Speed = other.StartSpeed;
        spr = other.spr;
    }
}

public enum TowerType
{
    FIRST_TOWER,
    SECOND_TOWER
}

public class GameControllerScr : MonoBehaviour
{
    public List<Tower> AllTowers = new List<Tower>();
    public List<TowerProjectile> AllProjectiles = new List<TowerProjectile>();
    public List<Enemy> AllEnemies = new List<Enemy> ();

    public void Awake()
    {
        AllTowers.Add(new Tower("Archer Tower", 0, 2, 2f, 10, "TowerSprites/archer_level_1"));
        AllTowers.Add(new Tower("Wizard Tower", 1, 5, 1, 25, "TowerSprites/wizard_level_1"));

        AllProjectiles.Add(new TowerProjectile(9, 10, "ProjectileSprites/arrow"));
        AllProjectiles.Add(new TowerProjectile(6, 15, "ProjectileSprites/wisp"));

        AllEnemies.Add(new Enemy(30, 3, "EnemySprites/bandit"));
        AllEnemies.Add(new Enemy(45, 4, "EnemySprites/sprout"));
    }
}
