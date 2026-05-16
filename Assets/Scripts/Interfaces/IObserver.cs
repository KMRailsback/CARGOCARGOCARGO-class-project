using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Straightforward interface for an Observer interface

public interface IObserver
{
    public GameObject gameObject { get; }

    public void Notify(string eventType, object argument);
}