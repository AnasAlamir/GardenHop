using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class attack : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collect)
    {
        if (collect.gameObject.CompareTag("traps"))
        {
            
            Destroy(collect.gameObject);
           
        }
    }
}