using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float backgroundSize;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;

    private void Start()
    {
        leftIndex = 0;
        rightIndex = layers.Length - 1;
    }

    private void Update()
    {
        if (cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone))
            ScrollLeft();

        if (cameraTransform.position.x > (layers[rightIndex].transform.position.x + viewZone))
            ScrollRight();

        Debug.Log("SCROLL LEFT: " + ((layers[leftIndex].transform.position.x + viewZone)));
        Debug.Log("SCROLL RIGHT: " + ((layers[rightIndex].transform.position.x + viewZone)));

    }

    private void ScrollLeft()
    {
        Debug.Log("LEFTTTT");

        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }

    private void ScrollRight()
    {
        Debug.Log("RIGHTTT");

        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
            leftIndex = 0;
    }
}
