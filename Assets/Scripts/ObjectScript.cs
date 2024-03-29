using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private AudioSource audioSource;
    private float objectSpeed = 20;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1f), 100 * Time.deltaTime);
        transform.Translate(Vector2.left * objectSpeed * Time.deltaTime, Space.World);
        if (audioSource != null && audioSource.time > 5f)
            audioSource.Stop();
        CheckDestroy();
    }
    public void Init(ObjectInfo info)
    {
        sr.sprite = Resources.Load<Sprite>("Sprites/FallingObjects/" + info.name);
        audioSource.clip = Resources.Load<AudioClip>("Sounds/" + info.name);
        if(audioSource.clip != null)
        {
            audioSource.Play();
            Debug.Log("jkfn");
        }
        boxCollider.size = sr.bounds.size;
        boxCollider.size /= transform.localScale;
        //sr.sprite = 
       // ObjectSpawner.instance.
    }
    private void CheckDestroy()
    {
        if(transform.position.x < PlayerBoundaries.instance.screenBounds.y * -1 - 30)
        {
            Destroy(gameObject);
        }
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