using UnityEngine;
using System.Collections;

public class ChairScare : MonoBehaviour
{
    bool hasScared = false;
    AudioSource _audio;
    public AudioClip Roar, Scream, Thunder;
    public GameObject Hanger;
    public GameObject Lightning, Atmoshpere;

    void Awake()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    // Commnence the oh shit.
    void OnTriggerEnter(Collider obj)
    {
        //Debug.Log("Item has entered");
        if (obj.tag == "Player")
        {
            if (!hasScared)
            {
                Debug.Log(obj.name);
                Debug.Log("Playing sounds");
                //_audio.PlayOneShot(Thunder, 0.4f);
                Hanger.SetActive(true);
                _audio.PlayOneShot(Roar, 0.7f);
                _audio.PlayOneShot(Scream, 0.5f);
                StartCoroutine("Flicker");
            }
        }
    }

    IEnumerator Flicker()
    {
        for (int i = 0; i < Random.Range(3, 6); i++)
        {
            Lightning.SetActive(true);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            Lightning.SetActive(false);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        }
        yield return new WaitForSeconds(2.25f);
        StartCoroutine("ReturnToNorm");
    }

    IEnumerator ReturnToNorm()
    {
        hasScared = true;
        Lightning.SetActive(false);
        Destroy(Hanger);
        for (int i = 1; i > 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            _audio.volume -= 0.1f;
        }
    }
}
