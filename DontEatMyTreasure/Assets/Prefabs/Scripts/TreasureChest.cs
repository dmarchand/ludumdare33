using UnityEngine;
using System.Collections;

public class TreasureChest : MonoBehaviour {

    float flashDuration = 2f;
    float flashInterval = .2f;
    float timeFlashed = 0f;
    float intervalFlashed = 0f;
    bool opened;
    SpriteRenderer spriteRenderer;

    public delegate void OnTreasureOpenedEvent();
    public event OnTreasureOpenedEvent OnTreasureOpened;

    public Sprite OpenSprite;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (opened)
        {
            timeFlashed += Time.deltaTime;
            intervalFlashed += Time.deltaTime;

            if (intervalFlashed >= flashInterval)
            {
                spriteRenderer.enabled = !spriteRenderer.enabled;
                intervalFlashed = 0f;
            }


            if (timeFlashed >= flashDuration)
            {
                Destroy(this.gameObject);
            }
        }
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
        var enemy = collider.GetComponent<EnemyModel>();

        if (enemy != null)
        {
            opened = true;
            this.tag = "Untagged";
            spriteRenderer.sprite = OpenSprite;

            if (OnTreasureOpened != null)
            {
                OnTreasureOpened();
            }
        }
    }
}
