using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    // �V���O���g���C���X�^���X�ւ̐ÓI�Q��
    public static PersistentManager Instance { get; private set; }

    private void Awake()
    {
        // ���łɃC���X�^���X�����݂���ꍇ�́A�V�����C���X�^���X��j��
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // �C���X�^���X�����݂��Ȃ��ꍇ�A���̃I�u�W�F�N�g���C���X�^���X�Ƃ��Đݒ�
        Instance = this;

        // �V�[���J�ڎ��ɔj������Ȃ��悤�ɐݒ�
        DontDestroyOnLoad(this.gameObject);
    }
}
