using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class LifeSystem : MonoBehaviour
{
    public int maxLife = 3; // Cantidad máxima de vida
    private Stack<Image> heartStack = new Stack<Image>(); // Pila de corazones

    public Image heartPrefab; // Prefab del corazón
    public Transform heartParent; // Padre para los corazones

    void Start()
    {
        InitializeHearts();
        UpdateHeartsVisual();
    }

    void InitializeHearts()
    {
        for (int i = 0; i < maxLife; i++)
        {
            Image newHeart = Instantiate(heartPrefab, heartParent);
            newHeart.gameObject.SetActive(true);
            heartStack.Push(newHeart);
        }
    }

    void UpdateHeartsVisual()
    {
        foreach (Image heart in heartStack)
        {
            heart.enabled = true;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        for (int i = 0; i < damageAmount; i++)
        {
            if (heartStack.Count > 0)
            {
                Image heart = heartStack.Pop();
                Destroy(heart.gameObject);
            }
            else
            {
                Debug.LogError("Player is already dead!");
                // Aquí puedes manejar lo que sucede cuando el jugador está muerto
            }
        }
    }

    public void GainLife(int lifeAmount)
    {
        for (int i = 0; i < lifeAmount; i++)
        {
            if (heartStack.Count < maxLife)
            {
                Image newHeart = Instantiate(heartPrefab, heartParent);
                newHeart.gameObject.SetActive(true);
                heartStack.Push(newHeart);
            }
            else
            {
                Debug.LogWarning("Player life is already at maximum!");
                // Aquí puedes manejar lo que sucede cuando la vida del jugador ya está en el máximo
            }
        }
    }
}
