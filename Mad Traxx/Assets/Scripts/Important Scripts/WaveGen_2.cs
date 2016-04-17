using UnityEngine;
using System.Collections;

public class WaveGen_2 : MonoBehaviour
{

    [SerializeField]
    private float countDown;

    [SerializeField]
    private float waveTimer;

    [SerializeField]
    private bool gotoNext;

    [SerializeField]
    private int timerIndex;

    [SerializeField]
    private int myTimer;

    [SerializeField]
    private int waveIndex;

    [SerializeField]
    private int myWave;

    [SerializeField]
    private int enemyIndex;

    [SerializeField]
    private bool doCounter;

    [System.Serializable]
    public class Timers
    {
        [SerializeField]
        public float[] myTimers;
    }

    [System.Serializable]
    public class WaveTimers
    {
        [SerializeField]
        public float[] waveTimers;
    }

    [System.Serializable]
    public class Enemies
    {
        [SerializeField]
        public GameObject[] myEnemies;
    }

    [System.Serializable]
    public class Waves
    {
        public string waveName;

        [SerializeField]
        public WaveTimers[] waveCounters;

        [SerializeField]
        public Timers[] timers;

        [SerializeField]
        public Enemies[] enemies;
    }

    [SerializeField]
    private Waves[] waves;

    // Use this for initialization
    void Start()
    {
        doCounter = false;
        timerIndex = 0;
        waveIndex = 0;
        gotoNext = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gotoNext == true)
        {
            ExecuteWave();
        }
    }

    void ExecuteWave()
    {
        int waveSize = waves.Length;
        int timerSize = waves[waveIndex].timers[0].myTimers.Length;
        int enemySize = waves[waveIndex].enemies.Length;
        float curTimer = waves[waveIndex].timers[0].myTimers[timerIndex];
        float waveCounter = waves[waveIndex].waveCounters[0].waveTimers[0];
        GameObject nextEnemy = waves[waveIndex].enemies[0].myEnemies[enemyIndex];

        if (doCounter == false)
        {
            waveTimer += waveCounter;
        }

        if (waveTimer == waveCounter)
        {
            doCounter = true;
        }

        if (doCounter == true)
        {
            waveTimer -= Time.deltaTime;
        }

        if (waveTimer <= 0)
        {
            waveTimer = 0;
            countDown -= Time.deltaTime;

            if (timerIndex < timerSize)
            {
                if (countDown <= 0)
                {
                    countDown += curTimer;
                    timerIndex++;
                    SpawnAI();
                    Debug.Log(nextEnemy.transform.name);
                    Debug.Log(waves[waveIndex].waveName);
                    Debug.Log(curTimer);
                }
            }

            if (timerIndex == timerSize)
            {
                if (waveIndex < waveSize)
                {
                    enemyIndex = 0;
                    timerIndex = 0;
                    NextWave();
                }

                if (waveIndex == waveSize)
                {
                    gotoNext = false;
                    countDown = 0;
                }
            }
        }
        myTimer = timerSize;
        myWave = waveSize;

    }

    void NextWave()
    {
        waveIndex++;
        doCounter = false;
    }

    void SpawnAI()
    {
        Instantiate(waves[waveIndex].enemies[0].myEnemies[enemyIndex], transform.position, transform.rotation);
        enemyIndex++;
    }

}
