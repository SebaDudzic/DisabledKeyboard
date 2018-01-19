using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TextDrawer))]
public class TextController : MonoBehaviour, ITextControllerInput
{
    [SerializeField] private CPMCounter counter;

    public static ITextControllerInput Input;

    private TextDrawer textDrawer;
    private string text = "";

    private void Awake()
    {
        if(Input == null)
        {
            Input = this;
        }
        else
        {
            Destroy(this);
        }

        textDrawer = GetComponent<TextDrawer>();
        RefreshText();
    }

    void ITextControllerInput.OnCommandClicked(TextControllerCommand command, params object[] optionalParams)
    {
        try
        {
            switch (command)
            {
                case TextControllerCommand.Write:
                    Write((string)optionalParams[0]);
                    counter.OnTyped();
                    break;
                case TextControllerCommand.Backspace:
                    Backspace();
                    break;
                case TextControllerCommand.Enter:
                    SendText();
                    counter.OnSend();
                    break;
                default:
                    Debug.LogError("Not recognized command!");
                    break;
            }

            RefreshText();
        }
        catch
        {
            new System.Exception("Invalid command or optionalParams");
        }
    }

    private void RefreshText()
    {
        textDrawer.RefreshText(text);
    }

    private void SendText()
    {
        if (text != "")
        {
            textDrawer.SendText();
            text = "";
        }
    }

    private void Write(string character)
    {
        text += character;
    }

    private void Backspace()
    {
        text = text.Substring(0, text.Length - 1);
    }
}
