using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {

    public float Power = 1f;
    public float Speed = 3f;

    [HideInInspector]
    public int Level;

    public int[] LevelCosts;

    public int Gold;

    private MoveOnAxisInput moveOnAxisInput;

	// Use this for initialization
	void Start () {
        moveOnAxisInput = GetComponent<MoveOnAxisInput>();
	}
	
	// Update is called once per frame
	void Update () {
        moveOnAxisInput.speed = Speed;
	}
}
