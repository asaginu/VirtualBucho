using UnityEngine;
using TMPro;
using System.IO;

public class ConfigUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputFiled;
    /// <summary>
    /// とりあえずコンフィグのinputfieldが書き終わったら呼ぶ
    /// </summary>
    /// <param name="path"></param>
    public void SetConfigInfo()
    {
        SetConfigPath(inputFiled.text);
    }
    private void SetConfigPath(string path)
    {
        var l = path.Length;
        if (path.Substring(l - 1) == "/")
        {
            path = path.Substring(0, l - 1);
        }
        Config.Instance.path = path;
        Debug.Log("path: " + path);
    }
}
