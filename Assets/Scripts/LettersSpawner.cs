using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersSpawner : MonoBehaviour
{

    private readonly string[] LETTERS = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "Y", "Z", "<" };

    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private float radius;

    [ContextMenu("Spawn")]
    public void SpawnKeyboard()
    {
        float degreesOffset = 360.0f / LETTERS.Length;
        for (int i = 0; i < LETTERS.Length; i++)
        {
            float sinValue = Mathf.Sin(Mathf.Deg2Rad * i * degreesOffset);
            float cosValue = Mathf.Cos(Mathf.Deg2Rad * i * degreesOffset);
            Vector3 newPos = new Vector3(sinValue * radius, cosValue * radius, 0);
            GameObject newLetter = Instantiate(letterPrefab, this.transform);

            newLetter.transform.localPosition = newPos;
            Vector3 localRotation = newLetter.transform.localRotation.eulerAngles;
            localRotation.z = -i * degreesOffset;
            newLetter.transform.localRotation = Quaternion.Euler(localRotation);

            if (LETTERS[i] != "<")
            {
                InputObject_WriteChar inputObject = newLetter.AddComponent<InputObject_WriteChar>();
                inputObject.SetCharacter(LETTERS[i]);
                inputObject.SetCommandType(TextControllerCommand.Write);
                inputObject.RefreshTextRotation();
            }
            else
            {
                InputObject_Base inputObject = newLetter.AddComponent<InputObject_Base>();
                inputObject.SetCharacter(LETTERS[i]);
                inputObject.SetCommandType(TextControllerCommand.Backspace);
                inputObject.RefreshTextRotation();
            }
            

        }

    }

}
