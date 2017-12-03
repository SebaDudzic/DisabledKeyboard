using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextDrawer : MonoBehaviour {

    [SerializeField] private TextMeshProUGUI textMesh;
    [SerializeField] private TextMeshProUGUI sentTextMesh;

    public void SendText()
    {
        sentTextMesh.text = "Sent:\n" + textMesh.text;
        textMesh.text = "";
    }

    public void RefreshText(string newText)
    {
        if(newText != null  && newText.Length > 0)
        {
            SetText(newText);
        }
        else
        {
            SetText("start typing...");
        }
    }

    private void SetText(string newText)
    {
        textMesh.text = newText;
    }

}
