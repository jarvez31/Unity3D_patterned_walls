using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class CheckertiltedStripes : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material material;
    Texture2D texture;
    [SerializeField] float width_x = 256.0f;
    [SerializeField] float width_y = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
        texture = new Texture2D(256, 256, TextureFormat.RGBA32, true, true);
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;
        material.SetTexture("_MainTex", texture);
        CreateCheckerboard();
    }
    void CreateCheckerboard()
    {
        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                Color temp = EvaluateCheckerboardPixel(x, y);
                texture.SetPixel(x, y, temp);
            }
        }
        texture.Apply();
    }
    Color EvaluateCheckerboardPixel(int x, int y)
    {
        //float valueX = (y % (width_x * 2)) / (width_x * 2.0f);
        //int vX = 1;
        //if (valueX < 0.5f)
        // vX = 0;
        //if (y>=x)
        //{
            float valueY = (Math.Abs(y + x) % (width_y * 2)) / (width_y * 2.0f);
        //}
        //else
        //{
         //  float valueY = ((x - y) % (width_y * 2)) / (width_y * 2.0f);
        //}

        int vY = 1;
        if (valueY < 0.5f)
            vY = 0;

        float value_r = 0;
        float value_g = 0;
        float value_b = 0;
        if (vY == 0)
        {
            value_r = 0f;
            value_g = 1f;
            value_b = 0f;

        }
        else
        {
            value_r = 1f;
            value_g = 0f;
            value_b = 1f;
        }

        return new Color(value_r, value_g, value_b, 1.0f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
