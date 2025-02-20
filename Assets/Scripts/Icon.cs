using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Dissappear());
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform.position);
    }

    IEnumerator Dissappear()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
