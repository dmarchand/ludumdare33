using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour {

    public float Damage;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.GetComponent<EnemyModel>();

        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
            Destroy(this.gameObject);
        }
    }
}
