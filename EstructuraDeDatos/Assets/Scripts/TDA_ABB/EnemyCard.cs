using UnityEngine;

[System.Serializable]
public class EnemyCard
{
    public string enemyName;
    public int enemyHealth;
    public Sprite enemySprite;

    public EnemyCard(string name, int health, Sprite sprite)
    {
        enemyName = name;
        enemyHealth = health;
        enemySprite = sprite;
    }
}