using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(EventTrigger))]
public class DetectUIInteraction : MonoBehaviour
{
    public BoolVariable UIInteraction;
    public BoolVariable MouseOnScreen;
    private EventTrigger eventTrigger;


    GraphicRaycaster Raycaster;
    PointerEventData PointerEventData;
    EventSystem m_EventSystem;

    void Start()
    {
        Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
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
        CheckTileSelection();
        CheckMouseOnScreen();
    }

    void CheckTileSelection()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PointerEventData = new PointerEventData(m_EventSystem);
            PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            Raycaster.Raycast(PointerEventData, results);

            foreach (RaycastResult result in results)
            {
                if (result.gameObject.tag == "TileAssetPanel") UIEvents.current.TileClicked(result.gameObject);
            }
        }
    }

    void CheckMouseOnScreen()
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
