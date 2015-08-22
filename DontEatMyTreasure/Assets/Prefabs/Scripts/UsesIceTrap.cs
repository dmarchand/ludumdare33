using UnityEngine;
using System.Collections;

public class UsesIceTrap : MonoBehaviour {

    public int Cost = 100;
    public float FreezeDuration = 2f;
    public string Key = "q";
    public GameObject Trap;
    

    private PlayerModel playerModel;

	// Use this for initialization
	void Start () {
        playerModel = GetComponent<PlayerModel>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(Key) && playerModel.Gold >= Cost)
        {
            playerModel.Gold -= Cost;

            var trap = ((GameObject)Instantiate(Trap, transform.position, Quaternion.identity)).GetComponent<IceTrap>();
            trap.FreezeDuration = FreezeDuration;
        }
	}
}
