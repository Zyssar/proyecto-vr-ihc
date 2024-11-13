using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class VolumeController : MonoBehaviour
{
    [Header("UI Elements")]
    public TMPro.TMP_Text volumeText;
    public AudioSource backgroundMusic;

    private Slider volumeSlider;

    void Start()
    {
        volumeSlider = GetComponent<Slider>();

        if (backgroundMusic != null)
        {
            volumeSlider.value = backgroundMusic.volume;
        }

        volumeSlider.onValueChanged.AddListener(UpdateVolume);
        UpdateVolumeText(volumeSlider.value);
    }

    void UpdateVolume(float value)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = value;
        }
        UpdateVolumeText(value);
    }

    void UpdateVolumeText(float value)
    {
        int volumePercentage = Mathf.RoundToInt(value * 100);
        volumeText.text = volumePercentage + "%";
    }

    void OnDestroy()
    { 
        volumeSlider.onValueChanged.RemoveListener(UpdateVolume);
    }
}
