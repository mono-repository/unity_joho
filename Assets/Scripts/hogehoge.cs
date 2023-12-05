using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hogehoge : MonoBehaviour
{
    //先ほど作成したクラス
    public SerialHandler serialHandler;

    void Start()
    {
        //信号を受信したときに、そのメッセージの処理を行う
        //serialHandler.OnDataReceived += OnDataReceived;
    }

    // ---------------------シリアル通信のための仕組み（ここから）
    private bool e1 = false; //ボタンなどセンサーの数が３つだった場合．各チームの用途に応じて増やしたり減らしたりすればいい
    private bool e2 = false;

    //Arduino側でイベントが発生した
    void onE1()
    {
        e1 = true; //イベントが発生したことを記憶しておく
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

    // ---------------------シリアル通信のための仕組み（ここまで）
    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
    {
        // ---------------------シリアル通信のための仕組み（ここから）
        //イベントコードに応じて処理する
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

        // ---------------------シリアル通信のための仕組み（ここまで）
    }
}