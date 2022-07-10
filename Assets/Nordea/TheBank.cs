using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro ;

public class TheBank : MonoBehaviour
{
    [SerializeField] private int StartingBalance = 150;
    [SerializeField] private int currentBalance;
    [SerializeField]  TextMeshProUGUI displaybalance;
    public int CurrentBalance { get { return currentBalance; }
    }
    
    private void Awake()
    {
        currentBalance = StartingBalance;
        UpdateDisplay();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        
        if (currentBalance < 0)
        {
            Debug.Log("Game over");
            ReloadScene();
        }
    }

    void UpdateDisplay()
    {
        displaybalance.text = "Gold " + currentBalance;
    }

    void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
    
}
