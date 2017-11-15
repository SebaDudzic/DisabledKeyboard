using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersSpawner : MonoBehaviour {

    private readonly string[] LETTERS = { "A", "B", "C", "D" };

    [SerializeField] private GameObject letterPrefab;
    [SerializeField] private float radius;
    private int degreesOffset;

    [ContextMenu("Spawn")]
    public void SpawnKeyboard()
    {
        float degreedOffset = 360.0f / LETTERS.Length;
        for (int i = 0; i < LETTERS.Length; i++)
        {
            float sinValue = Mathf.Sin(Mathf.Deg2Rad * i * degreesOffset);
            float cosValue = Mathf.Cos(Mathf.Deg2Rad * i * degreesOffset);
            Vector3 newPos = new Vector3(sinValue * radius, cosValue * radius, 0);
            GameObject newLetter = Instantiate(letterPrefab, this.transform);
            newLetter.transform.localPosition = newPos;
        }
        
    }

}
