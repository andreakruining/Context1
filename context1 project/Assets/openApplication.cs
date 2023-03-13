using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using TMPro;
using UnityEditor;

public class openApplication : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartOtherProgram);
    }

    void StartOtherProgram()
    {
        Process process = new Process();
        process.StartInfo.FileName = "D:\\installations\\Arduino IDE\\Arduino IDE.exe"; // replace with the path to your program
        process.StartInfo.UseShellExecute = true;
        process.Start();
    }


    //D:\\installations\\Krita (x64)\\bin\\krita.exe
    //D:\\installations\\Arduino IDE\\Arduino IDE.exe


    // [SerializeField] private TextMeshProUGUI outputText;
    // [SerializeField] private Button startButton;

    // private void Start()
    // {
    //     startButton.onClick.AddListener(CreateProcess);
    // }

    // private void CreateProcess()
    // {
    //     var processInfo = new ProcessStartInfo
    //     {
    //         WorkingDirectory = Application.persistentDataPath,
    //         WindowStyle = ProcessWindowStyle.Normal,
    //         FileName = "explorer.exe",
    //         UseShellExecute = false,
    //         CreateNoWindow = true,
    //         RedirectStandardOutput = true,
    //     };

    //     var process = Process.Start(processInfo);
    //     var result = process.StandardOutput.ReadToEnd();

    //     process.WaitForExit();

    //     outputText.text = result;
    // }





    // public static void Openen()
    // {
    //     string pathToExe = Application.persistantDataPath; //Replace(@"/", @"\") + "\\Plugins\\";
    //     string command = pathToExe + "D:\installations\Arduino IDE";
    //     Process process = Process.Start("Arduino IDE.exe", command);
    //     process.WaitForExit();
    //     process.Close();
    // }

}
