using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject_Base : MonoBehaviour
{
    [SerializeField] protected TextControllerCommand command;

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
}
