
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform player2 ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player2.position.x , player2.position.y ,transform.position.z) ;
    }
}
