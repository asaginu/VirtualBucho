using UnityEngine;
using UnityEngine.EventSystems;
using System.IO;
using SFB;
using System.Text;

namespace WavFile
{
    public class FileLoader : MonoBehaviour, IPointerDownHandler
    {
        public static FileLoader Instance{get; private set;} = null;
        //読み込むファイル形式
        ExtensionFilter[] extensions = new[] {
                //new ExtensionFilter("txt Files", "txt"),
                new ExtensionFilter("Sound File", "wav" ),
            };

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
        public void OnPointerDown(PointerEventData eventData) { }
        private string path;

        private void Start()
        {
            path = Application.dataPath;
        }
        public AudioClip[] Load()
        {
            string[] openPaths;
            if (File.Exists(Config.Instance.path))
            {
                openPaths = StandaloneFileBrowser.OpenFilePanel("Open File", Config.Instance.path, extensions, true);
            }
            else
            {
                openPaths = StandaloneFileBrowser.OpenFilePanel("Open File", "", extensions, true);
            }
            return LoadWavFile(openPaths);
        }
        private AudioClip[] LoadWavFile(string[] paths)
        {
            AudioClip[] clip = new AudioClip[paths.Length];
            for (int i = 0; i < paths.Length; i++)
            {
                byte[] bytes = File.ReadAllBytes(paths[i]);
                clip[i] = WavUtility.ToAudioClip(bytes);
                var name =  LoadNameTxt(paths[i]);
                if (name != null)
                {
                    clip[i].name = name;
                }
                else
                {
                    clip[i].name = Path.GetFileName(paths[i]);
                }
            }
            return clip;
        }
        private string LoadNameTxt(string path)
        {
            var txtPath = Config.Instance.path +"/"+Path.GetFileNameWithoutExtension(path) + ".txt";
            Debug.Log("txtPath "+txtPath);
            if (File.Exists(txtPath))
            {
                StreamReader sr = new StreamReader(txtPath, Encoding.UTF8);
                string txt = sr.ReadToEnd();
                sr.Close();
                Debug.Log("txt file: " + txt);
                return txt;
            }
            else
            {
                Debug.Log("txt is none");
                return null;
            }
        }
        public void InitLoad()
        {

        }
    }
}