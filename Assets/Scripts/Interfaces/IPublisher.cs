using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Straightforward interface for a Publisher interface

public interface IPublisher
{
    public void Subscribe(string eventType, IObserver observer);
    public void Unsubscribe(string eventType, IObserver observer);
    public void Publish(string eventType, object argument);
}