using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NextWaveDisplay : MonoBehaviour {

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
        text.text = "Next Wave In: " + director.WaveTimeRemainingDisplay.ToString("F0") + " seconds";

        if (director.WaveTimeRemainingDisplay <= 0)
        {
            text.text = "Wave Active";
        }
    }
}
