using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveMapClick : MonoBehaviour
{
    [SerializeField] InputField pathField;

    public void Save() => UIEvents.current.SaveClicked(pathField.text);
}
