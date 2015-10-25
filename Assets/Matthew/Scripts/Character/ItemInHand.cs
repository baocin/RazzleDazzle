using UnityEngine;
using System.Collections;

public class ItemInHand : MonoBehaviour
{
    public GameObject Parent;
    float MaxUpDown = 0.1f;
    float Speed = 150;
    protected float angle = 0;
    protected float toDegrees = Mathf.PI / 180;

    void Update()
    {
        angle += Speed * Time.deltaTime;
        if(angle > 360)
        {
            angle -= 360;
        }
        transform.position = new Vector3((Parent.transform.position.x), ((MaxUpDown * Mathf.Sin(angle * toDegrees)) + 2f), (Parent.transform.position.z + 0.25f));
    }
}
