using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MapTypeDropDownChanged : MonoBehaviour
{
	TMP_Dropdown dropdown;

	private void Awake()
	{
		dropdown = GetComponent<TMP_Dropdown>();
	}

	public void ValueChanged() => UIEvents.current.MapTypeSet(dropdown.value); 
}
