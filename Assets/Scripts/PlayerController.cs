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

    private hogehoge h;
    // Start is called before the first frame update
    void Start()
    {
        h = GameObject.Find("Main Camera").GetComponent<hogehoge>();

        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        UpdateHealthText();
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

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey("Btn1") || h.getE1())
        //{
            //h.resetE1();
            //transform.position += new Vector3(30f, 55f, 0f);
        //}
        //if (Input.GetKey("Btn2"))
        //{
            //transform.position += new Vector3(84.5f, 55f, 0f);
        //}

    }
}
