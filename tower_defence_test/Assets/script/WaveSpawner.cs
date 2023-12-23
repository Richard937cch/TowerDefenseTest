using UnityEngine;
using System.Collections;
public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private float countdown;
    [SerializeField] private GameObject spawnpoint;

    public Wave[] waves;
    public int currentWaveIndex = 0;
    //public int SpawnCount = 0;
    public int DeadCount = 0;

    public bool gameEnd = false;

    private bool readyToCountDown;

    
    private void Start()
    {
        
        readyToCountDown = true;

        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesLeft = waves[i].enemies.Length;
            
        }
    }
    private void Update()
    {
        if (currentWaveIndex >= waves.Length)
        {
            Debug.Log("You survived every wave!");
            gameEnd = true;
            return;
        }

        if (readyToCountDown == true)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            readyToCountDown = false;

            countdown = waves[currentWaveIndex].timeToNextWave;

            StartCoroutine(SpawnWave());
        }

        if (DeadCount == waves[currentWaveIndex].enemies.Length )
        {
            readyToCountDown = true;
            DeadCount = 0;
            currentWaveIndex++;
            
        }
        
    }
    private IEnumerator SpawnWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            for (int i = 0; i < waves[currentWaveIndex].enemies.Length; i++)
            {
                Enemy enemy = Instantiate(waves[currentWaveIndex].enemies[i]);
                //SpawnCount +=1;

                yield return new WaitForSeconds(waves[currentWaveIndex].timeToNextEnemy);
            }
            
        }
    }
}

[System.Serializable]
public class Wave
{
    public Enemy[] enemies;
    public float timeToNextEnemy;
    public float timeToNextWave;

    [HideInInspector] public int enemiesLeft;
}