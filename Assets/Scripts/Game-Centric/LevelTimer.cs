using TMPro;
using UnityEngine;

// NOTE: This is a timer specially designed for this game. Creating timer as a separate object to leave the option for special extensions, such as the ability for pick-ups to extend time

public class LevelTimer: MonoBehaviour
{
    private TextMeshProUGUI UIElement = null;

    private float timeElapsed = 0.0f;
    private bool timerActive = false;
    
    // Mutator for setting timer length
    // NOTE TO SELF: This was supposed to be included in a constructor, but that would've included this not being a MonoBehavior so I could've used new on this, and...it didn't work out
    public void setTimerLength(float newTimerLength)
    {
        timerLength = newTimerLength;
    }

    // Seperate mutator for setting UIElement
    // NOTE TO SELF: This was supposed to be included in the constructor, but variables cannot be passed to constructors, which means a reference to the appropriate UI element stored as a variable wouldn't fly. Bummer
    public void setUIElement(TextMeshProUGUI newUIElement)
    {
        UIElement = newUIElement;
    }

    private float timerLength = 10.0f; // The duration that the timer runs for

    // Manually ends timer, returning amount of time elapsed thus far, intended for capturing the time at which players clears level for score calculation
    public float TimeHasEnded()
    {
        timerActive = false;
        return timeElapsed;
    }

    // Begins the timer
    public void StartTimer()
    {
        timeElapsed = 0.0f;
        timerActive = true; 
    }

    private void TimerReachedEnd()
    {
        timerActive = false;
    }

    private void Update()
    {
        if (timerActive)
        {
            timeElapsed += Time.deltaTime;
            UIElement.text = (timerLength - timeElapsed).ToString("0.00"); // Updates UI element corresponding to timer, with output formatting applied to only show two decimals places
            if (timeElapsed >= timerLength) { TimerReachedEnd(); }
        }
    }
}
