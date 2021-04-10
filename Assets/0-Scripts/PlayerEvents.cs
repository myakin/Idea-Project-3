using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerEvents000000", menuName = "ScriptableObjects/Player Events", order = 1)]
public class PlayerEvents : ScriptableObject {
    public bool isDead;
    public int score;
    public int scoreIncrementAmount;
    public float timer;

    private List<EventSubscriber> subscribers = new List<EventSubscriber>();

    public void Register(EventSubscriber aSubscriber) {
        subscribers.Add(aSubscriber);
    }

    public void Unregister(EventSubscriber aSubscriber) {
        subscribers.Remove(aSubscriber);
    }

    public void ExecuteEventSubscribers() {
        for (int i=0; i<subscribers.Count; i++) {
            subscribers[i].Execute();
        }
    }

    
}
