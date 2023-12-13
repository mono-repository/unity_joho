using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public TextMeshProUGUI healthText;
    public Slider spSlider;
    public int maxSP = 100;
    public int currentSP = 0;
    public TextMeshProUGUI spText;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private hogehoge h;
    // Start is called before the first frame update
    void Start()
    {
        h = GameObject.Find("Main Camera").GetComponent<hogehoge>();

        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealthText();
        UpdateSPText();
        UpdateScoreText();
    }

    private void GameOver()
    {
        Application.Quit();

        // In editor
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthSlider.value = currentHealth;
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Debug.Log("Player defeated!");
            GameOver();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();

        if (currentHealth <= 30)
        {
            healthText.color = Color.red;
        }
    }

    public void AddSP(int amount)
    {
        currentSP += amount;
        if (currentSP > maxSP)
        {
            currentSP = maxSP;
        }
        spSlider.value = currentSP;
    }

    public void ActivateSP()
    {
        if (currentSP >= maxSP)
        {
            GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
            foreach (GameObject bullet in bullets)
            {
                Destroy(bullet.gameObject);
            }

            currentSP = 0;
            spSlider.value = currentSP;
            UpdateSPText();
        }
    }

    public void UpdateSPText()
    {
        spText.text = currentSP.ToString();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
    }

    public void UpdateScoreText()
    {
        scoreText.text = $"SCORE: {score:0000}";
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("Btn1") || h.getE1())
        //{
            //h.resetE1();
            
        //}
        //if (Input.GetKey("Btn2"))
        //{
            
        //}

    }
}
