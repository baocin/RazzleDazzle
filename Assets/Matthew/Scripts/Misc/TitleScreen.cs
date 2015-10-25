using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour
{
    public Camera cam;
    public float shake = 0f, shakeAmount = 0.7f, decreaseFactor = 1.0f;

    void Update()
    {
        if (shake > 0)
        {
            cam.transform.localPosition = new Vector3((Random.insideUnitSphere.x * shakeAmount), (float)(Random.insideUnitSphere.y * shakeAmount));
            shake -= Time.deltaTime * decreaseFactor;
        }
        if (shakeAmount > 25)
        {
            shakeAmount += 0.15f * Time.deltaTime;
        }
    }
}
