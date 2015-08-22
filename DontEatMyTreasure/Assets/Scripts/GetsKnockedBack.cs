using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AstarAI))]
public class GetsKnockedBack : MonoBehaviour
{
    float mass = 1.0F; 
    Vector3 impact = Vector3.zero;

    // Update is called once per frame
    void Update()
    {

        if (impact.magnitude > 0.2F)
        {
            transform.position += impact * Time.deltaTime;
        }
        else
        {
            GetComponent<AstarAI>().Pause(false);
        }

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
    // call this function to add an impact force:
    public void AddImpact(Vector3 dir, float force)
    {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y;
        impact += dir.normalized * force / mass;
        GetComponent<AstarAI>().Pause(true);
    }
}
