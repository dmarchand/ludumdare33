using UnityEngine;
using System.Collections;

public class CollideWithEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        GetsKnockedBack gkb = collider.GetComponent<GetsKnockedBack>();

        if (gkb != null)
        {
            var heading = gkb.transform.position - transform.position;

            gkb.AddImpact(heading, 6);
        }
    }
}
