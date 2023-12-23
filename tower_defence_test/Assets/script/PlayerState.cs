using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
    public int PlayerHealth = 10;
    public int enemyTotal;

    public Button Retry;
    public Button MainMenu;
    public TextMeshProUGUI lose;
    public TextMeshProUGUI win;
    public Image HPbar;
    
    //EnemySpawn enemySpawn;
    WaveSpawner waveSpawner;

    void Awake()
    {
        //enemySpawn = GameObject.Find("EnemyControl").GetComponent<EnemySpawn>();
        //enemyTotal = enemySpawn.enemyi;
        waveSpawner = GameObject.Find("EnemyControl").GetComponent<WaveSpawner>();

    }
 
    void OnEnable(){
        Retry.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
    }
    public void Scene1(string SceneName) {  
        UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName);  
    }
    // Start is called before the first frame update
    void Start()
    {
        Retry.gameObject.SetActive(false);
        MainMenu.gameObject.SetActive(false);
        lose.gameObject.SetActive(false);
        win.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("PLAY");
        if (PlayerHealth<=0)
        {
            Retry.gameObject.SetActive(true);
            MainMenu.gameObject.SetActive(true);
            lose.gameObject.SetActive(true);
        }
        else if (PlayerHealth>0 && waveSpawner.gameEnd == true)
        {
            Retry.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(true);
            win.gameObject.SetActive(true);
        }
        

    }
}
