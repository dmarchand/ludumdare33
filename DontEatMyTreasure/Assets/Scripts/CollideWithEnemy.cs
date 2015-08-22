using UnityEngine;
using System.Collections;

public class CollideWithEnemy : MonoBehaviour {

    float invincibilityTime = 1f;
    float timeSinceCollision = 0f;
    bool collided = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (collided)
        {
            timeSinceCollision += Time.deltaTime;

            if (timeSinceCollision >= invincibilityTime)
            {
                collided = false;
                timeSinceCollision = 0f;
            }
        }
	}

    void OnTriggerStay2D(Collider2D collider)
    {

        EnemyModel enemyModel = collider.GetComponent<EnemyModel>();

        if (enemyModel != null && !collided)
        {
            GetsKnockedBack gkb = collider.GetComponent<GetsKnockedBack>();

            var heading = gkb.transform.position - transform.position;

            gkb.AddImpact(heading, 4);
            gkb.GetComponent<FlashOnDamage>().Hit();

            PlayerModel model = GetComponent<PlayerModel>();
            enemyModel.CurrentHP -= model.Power;

            if (enemyModel.CurrentHP <= 0)
            {
                Destroy(enemyModel.gameObject);
            }

            collided = true;
        }
    }
}
