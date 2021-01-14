using UnityEngine;
using UnityEngine.Events;

public class FadeTween : MonoBehaviour
{
	[SerializeField] RectTransform rect;
	[Space(10)]

	[SerializeField] LeanTweenType inType;
	[SerializeField] LeanTweenType outType;
	[Space(10)]

	[SerializeField] Vector2 pivot;
	[Space(10)]

	[SerializeField] float initAlpha;
	[SerializeField] float targetAlpha;
	[Space(10)]

	[SerializeField] float duration;
	[SerializeField] float delay;
	[Space(10)]

	[SerializeField] UnityEvent onStartInCallBack;
	[SerializeField] UnityEvent onCompleteInCallBack;
	[SerializeField] UnityEvent onStartOutCallBack;
	[SerializeField] UnityEvent onCompleteOutCallBack;

	bool tweening;

	public void Fade()
	{
		OnStartIn();
		rect.pivot = pivot;
		LeanTween.alpha(rect, targetAlpha, duration).setDelay(delay).setOnComplete(OnCompleteIn).setEase(inType);
	}

	void Revert()
	{
		OnStartOut();
		rect.pivot = pivot;
		LeanTween.alpha(rect, initAlpha, duration).setDelay(delay).setOnComplete(OnCompleteOut).setEase(outType);
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
