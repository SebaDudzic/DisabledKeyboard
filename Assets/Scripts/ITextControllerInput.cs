using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITextControllerInput
{
    void OnCommandClicked(TextControllerCommand command, params object[] optionalParams);
}
