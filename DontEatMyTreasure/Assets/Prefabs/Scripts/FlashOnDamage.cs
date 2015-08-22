using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class FlashOnDamage : MonoBehaviour {

    public float TimeScale;
    public float Duration;
    public Color BlinkColor;


    public void Hit()
    {
        StartCoroutine(FlashUtils.BlinkSmooth(GetComponent<SpriteRenderer>(), TimeScale, Duration, BlinkColor));
    }


}
