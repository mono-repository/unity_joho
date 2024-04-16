using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Awake()
    {
        // 他のすべてのオーディオリスナーを無効にする
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        foreach (var listener in listeners)
        {
            listener.enabled = false;
        }

        // このカメラのオーディオリスナーを有効にする
        GetComponent<AudioListener>().enabled = true;
    }
}

