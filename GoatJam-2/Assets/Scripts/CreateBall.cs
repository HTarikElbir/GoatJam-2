using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CreateBall : MonoBehaviour
{   GameObject newObject;


    [Serializable]
    public struct Ball
    {
       public GameObject objectPrefab;
       public float spawnInterval;
       public float minSpawnX;
        public float maxSpawnX;
        public float minSpawnY;
        public float maxSpawnY;
        public float minDuration;
        public float maxDuration;

    }
    [SerializeField] private Ball powerBall;
    



    private float spawnTimer = 0f; 

    void Update()
    {
        // spawnInterval aralıklarla yeni objeler oluştur
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= powerBall.spawnInterval)
        {
            SpawnObject();
            spawnTimer = 0f;
        }
    }

    void SpawnObject()
    {
        // rastgele bir konum ve süre belirle
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(powerBall.minSpawnX, powerBall.maxSpawnX), UnityEngine.Random.Range(powerBall.minSpawnY, powerBall.maxSpawnY), 0f);
        float duration = UnityEngine.Random.Range(powerBall.minDuration, powerBall.maxDuration);

        // objeyi oluştur
        Instantiate(powerBall.objectPrefab, spawnPosition, Quaternion.identity);

        // objeyi belirtilen süre sonra yok et
        
        
        Destroy(newObject, duration);
        
    
    }



}
