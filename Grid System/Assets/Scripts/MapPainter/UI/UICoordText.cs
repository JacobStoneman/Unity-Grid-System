using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICoordText : MonoBehaviour
{
    public StringVariable Coord;
    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        Coord.value = "0,0";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Coord.value;
    }
}
