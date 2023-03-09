using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;
using TMPro;

public class openApplication : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI outputText;
    [SerializeField] private Button startButton;

    private void Start()
    {
        startButton.onClick.AddListener(CreateProcess);
    }

    private void CreateProcess()
    {
        var processInfo = new ProcessStartInfo
        {
            WorkingDirectory = Application.persistentDataPath,
            WindowStyle = ProcessWindowStyle.Normal,
            FileName = "explorer.exe",
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
        };

        var process = Process.Start(processInfo);
        var result = process.StandardOutput.ReadToEnd();

        process.WaitForExit();

        outputText.text = result;
    }
}
