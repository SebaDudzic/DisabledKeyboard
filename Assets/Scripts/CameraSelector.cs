using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    [SerializeField] private GameObject standaloneCamera;
    [SerializeField] private GameObject vrCamera;

    private void Awake()
    {
        bool vrActive = false;
#if !UNITY_EDITOR && !UNITY_STANDALONE_WIN
        vrActive = true;
#endif
        standaloneCamera.SetActive(!vrActive);
        vrCamera.SetActive(vrActive);
    }
}
