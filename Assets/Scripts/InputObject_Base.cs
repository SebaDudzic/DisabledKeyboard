using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject_Base : MonoBehaviour
{
    [SerializeField] protected string character;
    [SerializeField] protected TextControllerCommand command;

    protected TextMesh textMesh;
    private Vector3 startScale;
    private AudioSource audioSource;

    private bool isPressed = false;
    private DateTime timeEntered;
    private float pressTime = 0;

    private void Awake()
    {
        startScale = transform.localScale;
        textMesh = GetComponentInChildren<TextMesh>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPressed && (DateTime.UtcNow - timeEntered).TotalSeconds >= Settings.Instance.holdButtonTime)
        {
            if (pressTime > Settings.Instance.holdSpan)
            {
                OnRunCommand();
                pressTime = 0;
            }

            pressTime += Time.deltaTime;
        }
    }

    protected virtual void RunCommand()
    {
        TextController.Input.OnCommandClicked(command);
    }

    [ContextMenu("OnPress")]
    public void OnPress()
    {
        OnRunCommand();
    }

    private void OnTriggerEnter(Collider collider)
    {
        isPressed = true;
        pressTime = Mathf.Infinity;
        timeEntered = DateTime.UtcNow;
        OnRunCommand();
    }

    private void OnTriggerExit(Collider collider)
    {
        isPressed = false;
    }

    public void SetCommandType(TextControllerCommand commandType)
    {
        command = commandType;
    }

    public virtual void SetCharacter(string character)
    {
        this.character = character;
        RefreshText();
    }

    protected void RefreshText()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        textMesh.text = character;
    }

    public void RefreshTextRotation()
    {
        textMesh.transform.rotation = Quaternion.identity;
    }

    private void OnRunCommand()
    {
        RunCommand();   
        AnimatePress();
    }

    private void AnimatePress()
    {
        StopAllCoroutines();
        StartCoroutine(AnimationCor());
        PlaySound();
    }

    private IEnumerator AnimationCor()
    {
        float phase = 0;

        while (phase <= 1)
        {
            SetAnimationPhase(phase);
            phase += Time.deltaTime / Settings.Instance.buttonAnimTime;
            yield return null;
        }

        SetAnimationPhase(1);
    }

    private void SetAnimationPhase(float phase)
    {
        transform.localScale = startScale * Settings.Instance.buttonScaleCurve.Evaluate(phase);
        textMesh.color = Color.Lerp(Color.white, Settings.Instance.pressedColor,
            Settings.Instance.colorCurve.Evaluate(phase));
    }

    private void PlaySound()
    {
        audioSource.Play();
    }
}
