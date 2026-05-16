using System.Collections.Generic;
using UnityEngine;

// NOTE: This simply handles behavior for the finish line of the level. The only responsibilty this script holds is outputting a signal when its crossed to say that the player has now completed the level

public class StartOrFinishLine : MonoBehaviour, IPublisher
{
    public enum LineType
    {
        StartLine,
        FinishLine,
    }

    private Dictionary<string, List<IObserver>> subscribers = new Dictionary<string, List<IObserver>>(); // Holds all subscribers to this script's announcements
    [SerializeField]
    public LineType thisLine = LineType.StartLine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true)
        {
            switch (thisLine)
            {
                case LineType.StartLine:
                    this.Publish("PlayerCrossedStartLine", null);
                    break;
                case LineType.FinishLine:
                    this.Publish("PlayerCrossedFinishLine", null);
                    break;

            }
        }
    }

    // What remains below are standard functions incorporated from IPublisher interface
    public void Subscribe(string eventType, IObserver observer)
    {
        if (!this.subscribers.ContainsKey(eventType))
        {
            this.subscribers[eventType] = new List<IObserver>();
        }

        this.subscribers[eventType].Add(observer);
    }

    public void Unsubscribe(string eventType, IObserver observer)
    {
        if (!this.subscribers.ContainsKey(eventType))
        {
            return;
        }

        this.subscribers[eventType].Remove(observer);
    }

    public void Publish(string eventType, object argument)
    {
        if (!this.subscribers.ContainsKey(eventType))
        {
            return;
        }

        foreach (IObserver observer in this.subscribers[eventType])
        {
            observer.Notify(eventType, argument);
        }
    }
}