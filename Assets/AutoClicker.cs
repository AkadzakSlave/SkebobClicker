using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoClicker : MonoBehaviour
{
    public ClickerController clicker;
    public int cost = 50;
    public float interval = 1f; // Как часто добавляются очки
    public int pointsPerInterval = 1;
    public Text costText;
    
    private int autoClickerCount = 0;
    
    void Start()
    {
        costText.text = "Цена: " + cost;
        InvokeRepeating("AddAutoPoints", interval, interval);
    }
    
    public void BuyAutoClicker()
    {
        if (clicker.score >= cost)
        {
            clicker.score -= cost;
            autoClickerCount++;
            cost = (int)(cost * 1.5f); // Увеличиваем цену
            costText.text = "Цена: " + cost;
        }
    }
    
    void AddAutoPoints()
    {
        if (autoClickerCount > 0)
        {
            clicker.score += autoClickerCount * pointsPerInterval;
        }
    }
}
