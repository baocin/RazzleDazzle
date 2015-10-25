using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour
{
    void OnTriggerEnter(Collider obj)
    {
        if(obj.tag == "Player" && gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
            obj.GetComponent<Misc>().ActivateFlashlight();
        }
    }
}
