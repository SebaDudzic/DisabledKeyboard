using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersSpawner : MonoBehaviour
{

    private readonly string[] LETTERS = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "Y", "Z", "_", "BACKSPACE", "ENTER" };

    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private float radius;
    [SerializeField] private Sprite backSpaceSprite;
    [SerializeField] private Sprite enterSprite;

    void Awake()
    {
        SpawnKeyboard();
    }

    [ContextMenu("Spawn")]
    public void SpawnKeyboard()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Destroy(child.gameObject);
        }

        int startOffset = 1;
        float degreesOffset = 360.0f / LETTERS.Length;
        for (int i = 0; i < LETTERS.Length; i++)
        {
            float sinValue = Mathf.Sin(Mathf.Deg2Rad * (i + startOffset) * degreesOffset);
            float cosValue = Mathf.Cos(Mathf.Deg2Rad * (i + startOffset) * degreesOffset);
            Vector3 newPos = new Vector3(sinValue * radius, cosValue * radius, 0);
            GameObject newLetter = Instantiate(letterPrefab, this.transform);

            newLetter.transform.localPosition = newPos;
            Vector3 localRotation = newLetter.transform.localRotation.eulerAngles;
            localRotation.z = -(i + startOffset) * degreesOffset;
            newLetter.transform.localRotation = Quaternion.Euler(localRotation);

            if (LETTERS[i].Length == 1)
            {
                InputObject_WriteChar inputObject = newLetter.AddComponent<InputObject_WriteChar>();
                inputObject.SetCharacter(LETTERS[i]);
                inputObject.SetCommandType(TextControllerCommand.Write);
                inputObject.RefreshTextRotation();
            }
            else if (LETTERS[i] == "BACKSPACE")
            {
                InputObject_Base inputObject = newLetter.AddComponent<InputObject_Base>();
                inputObject.SetCharacter(LETTERS[i]);
                inputObject.SetCommandType(TextControllerCommand.Backspace);
                inputObject.SetIcon(backSpaceSprite);
            }
            else if (LETTERS[i] == "ENTER")
            {
                InputObject_Base inputObject = newLetter.AddComponent<InputObject_Base>();
                inputObject.SetCharacter(LETTERS[i]);
                inputObject.SetCommandType(TextControllerCommand.Enter);
                inputObject.SetIcon(enterSprite);
            }
        }
    }

}