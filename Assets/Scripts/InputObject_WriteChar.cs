using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObject_WriteChar : InputObject_Base
{

    protected override void RunCommand()
    {
        TextController.Input.OnCommandClicked(command, character);
    }




}
