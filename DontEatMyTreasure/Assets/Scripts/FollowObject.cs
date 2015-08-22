using UnityEngine;
using System.Collections;

public class FollowObject : MonoBehaviour {

    public float DampTime = 0.15f;
    public Transform Target;
    private Vector3 velocity = Vector3.zero;
    private Camera camera;

    void Start()
    {
        camera = GetComponent<Camera>();
    }

	// Update is called once per frame
	void Update () {
        if (Target) {
            
            Vector3 point = camera.WorldToViewportPoint(Target.position);
            Vector3 delta = Target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = destination;//Vector3.SmoothDamp(transform.position, destination, ref velocity, DampTime);
        }
	}
}
