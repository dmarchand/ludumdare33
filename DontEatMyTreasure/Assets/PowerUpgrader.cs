using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PowerUpgrader : MonoBehaviour {

    public PlayerModel player;

    Text text;


    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {


        if (player.SpeedLevel < player.SpeedCosts.Length)
        {
            GetComponent<Button>().enabled = Clickable();
            int upgradeCost = player.PowerCosts[player.PowerLevel];
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
        int upgradeCost = player.PowerCosts[player.PowerLevel];

        if (player.Gold >= upgradeCost)
        {
            player.Gold -= upgradeCost;
            player.PowerLevel++;
            player.Power++;
        }
    }

    bool Clickable()
    {
        int upgradeCost = player.PowerCosts[player.PowerLevel];
        return player.Gold >= upgradeCost;
    }
}
