using UnityEngine;
using System.Collections;

public class GetsHealed : MonoBehaviour {

    public Color BlinkColor;


    public void Heal(int amount)
    {
        var model = GetComponent<EnemyModel>();
        model.CurrentHP += amount;
        model.CurrentHP = Mathf.Min(model.CurrentHP, model.MaxHP);

        StartCoroutine(FlashUtils.BlinkSmooth(GetComponent<SpriteRenderer>(), 10, 2, BlinkColor));
    }
}
