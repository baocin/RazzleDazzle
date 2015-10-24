using UnityEngine;
using System.Collections;

public class WallLamp : MonoBehaviour
{
    private Light LightComponent;
	void Start ()
    {
        LightComponent = GetComponent<Light>();
        StartCoroutine("FlickerOff");
    }
	
    IEnumerator FlickerOff()
    {
        while (true)
        {
            for (int i = 0; i < Random.Range(5, 15); i++)
            {
                LightComponent.enabled = false;
                yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
                LightComponent.enabled = true;
                yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            }
            LightComponent.enabled = false;
            yield return new WaitForSeconds(Random.Range(1, 10));
            StartCoroutine("FlickerOn");
        }
    }

    IEnumerator FlickerOn()
    {
        
        for (int i = 0; i < Random.Range(7, 20); i++)
        {
            LightComponent.enabled = true;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
            LightComponent.enabled = false;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.4f));
        }
        LightComponent.enabled = true;
        yield return new WaitForSeconds(Random.Range(1, 10));
        StartCoroutine("FlickerOff");
    }

}
