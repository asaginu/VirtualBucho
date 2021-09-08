using UnityEngine;

public class Config : MonoBehaviour
{
    public static Config Instance { get; private set; } = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    public string path{ get; set; }
}
