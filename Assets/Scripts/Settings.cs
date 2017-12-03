using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public AnimationCurve buttonScaleCurve;
    public float buttonAnimTime = 0.4f;
    public AnimationCurve colorCurve;
    public Color pressedColor = Color.cyan;
    public float holdButtonTime = 0.8f;
    public float holdSpan = 0.4f;

    public static Settings Instance;

    void Awake()
    {
        Instance = this;
    }
}
