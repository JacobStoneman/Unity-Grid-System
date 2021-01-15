using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAndDrag : EventTrigger
{
    float xOffset;
    float yOffset;
    private bool dragging;
    public void Update()
    {
        if (dragging)
        {
            transform.position = new Vector2(Input.mousePosition.x + xOffset, Input.mousePosition.y + yOffset);
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        xOffset = transform.position.x - Input.mousePosition.x;
        yOffset = transform.position.y - Input.mousePosition.y;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }
}
