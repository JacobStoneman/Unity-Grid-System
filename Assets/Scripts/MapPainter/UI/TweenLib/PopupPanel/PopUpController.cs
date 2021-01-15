using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopUpController : MonoBehaviour
{
    [SerializeField] UnityEvent StartEvent;
    [SerializeField] float DestroyDelay;
    void Start() => StartEvent?.Invoke();

    public void DestroyOnClose() => Destroy(gameObject, DestroyDelay);
}
