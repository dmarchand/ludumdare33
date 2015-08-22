using UnityEngine;
using System.Collections;

public abstract class UsesTrap : MonoBehaviour {
    public int Cost = 100;
    public string Key = "q";
    public GameObject Trap;
    protected PlayerModel playerModel;
}
