using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpd = 6f;
    [SerializeField] float timeBetweenSpawn = 1f;
    [SerializeField] float spawnTimeVariance = 0.5f;
    [SerializeField] float minimumSpawnTime = 0.3f;

    public Transform GetStartWaypt()
    {
        return pathPrefab.GetChild(0);
    }
    public List<Transform> GetWaypts()
    {
        List<Transform> waypts = new List<Transform>();
        foreach( Transform c in pathPrefab)
        {
            waypts.Add(c);
        }
        return waypts;
    }
    public float GetMoveSpd()
    {
        return moveSpd;
    }
    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }
    public GameObject GetEnemyPrefab(int i)
    {
        return enemyPrefabs[i];
    }
    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(timeBetweenSpawn - spawnTimeVariance, timeBetweenSpawn  + spawnTimeVariance);
        return Mathf.Clamp(spawnTime, minimumSpawnTime, float.MaxValue);
    }
}
