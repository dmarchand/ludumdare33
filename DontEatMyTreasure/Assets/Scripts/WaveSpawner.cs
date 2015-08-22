using UnityEngine;
using System.Collections;
using System;

public class WaveSpawner : MonoBehaviour {

    public WaveInfo[] Waves;
    public GameObject SpawnerObject;

    private int currentWave;

    public delegate void OnWaveSpawnerCompleteEvent();
    public event OnWaveSpawnerCompleteEvent OnWaveSpawnerComplete;

    [Serializable]
    public class WaveInfo
    {
        public float SpawnTime;
        public EnemyModel Enemy;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartSpawning()
    {
        currentWave = 0;
        SpawnWave();
    }

    void SpawnWave()
    {
        Instantiate(Waves[currentWave].Enemy, SpawnerObject.transform.position, Quaternion.identity);

        currentWave++;
        if (currentWave < Waves.Length)
        {
            Invoke("SpawnWave", Waves[currentWave].SpawnTime);
        }
        else
        {
            if (OnWaveSpawnerComplete != null)
            {
                OnWaveSpawnerComplete();
            }
        }
    }
}
