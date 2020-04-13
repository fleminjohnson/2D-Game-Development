using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private float lowY;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;

        lowY = transform.position.y;
    }

    private void LateUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector2.Lerp(transform.position, targetCamPos, 5.0f * Time.deltaTime);
        if (transform.position.y < lowY) transform.position = new Vector3(transform.position.x,lowY, transform.position.z);
    }
}
