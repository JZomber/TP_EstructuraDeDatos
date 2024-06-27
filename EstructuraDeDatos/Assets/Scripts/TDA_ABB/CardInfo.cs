using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfo : MonoBehaviour
{
    [SerializeField] private TMP_Text NameEnemy;
    [SerializeField] private TMP_Text HealthEnemy;
    [SerializeField] private Image SpriteEnemy;

    public void ShowInfo(EnemyCard enemyCard)
    {
        NameEnemy.text = enemyCard.enemyName;
        HealthEnemy.text = enemyCard.enemyHealth.ToString();
        SpriteEnemy.sprite = enemyCard.enemySprite;
    }
}