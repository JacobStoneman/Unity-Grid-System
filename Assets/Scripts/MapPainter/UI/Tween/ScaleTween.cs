using UnityEngine;
using UnityEngine.Events;

public class ScaleTween : MonoBehaviour
{
	[SerializeField] RectTransform rect;
	[Space(10)]

	[SerializeField] LeanTweenType inType;
	[SerializeField] LeanTweenType outType;
	[Space(10)]

	[SerializeField] Vector2 pivot;
	[Space(10)]

	[SerializeField] Vector3 initScale;
	[SerializeField] Vector3 targetScale;
	[Space(10)]

	[SerializeField] float duration;
	[SerializeField] float delay;
	[Space(10)]

	[SerializeField] UnityEvent onCompleteCallBack;

	bool moving;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.O) && !moving)
		{
			Scale();
		}
		if (Input.GetKeyDown(KeyCode.P) && !moving)
		{
			Revert();
		}
	}

	void Scale()
	{
		rect.pivot = pivot;
		LeanTween.scale(rect, targetScale, duration).setDelay(delay).setOnComplete(OnComplete).setEase(inType);
		moving = true;
	}

	void Revert()
	{
		rect.pivot = pivot;
		LeanTween.size(rect, initScale, duration).setDelay(delay).setOnComplete(OnComplete).setEase(outType);
		moving = true;
	}

	void OnComplete()
	{
		onCompleteCallBack?.Invoke();
		moving = false;
	}
}