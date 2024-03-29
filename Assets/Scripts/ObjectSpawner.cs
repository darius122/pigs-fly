using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public static ObjectSpawner instance;
    [SerializeField] private GameObject objectPrefab;
    private Vector2 spawnPosition;
    //private List<ObjectScript> objectList = new List<ObjectScript>();
    private ObjectInfoList objectList;

    [SerializeField] private TextAsset objectTextAsset;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        objectList = JsonUtility.FromJson<ObjectInfoList>(objectTextAsset.text);
        InvokeRepeating("SpawnObjects", 3f, 2f);
       // Invoke("SpawnObjects", 3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnObjects()
    {
        float xPos = PlayerBoundaries.instance.screenBounds.x + 2;
        float randomY = Random.Range(-PlayerBoundaries.instance.screenBounds.y + 2, PlayerBoundaries.instance.screenBounds.y - 2);
        spawnPosition = new Vector2(xPos,randomY);
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        int rand = (int)Random.Range(cameraManegement.ins.level, cameraManegement.ins.level + 2);
        rand = (int)Mathf.Clamp(rand, cameraManegement.ins.level, objectList.objectInfoList.Length - 1);
        //Debug.Log(rand);
        //ObjectScript _objectScript 
        newObject.GetComponent<ObjectScript>().Init(objectList.objectInfoList[rand]);
        //objectList.Add(new)
    }
}
