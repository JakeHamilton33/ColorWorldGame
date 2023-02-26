using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleWipeController : MonoBehaviour
{
    public static CircleWipeController instance;
    
    public float _radius;
    
    public Shader shader;

    private Material material;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        
        material = new Material(shader);
    }

    private void Update()
    {
        material.SetFloat("_Radius", _radius);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
