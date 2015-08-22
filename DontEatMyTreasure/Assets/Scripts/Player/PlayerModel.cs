﻿using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour {

    public float Power = 1f;
    public float Speed = 3f;
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