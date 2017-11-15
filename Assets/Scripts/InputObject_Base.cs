using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject_Base : MonoBehaviour
{
    [SerializeField] protected string character;
    [SerializeField] protected TextControllerCommand command;
    [SerializeField] protected TextMesh textMesh;

    protected virtual void RunCommand()
    {
        TextController.Input.OnCommandClicked(command);
    }

    [ContextMenu("OnPress")]
    public void OnPress()
    {
        RunCommand();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("colenter" + gameObject.name, gameObject);
        RunCommand();
    }

    public void SetCommantType(TextControllerCommand commandType)
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
        if (textMesh == null)
        {
            textMesh = GetComponentInChildren<TextMesh>();
        }

        textMesh.text = character;

    }

    public void RefreshTextRotation()
    {
        textMesh.transform.rotation = Quaternion.identity;
    }
}
