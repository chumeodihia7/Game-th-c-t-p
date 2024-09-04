using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies2 : MonoBehaviour
{
    // Start is called before the first frame update
     public GameObject PlantBullet;
    public Transform TransfromBullet;
    [SerializeField] protected int moveSpeed ;
    Animator animator ; 
    
 
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bullett()
    {
        GameObject PlantBu = Instantiate(PlantBullet,TransfromBullet.position,TransfromBullet.rotation);
        Bullet rb = PlantBu.GetComponent<Bullet>(); 
        if (rb != null)
        {
            rb.speed = moveSpeed;
            rb.direction = Vector3.left;
        }
        Destroy( PlantBu,1.5f );
       
    }
   
}
