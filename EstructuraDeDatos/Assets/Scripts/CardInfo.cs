using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardInfo : MonoBehaviour
{
    public EnemyScript InfoEnemy;
    [SerializeField] private TMP_Text NameEnemy;
    [SerializeField] private TMP_Text HealthEnemy;
    [SerializeField] private Image SpriteEnemy;

    public void Showinfo() 
    {
        NameEnemy.text = InfoEnemy.name;
        HealthEnemy.text = InfoEnemy.health.ToString();
        SpriteEnemy.sprite = InfoEnemy.EnemySprite;
    
    }

}
