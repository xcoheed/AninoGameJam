using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    [SerializeField] private Renderer scrollRenderer;
    [SerializeField] private float speed = 0.5f;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 offset = new Vector2(Time.time * speed, 0);

        if (scrollRenderer != null)
        {
            scrollRenderer.material.mainTextureOffset = offset;
        }
    }
}
