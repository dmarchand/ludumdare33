using UnityEngine;
using System.Collections;

public class CollideWithEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerStay2D(Collider2D collider)
    {

        EnemyModel enemyModel = collider.GetComponent<EnemyModel>();

        if (enemyModel != null)
        {
            GetsKnockedBack gkb = collider.GetComponent<GetsKnockedBack>();

            gkb.Hit(GetComponent<PlayerModel>());
        }
    }
}
