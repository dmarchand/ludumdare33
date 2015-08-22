using UnityEngine;
using System.Collections;

public class GetsFrozen : MonoBehaviour {

    private float freezeDuration;
    private float timeFrozen;
    private bool isFrozen;
    private AstarAI ai;

    public Color BlinkColor;

	// Use this for initialization
	void Start () {
        ai = GetComponent<AstarAI>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isFrozen)
        {
            timeFrozen += Time.deltaTime;
            GetComponent<Rigidbody2D>().mass = 9999999;
            if (timeFrozen >= freezeDuration)
            {
                timeFrozen = 0;
                isFrozen = false;
                ai.UnPause();
                GetComponent<Rigidbody2D>().mass = 1;
            }
        }
	}

    public void Freeze(float duration)
    {
        isFrozen = true;
        freezeDuration = duration;
        StartCoroutine(FlashUtils.BlinkSmooth(GetComponent<SpriteRenderer>(), 10, duration, BlinkColor));
        ai.Pause();
    }
}
