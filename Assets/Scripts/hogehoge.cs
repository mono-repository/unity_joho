using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hogehoge : MonoBehaviour
{
    //��قǍ쐬�����N���X
    public SerialHandler serialHandler;

    void Start()
    {
        //�M������M�����Ƃ��ɁA���̃��b�Z�[�W�̏������s��
        serialHandler.OnDataReceived += OnDataReceived;
    }

    // ---------------------�V���A���ʐM�̂��߂̎d�g�݁i��������j
    private bool e1 = false; //�{�^���ȂǃZ���T�[�̐����R�������ꍇ�D�e�`�[���̗p�r�ɉ����đ��₵���茸�炵���肷��΂���
    private bool e2 = false;

    //Arduino���ŃC�x���g����������
    void onE1()
    {
        e1 = true; //�C�x���g�������������Ƃ��L�����Ă���
    }

    public bool getE1()
    {
        return e1;
    }

    public void resetE1()
    {
        e1 = false;
    }

    public bool getE2()
    {
        return e2;
    }

    public void resetE2()
    {
        e2 = false;
    }

    // ---------------------�V���A���ʐM�̂��߂̎d�g�݁i�����܂Łj
    //��M�����M��(message)�ɑ΂��鏈��
    void OnDataReceived(string message)
    {
        // ---------------------�V���A���ʐM�̂��߂̎d�g�݁i��������j
        //�C�x���g�R�[�h�ɉ����ď�������
        var data = message.Split(
               new string[] { "\n" }, System.StringSplitOptions.None);
        //if (data.Length < 2) return;
        try
        {
            Debug.Log(data[0]);
        }
        catch (System.Exception e)
        {
            Debug.LogWarning(e.Message);
        }

        // ---------------------�V���A���ʐM�̂��߂̎d�g�݁i�����܂Łj
    }
}