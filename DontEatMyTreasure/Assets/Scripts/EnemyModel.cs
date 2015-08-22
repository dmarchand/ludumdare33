using UnityEngine;
using System.Collections;

public class EnemyModel : MonoBehaviour {

    public float Speed;
    public float MaxHP, CurrentHP;
    public string Name;
    public GameObject HealthPanel;

    private AstarAI ai;

	// Use this for initialization
	void Start () {
        ai = GetComponent<AstarAI>();
	}
	
	// Update is called once per frame
	void Update () {
        ai.speed = Speed;
	}
}
