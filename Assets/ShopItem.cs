using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public ClickerController clicker;
    public int cost = 10;
    public int powerIncrease = 1;
    public Text costText;
    
    void Start()
    {
        costText.text = "Цена: " + cost;
    }
    
    public void BuyUpgrade()
    {
        if (clicker.score >= cost)
        {
            clicker.score -= cost;
            clicker.clickPower += powerIncrease;
            cost *= 2; // Увеличиваем цену для следующего покупки
            costText.text = "Цена: " + cost;
        }
    }
}