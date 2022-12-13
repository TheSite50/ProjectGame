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

   // private void Awake()
   // {
   //     audioVolumeControll.SetFloat("Volume", );
   //     audioVolumeControll.SetFloat("Music", musicSlider.value);
   //     audioVolumeControll.SetFloat("Voice", voiceSlider.value);
   //     audioVolumeControll.SetFloat("Effect", effectSlider.value);
   // }
    public void SetVolume()
    {
        audioVolumeControll.SetFloat("Volume", volumeSlider.value);
    }
    public void SetMusicVolume()
    {
        audioVolumeControll.SetFloat("Music", musicSlider.value);
    }
    public void SetVoiceVolume()
    {
        audioVolumeControll.SetFloat("Voice", voiceSlider.value);
    }
    public void SetEffectVolume()
    {
        audioVolumeControll.SetFloat("Effect", effectSlider.value);
    }
}