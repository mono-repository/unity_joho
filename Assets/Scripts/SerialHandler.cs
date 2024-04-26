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
    public string portName = "COM3";
    public int baudRate = 115200;

    private SerialPort serialPort_;
    private bool isRunning_ = false;

    private bool isNewMessageReceived_ = false;
    public bool IsOpenSuccessful { get; private set; }

    void Awake()
    {
        Open();
    }

    void Update()
    {
        Read();
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
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

        if (serialPort_ != null && serialPort_.IsOpen)
        {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    private void Read()
    {
        if (serialPort_ != null && serialPort_.IsOpen && serialPort_.BytesToRead > 0)
        {
            try
            {
                string message = serialPort_.ReadLine();  // ReadLine は ReadTimeout で設定されたタイムアウトを使用
                UnityEngine.Debug.Log("Received data: " + message);
                isNewMessageReceived_ = true;

                OnDataReceived?.Invoke(message);
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
