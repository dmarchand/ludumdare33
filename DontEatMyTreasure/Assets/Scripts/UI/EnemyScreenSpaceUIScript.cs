﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyScreenSpaceUIScript : MonoBehaviour
{
    private EnemyModel enemyModel;

    public Canvas canvas;
    public GameObject healthPrefab;

    public float healthPanelOffset = .8f;
    public GameObject healthPanel;
    private Text enemyName;
    private Slider healthSlider;
    private int framesElapsed;
    private int framesUntilShow = 1;

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>() ;

        enemyModel = GetComponent<EnemyModel>();
        healthPanel = Instantiate(healthPrefab) as GameObject;
        healthPanel.transform.SetParent(canvas.transform, false);
        enemyModel.HealthPanel = healthPanel;

        enemyName = healthPanel.GetComponentInChildren<Text>();
        enemyName.text = enemyModel.Name;

        healthSlider = healthPanel.GetComponentInChildren<Slider>();
        healthSlider.enabled = false;
        healthSlider.gameObject.SetActive(false);
        enemyName.enabled = false;

    }

    void Update()
    {
        if (framesElapsed < framesUntilShow)
        {
            framesElapsed++;
            return;
        }
        else
        {
            healthSlider.enabled = true;
            enemyName.enabled = true;
            healthSlider.gameObject.SetActive(true);
        }
        healthSlider.value = enemyModel.CurrentHP / (float)enemyModel.MaxHP;

        Vector3 worldPos = new Vector3(transform.position.x, transform.position.y + healthPanelOffset, transform.position.z);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);
        healthPanel.transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);


    }
}