using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider hpSlider;
    [SerializeField] HealthScript playerHealth;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    Scorekeeper scoreKeep;
    void Awake()
    {
        scoreKeep = FindObjectOfType<Scorekeeper>();
    }
    void Start()
    {
        hpSlider.maxValue = playerHealth.GetHealth();        
    }
    void Update()
    {
        hpSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeep.GetScore().ToString("000000000");
    }
}
