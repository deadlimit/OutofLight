using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour {

    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable() { Event.Register(this); }
    private void OnDisable() { Event.DeRegister(this); }


    public void OnEventRaised() { Response.Invoke(); }
}
