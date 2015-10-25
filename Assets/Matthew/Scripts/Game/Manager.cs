using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Manager : MonoBehaviour
{
    AudioSource _audio;
    public Canvas NotesCanvas;
    public Sprite[] Notes;
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

    public void ActivateNote(int i)
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().noteOpen = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        NotesCanvas.gameObject.SetActive(true);
        switch (i)
        {
            case 0:
                NotesCanvas.gameObject.GetComponentInChildren<Image>().sprite = Notes[0];
                break;
            case 1:
                NotesCanvas.gameObject.GetComponentInChildren<Image>().sprite = Notes[1];
                break;
        }
    }

    public void CloseNote()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().noteOpen = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        NotesCanvas.gameObject.SetActive(false);
    }
}
