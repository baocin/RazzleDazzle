using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    AudioSource _audio;
    public GameObject[] FlashlightSpawns;
    public GlitchVars Glitch;
    [System.Serializable]
    public class GlitchVars
    {
        public float MinimumTime, MaximumTime;
        public AudioClip[] Sound;
    }
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
        SpawnFlashlight();
        StartCoroutine("GlitchInterval");
    }

    void SpawnFlashlight()
    {
        FlashlightSpawns[Random.Range(0, Mathf.RoundToInt(FlashlightSpawns.Length - 1))].gameObject.SetActive(true);
    }

    IEnumerator GlitchInterval()
    {
        yield return new WaitForSeconds(Random.Range(Glitch.MinimumTime, Glitch.MaximumTime));
        _audio.PlayOneShot(Glitch.Sound[Random.Range(0, Mathf.RoundToInt(Glitch.Sound.Length - 1))], 0.8f);
        StartCoroutine("GlitchInterval");
    }
}
