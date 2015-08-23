using UnityEngine;
using System.Collections;

public class UsesIceTrap : UsesTrap {


    public float FreezeDuration = 2f;




	// Use this for initialization
	void Start () {
        playerModel = GetComponent<PlayerModel>();
        BaseCost = Cost;
        Director = GameObject.Find("Director").GetComponent<Director>();
	}
	
	// Update is called once per frame
	void Update () {

        Cost = BaseCost + (Director.CurrentWave * 10);

        if (Input.GetKeyDown(Key) && playerModel.Gold >= Cost)
        {
            playerModel.Gold -= Cost;

            var trap = ((GameObject)Instantiate(Trap, transform.position, Quaternion.identity)).GetComponent<IceTrap>();
            trap.FreezeDuration = FreezeDuration;
        }
	}
}
