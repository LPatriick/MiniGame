using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIUP : MonoBehaviour
{
    [Header("Hearts")]
    public Image[] hearts;
    public Sprite fHeart;
    public Sprite eHeart;
    public int health = 3;
    private int crHearts;
    [Header("Timer")]
    public TextMeshProUGUI timerText;
    private float timer;
    private bool isAlive = true;
    void Start()
    {
        crHearts = health;
        UpdateH();
    }

    void Update()
    {
        if (isAlive)
        {
            timer += Time.deltaTime;
            timerText.text = timer.ToString("F2") + "s";
        }
    }

    public void Damage()
    {
        if(crHearts >= 0)
        {
            crHearts--;
            UpdateH();
        }
        if(crHearts <= 0)
        {
            Die();
        }
    }
    void UpdateH()
    {
        for(int i = 0; i <hearts.Length; i++)
        {
            if (i < crHearts)
            {
                hearts[i].sprite = fHeart;
            }
            else
            {
                hearts[i].sprite = eHeart;
            }
        }
    }
    void Die()
    {
        isAlive = false;
        timerText.text += " - Game Over!";
    }
    public void StopTime()
    {
        isAlive = false;
    }
}
