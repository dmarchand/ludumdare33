using UnityEngine;
using System.Collections;

public class EnemyModel : MonoBehaviour {

    public float Speed;
    public float MaxHP, CurrentHP;
    public string Name;
    public int Gold;
    public GameObject HealthPanel;

    private AstarAI ai;

	// Use this for initialization
	void Start () {
        ai = GetComponent<AstarAI>();
	}
	
	// Update is called once per frame
	void Update () {
        ai.speed = Speed;
	}

    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
        GetComponent<FlashOnDamage>().Hit();

        if (CurrentHP <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerModel>().Gold += Gold;
            Destroy(HealthPanel.gameObject);
            Destroy(gameObject);
        }
    }
}
