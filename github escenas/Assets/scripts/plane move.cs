﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planemov : MonoBehaviour
{
    float scrollSpeed = 0.5f;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
