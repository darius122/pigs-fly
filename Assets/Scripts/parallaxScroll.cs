using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxScroll : MonoBehaviour
{
    Material mat;
    float distance;
    float Updistance;
    [Range(0f, 1f)]
    public float speed = 0.5f;
    [Range(0f, 1f)]
    public float Upspeed = 0.5f;
    public Camera orthographicCamera;
    [SerializeField] Transform parent;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
   

        distance += Time.deltaTime*speed;
        Updistance += Time.deltaTime * Upspeed;
        mat.SetTextureOffset("_MainTex",Vector2.right*distance + Vector2.up*Updistance);
    }

    
}
