using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smoothTime;
    public Vector2 refVeloccity;
    public Vector2 minPosi, maxPosi;
    private void Start()
    {
        
        minPosi = new Vector2(-4f, 9.3f);
        maxPosi = new Vector2(30f, 22f);
    }
    private void FixedUpdate()
    {
        float POSx = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref refVeloccity.x, smoothTime);
        float POSy = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.y, ref refVeloccity.y, smoothTime);
         this.transform.position = new Vector3(POSx, POSy, transform.position.z);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPosi.x, maxPosi.x), Mathf.Clamp(transform.position.y, minPosi.y, maxPosi.y), transform.position.z);
    }
}
