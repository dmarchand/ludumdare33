using UnityEngine;
using System.Collections;

public class FlashUtils : MonoBehaviour
{

    public static IEnumerator BlinkSmooth(SpriteRenderer spriteRenderer, float timeScale, float duration, Color blinkColor)
    {
        var material = spriteRenderer.material;
        var elapsedTime = 0f;
        while (elapsedTime <= duration)
        {
            material.SetColor("_BlinkColor", blinkColor);

            blinkColor.a = Mathf.PingPong(elapsedTime * timeScale, 1f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // revert to our standard sprite color
        blinkColor.a = 0f;
        material.SetColor("_BlinkColor", blinkColor);
    }
}
