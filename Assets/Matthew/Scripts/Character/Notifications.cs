using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Notifications : MonoBehaviour
{
    public Text NotifyText;
    public void Notify(string msg)
    {
        NotifyText.text = msg;
    }

    public void ResetNotify()
    {
        NotifyText.text = "";
    }
}
