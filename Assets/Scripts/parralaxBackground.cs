using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class parralaxBackground : MonoBehaviour
{
    public ParallaxCamera parallaxCamera;
    List<parallaxLayer> parallaxLayers = new List<parallaxLayer>();

    void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;

        SetLayers();
    }

    void SetLayers()
    {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            parallaxLayer layer = transform.GetChild(i).GetComponent<parallaxLayer>();

            if (layer != null)
            {
                layer.name = "Layer-" + i;
                parallaxLayers.Add(layer);
            }
        }
    }

    void Move(float delta)
    {
        foreach (parallaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}