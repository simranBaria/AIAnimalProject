using System.Collections;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public float time;

    void Start()
    {
        StartCoroutine(Dissappear());
    }

    void Update()
    {
        // Billboard prop, look towards the camera
        transform.LookAt(Camera.main.transform.position);
    }

    IEnumerator Dissappear()
    {
        // Dissapear after set time
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
