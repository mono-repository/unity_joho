using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentManager : MonoBehaviour
{
    // シングルトンインスタンスへの静的参照
    public static PersistentManager Instance { get; private set; }

    private void Awake()
    {
        // すでにインスタンスが存在する場合は、新しいインスタンスを破棄
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // インスタンスが存在しない場合、このオブジェクトをインスタンスとして設定
        Instance = this;

        // シーン遷移時に破棄されないように設定
        DontDestroyOnLoad(this.gameObject);
    }
}
