using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System;
using System.Diagnostics;

public class SerialHandler : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;

    //ポート名
    //例
    //Linuxでは/dev/ttyUSB0
    //windowsではCOM1
    //Macでは/dev/tty.usbmodem1421など
    public string portName = "COM9";
    public int baudRate = 115200;

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private bool isNewMessageReceived_ = false;
    public bool IsOpenSuccessful { get; private set; }
    public static SerialHandler Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Open();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isNewMessageReceived_)
        {
            // イベントがnullでないことを確認
            OnDataReceived?.Invoke(message_);
            isNewMessageReceived_ = false;
        }
    }


    void OnDestroy()
    {
        Close();
    }

    public void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

        // タイムアウト設定 (ミリ秒)
        serialPort_.ReadTimeout = 500;   // 読み取りタイムアウト
        serialPort_.WriteTimeout = 500;  // 書き込みタイムアウト

        try
        {
            serialPort_.Open();
            UnityEngine.Debug.Log("Port opened successfully");
            IsOpenSuccessful = true;

            isRunning_ = true;
            UnityEngine.Debug.Log("isRunning_ set to " + isRunning_);
            thread_ = new Thread(Read);
            thread_.Start();
        }
        catch (Exception e)
        {
            UnityEngine.Debug.LogError("Error opening serial port: " + e.Message);
            IsOpenSuccessful = false;
        }
    }


    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive)
        {
            thread_.Join();
        }

        if (serialPort_ != null && serialPort_.IsOpen)
        {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    private void Read()
    {
        UnityEngine.Debug.Log("Read method started. Serial port open: " + serialPort_.IsOpen);
        while (isRunning_)
        {
            try
            {
                if (serialPort_ != null && serialPort_.IsOpen)
                {
                    message_ = serialPort_.ReadLine();  // ReadLine は ReadTimeout で設定されたタイムアウトを使用
                    UnityEngine.Debug.Log("Received data: " + message_);
                    isNewMessageReceived_ = true;
                }
            }
            catch (TimeoutException)
            {
                UnityEngine.Debug.LogWarning("Read timeout occurred.");
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogWarning("Read failed: " + e.Message);
                if (!isRunning_)
                {
                    return;  // スレッドを安全に終了
                }
            }
        }
    }

    public void Write(string message)
    {
        try
        {
            serialPort_.Write(message);
        }
        catch (System.Exception e)
        {
            UnityEngine.Debug.LogWarning(e.Message);
        }
    }
}
