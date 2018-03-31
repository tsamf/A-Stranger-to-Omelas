using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    [Tooltip("Sets how fast a parallax is relative to the camera.")]
    public float parallaxFactor;

    [Tooltip("Sets the direction of the parallax.")]
    public bool sameDirectionAsCamera = false;

    void Start() {
        UpdateParrallax();
    }

    void Update() {
        UpdateParrallax();
    }

    void UpdateParrallax()
    {
        if (sameDirectionAsCamera)
        {
            float newPositionX = Camera.main.transform.position.x * parallaxFactor;
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
        else
        {
            float newPositionX = Camera.main.transform.position.x * parallaxFactor * -1;
            transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);
        }
    }
}
