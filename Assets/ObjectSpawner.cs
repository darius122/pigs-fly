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

    public PlayerBoundaries pb;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SpawnObjects()
    {
        float xPos = pb.screenBounds.x - 2;
        float randomY = Random.Range(-pb.screenBounds.y + 2, pb.screenBounds.y - 2);
        spawnPosition = new Vector2(xPos,randomY);
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, Quaternion.identity);
        int rand = Random.Range(0, objectList.objectInfoList.Length);
        //ObjectScript _objectScript 
        newObject.GetComponent<ObjectScript>().Init(objectList.objectInfoList[rand]);
        //objectList.Add(new)
    }
}
