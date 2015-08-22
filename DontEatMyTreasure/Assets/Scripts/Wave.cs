using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wave : MonoBehaviour {

    public WaveSpawner[] Spawners;
    private int wavesToGo;

    public delegate void OnWaveCompleteEvent();
    public event OnWaveCompleteEvent OnWaveComplete;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void WaveBegin()
    {
        wavesToGo = Spawners.Length;
        foreach (var spawner in Spawners)
        {
            spawner.StartSpawning();
            spawner.OnWaveSpawnerComplete += SpawnerComplete;

        }
    }

    void SpawnerComplete()
    {
        wavesToGo--;

        if (wavesToGo <= 0 && OnWaveComplete != null)
        {
            OnWaveComplete();
        }
    }
}
