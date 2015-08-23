using UnityEngine;
using System.Collections;

public class Director : MonoBehaviour {

    public int GoldBonusPerChestRemaining;
    public Wave[] Waves;
    public float WaveDelay = 25f;
    public float WaveTimeRemainingDisplay;
    public int CurrentWave = 0;
    public int CurrentWaveDisplay = 0;

    public delegate void OnLevelCompleteEvent();
    public event OnLevelCompleteEvent OnLevelComplete;

    private bool countingDown;
    private PlayerModel player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerModel>();
        NextWave();   
	}

    void Update()
    {
        if (countingDown)
        {
            WaveTimeRemainingDisplay -= Time.deltaTime;
            if (WaveTimeRemainingDisplay <= 0)
            {
                countingDown = false;
                WaveTimeRemainingDisplay = 0;
            }
        }
    }

    void NextWaveInit()
    {
        CurrentWave++;
        WaveTimeRemainingDisplay = WaveDelay;
        countingDown = true;
        Invoke("NextWave", WaveDelay);
    }

    void NextWave()
    {
        if (CurrentWave >= Waves.Length)
        {
            Debug.Log("Victory!");
            if (OnLevelComplete != null)
            {
                OnLevelComplete();
            }
            return;
        }

        int chestsRemaining = GameObject.FindGameObjectsWithTag("Treasure").Length;
        player.Gold += chestsRemaining * (GoldBonusPerChestRemaining + CurrentWave * 10);
        

        Waves[CurrentWave].WaveBegin();
        CurrentWaveDisplay++;
        Waves[CurrentWave].OnWaveComplete += NextWaveInit;
    }
	

}
