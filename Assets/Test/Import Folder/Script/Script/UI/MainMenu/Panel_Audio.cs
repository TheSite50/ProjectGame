using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Panel_Audio : MonoBehaviour
{
    [SerializeField] private AudioMixer audioVolumeControll;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider voiceSlider;
    [SerializeField] private Slider effectSlider;
    public void SetVolume()
    {
        audioVolumeControll.SetFloat("Volume", volumeSlider.value*100-80);
    }
    public void SetMusicVolume()
    {
        audioVolumeControll.SetFloat("Music", musicSlider.value* 100 - 80);
    }
    public void SetVoiceVolume()
    {
        audioVolumeControll.SetFloat("Voice", voiceSlider.value* 100 - 80);
    }
    public void SetEffectVolume()
    {
        audioVolumeControll.SetFloat("Effect", effectSlider.value* 100 - 80);
    }
}
