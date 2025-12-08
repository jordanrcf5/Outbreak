using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progessSlider;

    public GameObject player;
    public GameObject loadCanvas;
    public List<GameObject> levels;
    private int currentLevelIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressAmount = 0;
        progessSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
        HoldToLoad.OnHoldComplete += LoadNextLevel;
        loadCanvas.SetActive(false);
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progessSlider.value = progressAmount;
        if(progressAmount >= 100)
        {
            // Level complete! 
            loadCanvas.SetActive(true);
            Debug.Log("Level Complete");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadNextLevel()
    {
        int nextLevelIndex = (currentLevelIndex == levels.Count - 1) ? 0 : currentLevelIndex +1;
        loadCanvas.SetActive(false);

        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[nextLevelIndex].gameObject.SetActive(true);

        player.transform.position = new Vector3(0, 0, 0);

        currentLevelIndex = nextLevelIndex;
        progressAmount = 0;
        progessSlider.value = 0;
    }
}
