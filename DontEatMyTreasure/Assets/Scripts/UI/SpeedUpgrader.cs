using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedUpgrader : MonoBehaviour {

    public PlayerModel player;

    Text text;


	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {


        if (player.Level < player.LevelCosts.Length)
        {
            GetComponent<Button>().enabled = Clickable();
            int upgradeCost = player.LevelCosts[player.Level];
            text.text = "Upgrade: " + upgradeCost;
        }
        else
        {
            text.text = "MAX!";
            GetComponent<Button>().enabled = false;
        }
	}

    public void Click()
    {
        int upgradeCost = player.LevelCosts[player.Level];

        if (player.Gold >= upgradeCost)
        {
            player.Gold -= upgradeCost;
            player.Level++;
            player.Speed+=.5f;
        }
    }

    bool Clickable()
    {
        int upgradeCost = player.LevelCosts[player.Level];
        return player.Gold >= upgradeCost;
    }
}
