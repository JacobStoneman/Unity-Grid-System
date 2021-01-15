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

	[SerializeField] UnityEvent onStartInCallBack;
	[SerializeField] UnityEvent onCompleteInCallBack;
	[SerializeField] UnityEvent onStartOutCallBack;
	[SerializeField] UnityEvent onCompleteOutCallBack;

	bool tweening;

	public void Scale()
	{
		if (!tweening)
		{
			OnStartIn();
			rect.pivot = pivot;
			LeanTween.size(rect, targetSize, duration).setDelay(delay).setOnComplete(OnCompleteIn).setEase(inType);
		}
	}

	public void Revert()
	{
		if (!tweening)
		{
			OnStartOut();
			rect.pivot = pivot;
			LeanTween.size(rect, initSize, duration).setDelay(delay).setOnComplete(OnCompleteOut).setEase(outType);
		}
	}

	void OnStartIn()
	{
		tweening = true;
		onStartInCallBack?.Invoke();
	}

	void OnStartOut()
	{
		tweening = true;
		onStartOutCallBack?.Invoke();
	}

	void OnCompleteIn()
	{
		onCompleteInCallBack?.Invoke();
		tweening = false;
	}

	void OnCompleteOut()
	{
		onCompleteOutCallBack?.Invoke();
		tweening = false;
	}
}