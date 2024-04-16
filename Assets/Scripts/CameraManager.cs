using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    void Awake()
    {
        // ���̂��ׂẴI�[�f�B�I���X�i�[�𖳌��ɂ���
        AudioListener[] listeners = FindObjectsOfType<AudioListener>();
        foreach (var listener in listeners)
        {
            listener.enabled = false;
        }

        // ���̃J�����̃I�[�f�B�I���X�i�[��L���ɂ���
        GetComponent<AudioListener>().enabled = true;
    }
}

