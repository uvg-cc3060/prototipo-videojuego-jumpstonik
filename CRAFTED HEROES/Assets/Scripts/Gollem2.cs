using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gollem2 : MonoBehaviour
{

    float rotationAngle;
    float rotationSpeed;
    float time;
    float rotationTime = 0.5f;
    public float speed = 5f;
    Vector3 initialRotation;
    Vector3 finalRotation;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewRotationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.Lerp(initialRotation, finalRotation, Mathf.Clamp(time / rotationTime, 0, 1)));
        transform.Translate(transform.forward * speed * Time.deltaTime);
        time += Time.deltaTime;
    }

    void NewRotation() {
        initialRotation = transform.rotation.eulerAngles;
        finalRotation = new Vector3(initialRotation.x, initialRotation.y + Random.Range(30f, 40f), initialRotation.z);
        time = 0;
    }

    IEnumerator NewRotationCoroutine() {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            NewRotation();
        }
    }
}
