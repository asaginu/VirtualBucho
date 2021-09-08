using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Canvas))]
public class VoiceItemUI : MonoBehaviour
{
    [SerializeField] private GameObject _itemParent;
    [SerializeField] private EventSystem _eventSystem;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _settingPanel;
    public RectTransform prefab;

    public List<RectTransform> items;

    public RectTransform _selectedItem;

    private void Start()
    {
        items = new List<RectTransform>();
        if (_settingPanel == enabled) CloseConfigPanel();
    }
    private RectTransform SetItem(RectTransform item, AudioClip clip)
    {
        item.GetComponent<VoiceWav>().SetAudioClip(clip);
        item.GetComponent<VoiceWav>().SetTitle(clip.name);
        item.name = clip.name;
        item.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => SelectingItem(item));

        return item;
    }
    public void InsertItem(AudioClip clip)
    {
        var item = Instantiate(prefab) as RectTransform;
        SetItem(item, clip);
        items.Add(item);
        item.SetParent(_itemParent.GetComponent<Transform>(), false);
    }
    public void PlayWav()
    {
        //var selectedItem = _eventSystem.currentSelectedGameObject.gameObject;
        Debug.Log("selectitem: " + _selectedItem);
        _audioSource.clip = _selectedItem.GetComponent<VoiceWav>().GetAudioClip();
        _selectedItem.GetComponent<VoiceWav>().OnPlay();

        _audioSource.Play();
    }
    public void SelectingItem(RectTransform item)
    {
        if (item.tag == "Voice") return;
        else
        {
            _selectedItem = item;
        }
    }
    public void OpenConfigPanel()
    {
        _settingPanel.SetActive(true);
    }
    public void CloseConfigPanel()
    {
        _settingPanel.SetActive(false);
    }
    /// <summary>
    /// とりあえずコンフィグのinputfieldが書き終わったら呼ぶ
    /// </summary>
    /// <param name="path"></param>
    public void SetConfigInfo(string path)
    {
        SetConfigPath(path);
    }
    private void SetConfigPath(string path)
    {
        Config.Instance.path = path;
    }
}