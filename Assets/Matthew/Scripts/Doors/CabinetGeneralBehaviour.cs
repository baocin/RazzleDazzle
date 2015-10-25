using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class CabinetGeneralBehaviour : MonoBehaviour
{

    public bool CanBeOpened = true;
    public bool DoorInFocus = false; // Player is in the trigger.
    public bool IsOpen = true;
    public bool Locked = false;
    public GameObject Door;
    public string Axis = "left";
    public float Offset = 90f;
    public CoorPoints AxisPoints;
    [System.Serializable]
    public class CoorPoints
    {
        public float Open, Close;
    }

    private Quaternion rotation = Quaternion.identity;

    void OnTriggerStay(Collider Collider)
    {
        if (Collider.gameObject.tag == "Player" && CanBeOpened)
        {
            Collider.gameObject.GetComponent<Notifications>().Notify("Press the interact key to use the door.");
            Debug.Log("Player has entered");
            DoorInFocus = true;
        }
    }

    void OnTriggerExit(Collider Collider)
    {
        if (Collider.gameObject.tag == "Player" && CanBeOpened)
        {
            Collider.gameObject.GetComponent<Notifications>().ResetNotify();
            Debug.Log("Player has exited");
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
        if (axis == "left")
        {
            if (IsOpen)
            {
                Door.gameObject.transform.Rotate(0, 0, -(AxisPoints.Close - AxisPoints.Open));
                return false;
            }
            else
            {
                Door.gameObject.transform.Rotate(0, 0, (AxisPoints.Close - AxisPoints.Open));
                return true;
            }
        }
        else if (axis == "right")
        {
            //Debug.Log(Door.transform.localRotation);
            if (IsOpen)
            {
                //Door.gameObject.transform.localRotation = Quaternion.Euler(90, 90, 90);
                Door.gameObject.transform.Rotate(0, 0, (AxisPoints.Close - AxisPoints.Open));
                //transform.eulerAngles = new Vector3(transform.eulerAngles.x + 10, transform.eulerAngles.y + 10, transform.eulerAngles.z + 10);
                return false;
            }
            else
            {
                Door.gameObject.transform.Rotate(0, 0, -(AxisPoints.Close - AxisPoints.Open));
                return true;
            }
        }
        else
        {
            return false;
        }
    }
}
