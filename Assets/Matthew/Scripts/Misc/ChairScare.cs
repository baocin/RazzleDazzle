using UnityEngine;
using System.Collections;

public class ChairScare : MonoBehaviour
{
    bool hasScared = false;
    AudioSource _audio;
    public AudioClip Roar, Scream, Thunder;
    public GameObject Bolter;
    public GameObject Lightning, Atmoshpere;

    void Awake()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    // Commnence the oh shit.
    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Item has entered");
        if (obj.tag == "Player")
        {
            _audio.PlayOneShot(Thunder, 0.4f);
            Bolter.SetActive(true);
            _audio.PlayOneShot(Roar, 0.7f);
            _audio.PlayOneShot(Scream, 0.5f);
            StartCoroutine("Flicker");
        }
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(5, 15); i++)
            {
                Debug.Log("Running");
                Lightning.SetActive(true);
                yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
                Lightning.SetActive(false);
                yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            }
        }
    }
}
