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
    public string portName = "COM11";
    public int baudRate = 115200;

    private SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    private string message_;
    private bool isNewMessageReceived_ = false;

    void Awake()
    {
        Open();
    }

    void Update()
    {
        if (isNewMessageReceived_)
        {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

        try
        {
            serialPort_.Open();
            UnityEngine.Debug.Log("Port opened successfully");

            isRunning_ = true;
            UnityEngine.Debug.Log("isRunning_ set to " + isRunning_);
            thread_ = new Thread(Read);
            thread_.Start();
        }
        catch (Exception e)
        {
            // エラーが発生した場合、エラーメッセージをログに記録
            UnityEngine.Debug.LogError("Error opening serial port: " + e.Message);
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
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen)
        {
            try
            {
                message_ = serialPort_.ReadLine();
                UnityEngine.Debug.Log("Received data: " + message_);
                isNewMessageReceived_ = true;
            }
            catch (System.Exception e)
            {
                UnityEngine.Debug.LogWarning(e.Message);
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
