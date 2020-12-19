using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(EventTrigger))]
public class DetectUIInteraction : MonoBehaviour
{
    public BoolVariable UIInteraction;
    public BoolVariable MouseOnScreen;
    private EventTrigger eventTrigger;

    void Start()
    {
        eventTrigger = GetComponent<EventTrigger>();

        if (eventTrigger != null)
        {
            EventTrigger.Entry enterUIEntry = new EventTrigger.Entry();
            // Pointer Enter
            enterUIEntry.eventID = EventTriggerType.PointerEnter;
            enterUIEntry.callback.AddListener((eventData) => { EnterUI(); });
            eventTrigger.triggers.Add(enterUIEntry);

            //Pointer Exit
            EventTrigger.Entry exitUIEntry = new EventTrigger.Entry();
            exitUIEntry.eventID = EventTriggerType.PointerExit;
            exitUIEntry.callback.AddListener((eventData) => { ExitUI(); });
            eventTrigger.triggers.Add(exitUIEntry);
        }
    }

	private void Update()
	{
#if UNITY_EDITOR
        MouseOnScreen.value = ((Input.mousePosition.x >= 0 && Input.mousePosition.x <= Handles.GetMainGameViewSize().x) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= Handles.GetMainGameViewSize().y));
#else
        MouseOnScreen.value = ((Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width) && (Input.mousePosition.y >= 0 && Input.mousePosition.y <= Screen.height));
#endif
    }

    public void EnterUI() => UIInteraction.value = true;
    public void ExitUI() => UIInteraction.value = false;
}
