using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public Wave[] Waves;
    public float WaveDelay = 5f;
    int currentWave = 0;

    public delegate void OnLevelCompleteEvent();
    public event OnLevelCompleteEvent OnLevelComplete;

	// Use this for initialization
	void Start () {
        NextWave();   
	}


    void NextWaveInit()
    {
        currentWave++;
        Invoke("NextWave", WaveDelay);
    }

    void NextWave()
    {
        if (currentWave >= Waves.Length)
        {
            if (OnLevelComplete != null)
            {
                OnLevelComplete();
            }
            return;
        }

        Waves[currentWave].WaveBegin();
        Waves[currentWave].OnWaveComplete += NextWaveInit;
    }
	

}
