﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1,1)]
    public float scrollSpeed = .5f;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * scrollSpeed/10;
        mat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
