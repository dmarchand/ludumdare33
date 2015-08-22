using UnityEngine;
using System.Collections;

public class UsesFireTrap : UsesTrap {

    public float Damage;

	// Use this for initialization
	void Start () {
        playerModel = GetComponent<PlayerModel>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Key) && playerModel.Gold >= Cost)
        {
            playerModel.Gold -= Cost;

            var trap = ((GameObject)Instantiate(Trap, transform.position, Quaternion.identity)).GetComponent<FireTrap>();
            trap.Damage = Damage;
        }
	}
}
