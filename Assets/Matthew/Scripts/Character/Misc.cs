using UnityEngine;
using System.Collections;

public class Misc : MonoBehaviour
{
    public GameObject Flashlight;

    public void ActivateFlashlight()
    {
        Flashlight.SetActive(true);
        gameObject.GetComponent<Notifications>().Notify("Press F to toggle your flashlight");
        StartCoroutine("Wait");
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<Notifications>().ResetNotify();
    }
}
