using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SaveMapClick : MonoBehaviour
{
    [SerializeField] InputField pathField;
    [SerializeField] StringVariable exportPath;

    public void Save() => UIEvents.current.SaveClicked(pathField.text, exportPath.value);
}
