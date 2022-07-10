using System;
using UnityEngine;

public class WayPoint  : MonoBehaviour
{
    [SerializeField]  Tower towerprefab;
    [SerializeField]  bool isPlaceable;

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }
   
   private void OnMouseDown()
   {
       if (isPlaceable)
       {
          
           bool isPlaced = towerprefab.createTower(towerprefab , transform.position);
           isPlaceable = !isPlaced; // so u dont place another tower on the same place 
       }
   }
}
