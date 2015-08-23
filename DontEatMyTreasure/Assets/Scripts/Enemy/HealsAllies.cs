using UnityEngine;
using System.Collections;

public class HealsAllies : MonoBehaviour {

    public float HealDelay = 10f;
    public int Power = 2;

	// Use this for initialization
	void Start () {
        Invoke("Heal", HealDelay);
	}
	
	// Update is called once per frame
	void Update () {
	}

    void Heal()
    {
        var allies = GameObject.FindGameObjectsWithTag("Monster");
        foreach (var ally in allies)
        {
            if (ally.gameObject != gameObject)
            {
                ally.GetComponent<GetsHealed>().Heal(Power);
            }
        }

        Invoke("Heal", HealDelay);
    }
}
