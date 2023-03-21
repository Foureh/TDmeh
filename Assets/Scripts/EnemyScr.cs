using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScr : MonoBehaviour
{
    List<GameObject> wayPoints = new List<GameObject> ();

    int wayIndex = 0;
    int speed = 4;

    private void Start()
    {
        GetWaypoints ();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void GetWaypoints()
    {
        wayPoints = GameObject.Find("LevelGroup").GetComponent<LevelManagerScr>().wayPoints;
    }

    private void Move()
    {
        Transform currWayPoint = wayPoints[wayIndex].transform;
        Vector3 currWayPos = new Vector3(currWayPoint.position.x + currWayPoint.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                                         currWayPoint.position.y - currWayPoint.GetComponent<SpriteRenderer>().bounds.size.y / 2);

        Vector3 dir = currWayPos - transform.position;

        transform.Translate(dir.normalized * Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, currWayPos) < 0.1f)
        {
            if (wayIndex < wayPoints.Count - 1)
                wayIndex++;
            else Destroy(gameObject);
        }
    }
}
