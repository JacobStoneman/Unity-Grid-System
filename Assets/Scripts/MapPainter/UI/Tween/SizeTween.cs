using UnityEngine;
using UnityEngine.Events;

public class SizeTween : MonoBehaviour
{
	[SerializeField] RectTransform rect;
	[Space(10)]

	[SerializeField] LeanTweenType inType;
	[SerializeField] LeanTweenType outType;
	[Space(10)]

	[SerializeField] Vector2 pivot;
	[Space(10)]

	[SerializeField] Vector2 initSize;
	[SerializeField] Vector2 targetSize;
	[Space(10)]

	[SerializeField] float duration;
	[SerializeField] float delay;
	[Space(10)]

	[SerializeField] UnityEvent onCompleteCallBack;

	bool moving;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.P) && !moving)
		{
			Revert();
		}
	}

	public void Scale()
	{
		rect.pivot = pivot;
		LeanTween.size(rect, targetSize, duration).setDelay(delay).setOnComplete(OnComplete).setEase(inType);
		moving = true;
	}

	void Revert()
	{
		rect.pivot = pivot;
		LeanTween.size(rect, initSize, duration).setDelay(delay).setOnComplete(OnComplete).setEase(outType);
		moving = true;
	}

	void OnComplete()
	{
		onCompleteCallBack?.Invoke();
		moving = false;
	}
}