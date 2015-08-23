using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveDisplay : MonoBehaviour {

    Director director;
    Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        director = GameObject.Find("Director").GetComponent<Director>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Wave: " + director.CurrentWaveDisplay;
    }
}
