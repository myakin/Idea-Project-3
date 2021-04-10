using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSubscriber : MonoBehaviour
{
    public PlayerEvents playerEvents;
    public UnityEvent OnExecution;

    private void OnEnable() {
        playerEvents.Register(this);
    }
    private void OnDisable() {
        playerEvents.Unregister(this);
    }

    public void Execute() {
        OnExecution?.Invoke();
    }
}
