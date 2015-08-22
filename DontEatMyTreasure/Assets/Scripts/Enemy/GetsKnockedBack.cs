using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AstarAI))]
public class GetsKnockedBack : MonoBehaviour
{
    float mass = 1.0F; 
    Vector3 impact = Vector3.zero;
    public bool IsBeingKnockedBack = false;

    float invincibilityTime = 1f;
    float timeSinceCollision = 0f;
    bool collided = false;
    

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            timeSinceCollision += Time.deltaTime;

            if (timeSinceCollision >= invincibilityTime)
            {
                collided = false;
                timeSinceCollision = 0f;
            }
        }

        
        if (impact.magnitude > 0.2F)
        {
            transform.position += impact * Time.deltaTime;
        }
        else if (IsBeingKnockedBack)
        {
            GetComponent<AstarAI>().UnPause();
            IsBeingKnockedBack = false;
        }

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void Hit(PlayerModel player)
    {

        if (collided) return;

        var heading = transform.position - player.transform.position;

        AddImpact(heading, 4);
        

        var enemyModel = GetComponent<EnemyModel>();

        enemyModel.TakeDamage(player.Power);

        collided = true;
    }

    // call this function to add an impact force:
    public void AddImpact(Vector3 dir, float force)
    {
        if (IsBeingKnockedBack) return;

        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y;
        impact += dir.normalized * force / mass;
        GetComponent<AstarAI>().Pause();
        IsBeingKnockedBack = true;
    }
}
