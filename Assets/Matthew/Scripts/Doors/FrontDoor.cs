using UnityEngine;
using System.Collections;

public class FrontDoor : MonoBehaviour
{
    void OnTriggerStay(Collider obj)
    {
        if(obj.tag == "Player")
        {
            GameObject.Find("null").GetComponent<Manager>().FrontDoor();
        }
    }

    void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            Collider.gameObject.GetComponent<Notifications>().ResetNotify();
        }
    }
}
