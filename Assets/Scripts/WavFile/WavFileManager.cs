using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WavFile
{
    public class WavFileManager : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;

        private string folderPath;
        private AudioClip clip;
        private AudioClip[] clips;

        public void LoadFile()
        {
            FileLoader.Instance.InitLoad();
        }
        public void AddFile()
        {
            clips = FileLoader.Instance.Load();
            for (int i = 0; i < clips.Length; i++)
            {
                canvas.GetComponent<VoiceItemUI>().InsertItem(clips[i]);
            }
        }
        public void RemoveFile()
        {

        }
    }
}