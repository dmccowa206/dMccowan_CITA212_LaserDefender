using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpd = 6f;

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
}
