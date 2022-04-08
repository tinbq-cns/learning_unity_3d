using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject ball;
    private Plane _plane = new Plane(Vector3.forward * -1, 15);
    public Transform target;
    public float ballForce;

    // Update is called once per frame
    void Update()
    {
        var dir = target.position - ball.transform.position;
        if (Input.GetMouseButtonDown(0)) {
            ball.GetComponent<Rigidbody>().AddForce(dir * ballForce, ForceMode.Impulse);
        }

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_plane.Raycast(ray, out distance)) {
            Vector3 hitPoint = ray.GetPoint(distance);
            target.position = new Vector3(hitPoint.x, hitPoint.y, hitPoint.z);
        }
    }
}
