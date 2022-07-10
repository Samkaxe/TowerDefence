using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField]  List<WayPoint> path = new List<WayPoint>();
    [SerializeField]  [Range(0f , 5f) ]float speed = 1f;
    private Enemy enemy;
    
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnEnable()
    {
        Findpath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }


    void Findpath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("path");
        foreach(Transform child in parent.transform)
        {
            WayPoint wayPoint = child.GetComponent<WayPoint>();
            if (wayPoint != null)
            {
                path.Add(wayPoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    
    IEnumerator FollowPath()
    {
        foreach (WayPoint wayPoint in path)
        {
            Vector3 startpostion = transform.position;
            Vector3 endpostion = wayPoint.transform.position;
            float travelpercent = 0f;
            transform.LookAt(endpostion);
            while (travelpercent < 1f)
            {
                travelpercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startpostion, endpostion, travelpercent);
                yield return new WaitForEndOfFrame();
            }
        }
        
        FinishPath /* I mess Java */  ();
    }
}
