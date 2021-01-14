using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DetectMouseInteraction : MonoBehaviour
{
    public bool mouseHover;

    public void EnterUI() => mouseHover = true;
    public void ExitUI() => mouseHover = false;
}
