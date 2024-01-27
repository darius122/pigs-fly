using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Init(ObjectInfo info)
    {
        Debug.Log(info.name);
        //sr.sprite = 
       // ObjectSpawner.instance.
    }
}
[System.Serializable]
public class ObjectInfoList
{
    public ObjectInfo[] objectInfoList;
}
[System.Serializable]
public class ObjectInfo
{
    public string name;
}