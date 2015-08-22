using UnityEngine;
using System.Collections;

public class IceTrap : MonoBehaviour {

    public float FreezeDuration;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.GetComponent<GetsFrozen>();

        if (enemy != null)
        {
            enemy.Freeze(FreezeDuration);
            Destroy(this.gameObject);
        }
    }
}
