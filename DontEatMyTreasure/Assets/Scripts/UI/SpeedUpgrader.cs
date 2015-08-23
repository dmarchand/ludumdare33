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
        

        if (player.SpeedLevel < player.SpeedCosts.Length)
        {
            GetComponent<Button>().enabled = Clickable();
            int upgradeCost = player.SpeedCosts[player.SpeedLevel];
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
        int upgradeCost = player.SpeedCosts[player.SpeedLevel];

        if (player.Gold >= upgradeCost)
        {
            player.Gold -= upgradeCost;
            player.SpeedLevel++;
            player.Speed++;
        }
    }

    bool Clickable()
    {
        int upgradeCost = player.SpeedCosts[player.SpeedLevel];
        return player.Gold >= upgradeCost;
    }
}
