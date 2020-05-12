using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject {

    List<EventListener> _eventListener = new List<EventListener>();

    public void Raise() {
        for (var i = _eventListener.Count - 1; i >= 0; i--) {
            _eventListener[i].OnEventRaised();
        }
    }

    public void Register(EventListener listener) {
        if (!_eventListener.Contains(listener)){
            _eventListener.Add(listener);
        }
    }

    public void DeRegister(EventListener listener) {
        if (_eventListener.Contains(listener)) {
            _eventListener.Remove(listener);
        }
    }

}

