using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planemovimiento : MonoBehaviour
{
    public float WF_speed = 0.75f;

    public Renderer WF_renderer;
    // Start is called before the first frame update
    void Start()
    {
        WF_renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float TextureOffset = Time.time * WF_speed;
        WF_renderer.material.SetTextureOffset("_MainTex", new Vector2(0, TextureOffset));
    }
}

