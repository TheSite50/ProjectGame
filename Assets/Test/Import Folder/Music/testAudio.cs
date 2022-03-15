using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAudio : MonoBehaviour
{
    [SerializeField] private AudioSource volumeTest;
    [SerializeField] private AudioSource musicTest;
    [SerializeField] private AudioSource effectTest;
    [SerializeField] private AudioSource voiceTest;
    private void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            volumeTest.Play();
            musicTest.Stop();
            effectTest.Stop();
            voiceTest.Stop();
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            musicTest.Play();
            volumeTest.Stop();
            effectTest.Stop();
            voiceTest.Stop();
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            effectTest.Play();
            volumeTest.Stop();
            musicTest.Stop();
            voiceTest.Stop();
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            voiceTest.Play();
            volumeTest.Stop();
            musicTest.Stop();
            effectTest.Stop();
        }
    }
}
