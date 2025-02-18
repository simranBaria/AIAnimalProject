using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mosquito : MonoBehaviour
{
    public float hoverRadius, sampleFrequency, directionChangeFrequency;

    private Vector3 randomPoint = Vector3.zero, center;
    private float timerSinceLastDirectionChange = 0, timeSinceLastSample = 0;
    private Transform mosquitoTransform;

    // Start is called before the first frame update
    void Start()
    {
        mosquitoTransform = GetComponent<Transform>();
        center = mosquitoTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase timers
        timeSinceLastSample += Time.deltaTime;
        timerSinceLastDirectionChange += Time.deltaTime;

        // Move to new position
        if (timeSinceLastSample > sampleFrequency) transform.position = Vector3.Lerp(transform.position, center + randomPoint, Time.deltaTime);

        // Get a new random position
        if (timerSinceLastDirectionChange > directionChangeFrequency)
        {
            randomPoint = Random.insideUnitSphere.normalized * hoverRadius;
            timerSinceLastDirectionChange = 0;
        }

        // Die if morning
        if (!TimeCycle.isNight) Destroy(gameObject);
    }

    // Get eaten
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
