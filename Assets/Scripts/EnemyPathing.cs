using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] WaveConfig waveConfig;
    List<Transform> waypts;
    int wayptIndex = 0;
    void Start()
    {
        waypts = waveConfig.GetWaypts();
        transform.position = waypts[wayptIndex].position;        
    }
    void Update()
    {
        FollowPath();
    }
    void FollowPath()
    {
        if (wayptIndex < waypts.Count)
        {
            Vector3 targetPos = waypts[wayptIndex].position;
            float delta = waveConfig.GetMoveSpd() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, delta);
            if(transform.position == targetPos)
            {
                wayptIndex++;
            }
        }
    }
}
