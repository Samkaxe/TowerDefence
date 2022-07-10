using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private int cost = 75;
    
     public  bool createTower(Tower tower , Vector3 position)
     {
         TheBank bank = FindObjectOfType<TheBank>();
         if (bank == null)
         {
             return false;
         }

         if (bank.CurrentBalance >= cost)
         {
             Instantiate(tower.gameObject, position, Quaternion.identity);
             bank.Withdraw(cost);
             return true; 
         }

         return false;

     }
}
