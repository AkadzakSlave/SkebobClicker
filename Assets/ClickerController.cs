using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClickerController : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public int clickPower = 1;
    public Transform clickableImage;
    public float shrinkDelta = 0.1f; // Фиксированное значение уменьшения
    public float shrinkTime = 0.1f;

    private Vector3 originalScale;
    private bool isAnimating = false;
    public ParticleSystem clickParticles;
    public Sprite[] particleSprites; // Массив спрайтов для частиц

    void Update()
    {
        scoreText.text = "Очки: " + score;
    }
    void OnMouseDown()
    {
        score += clickPower;
        
        var textureSheetAnimation = clickParticles.textureSheetAnimation;
        textureSheetAnimation.SetSprite(0, particleSprites[Random.Range(0, particleSprites.Length)]);
        
        clickParticles.Play();
        if (!isAnimating)
        {
            StartCoroutine(ShrinkAnimation());
        }
    }
    
    void Start()
    {
        LoadGame();
        originalScale = clickableImage.localScale;  
    }

    void OnApplicationQuit()
    {
        SaveGame();
    }

    void SaveGame()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetInt("ClickPower", clickPower);
    }

    void LoadGame()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        clickPower = PlayerPrefs.GetInt("ClickPower", 1);
    }
    IEnumerator ShrinkAnimation()
    {
        isAnimating = true;
        
        Vector3 shrunkScale = originalScale - new Vector3(shrinkDelta, shrinkDelta, 0);
        float timer = 0;
        while (timer < shrinkTime)
        {
            clickableImage.localScale = Vector3.Lerp(originalScale, shrunkScale, timer/shrinkTime);
            timer += Time.deltaTime;
            yield return null;
        }
        timer = 0;
        while (timer < shrinkTime)
        {
            clickableImage.localScale = Vector3.Lerp(shrunkScale, originalScale, timer/shrinkTime);
            timer += Time.deltaTime;
            yield return null;
        }
        clickableImage.localScale = originalScale;
        isAnimating = false;
    }

}