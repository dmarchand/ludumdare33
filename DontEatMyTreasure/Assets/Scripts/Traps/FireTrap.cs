using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour {

    public float Damage;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        var triggerer = collider.GetComponent<EnemyModel>();

        if (triggerer != null)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Monster");

            foreach (var enemy in enemies)
            {
                enemy.GetComponent<EnemyModel>().TakeDamage(triggerer.MaxHP / 2);
            }

            Destroy(triggerer.gameObject);
            Destroy(this.gameObject);
            
        }
    }
}
