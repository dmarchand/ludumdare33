using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FireTrapCostDisplay : MonoBehaviour {

    public UsesFireTrap trap;
    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Cost: " + trap.Cost + " Gold";
    }
}
