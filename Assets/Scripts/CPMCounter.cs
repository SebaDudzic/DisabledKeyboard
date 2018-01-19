using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CPMCounter : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI lastCpmText;

    private System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
    private int typedCount = 0;

    public System.TimeSpan GetTypingTime()
    {
        return stopwatch.Elapsed;
    }

    public void OnTyped()
    {
        if(typedCount == 0)
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        typedCount++;
    }

    public void OnSend()
    {
        if (typedCount > 0)
        {
            lastCpmText.text = string.Format("{0:00.0} characters per min", typedCount / GetTypingTime().TotalMinutes);
        }

        typedCount = 0;
    }
}
