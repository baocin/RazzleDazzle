using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class GeneralDoorBehaviour : MonoBehaviour
{
    public bool CanBeOpened = true;
    public bool DoorInFocus = false; // Player is in the trigger.
    public bool IsOpen = true;
    public bool Locked = false;
    public string Axis = "x";
    public float Offset = 90f;
    public GameObject DoorObject;
    public CoorPoints AxisPoints;
    [System.Serializable]
    public class CoorPoints
    {
        public float Open, Close;
    }
    
    private Quaternion rotation = Quaternion.identity;

    void OnTriggerStay(Collider Collider)
    {
        if(Collider.gameObject.tag == "Player")
        {
            Collider.gameObject.GetComponent<Notifications>().Notify("Press the interact key to use the door.");
            //Debug.Log("Player has entered");
            DoorInFocus = true;
        }
    }

    void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            Collider.gameObject.GetComponent<Notifications>().ResetNotify();
            //Debug.Log("Player has exited");
            DoorInFocus = false;
        }
    }

    void Update()
    {
        if (DoorInFocus)
        {
            if (Input.GetButtonUp("Interact") && CanBeOpened)
            {
                Debug.Log("Interacted with door.");
                IsOpen = DoDoor();
            }
        }
    }

    bool DoDoor()
    {
        string axis = Axis.ToLower();
        if(axis == "x")
        {
            if (IsOpen)
            {
                DoorObject.gameObject.transform.Rotate((AxisPoints.Close - AxisPoints.Open), 0, 0);
                return false;
            }
            else
            {
                DoorObject.gameObject.transform.Rotate(-(AxisPoints.Close - AxisPoints.Open), 0, 0);
                return true;
            }
        }
        else if(axis == "y")
        {
            if (IsOpen)
            {
                DoorObject.gameObject.transform.Rotate(-(AxisPoints.Close - AxisPoints.Open), 0, 0);
                return false;
            }
            else
            {
                DoorObject.gameObject.transform.Rotate((AxisPoints.Close - AxisPoints.Open), 0, 0);
                return true;
            }
        }
        else if(axis == "z")
        {
            if (IsOpen)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}
