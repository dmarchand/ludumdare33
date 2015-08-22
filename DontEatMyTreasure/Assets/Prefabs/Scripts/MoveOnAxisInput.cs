using UnityEngine;
using System.Collections;

public class MoveOnAxisInput : MonoBehaviour {

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public float speed = 1.0f;

    

    void FixedUpdate()
    {
        transform.position += (Vector3.right * Input.GetAxis(horizontalAxis) + Vector3.up * Input.GetAxis(verticalAxis)).normalized * speed * Time.deltaTime;
    }
}
