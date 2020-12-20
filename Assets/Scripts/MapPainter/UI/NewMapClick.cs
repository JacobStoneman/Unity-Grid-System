using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewMapClick : MonoBehaviour
{
    [SerializeField] InputField pathField;

    public void NewMapCreate() => UIEvents.current.NewMapClicked(pathField.text, "New Map");

}
