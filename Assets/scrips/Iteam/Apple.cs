using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Apple : MonoBehaviour
{
    private bool hasCollided = false;// Biến cờ để kiểm tra xem đã va chạm hay chưa
    public Animator Fruit;
    // Start is called before the first frame update
    void Start()
    {
        Fruit = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasCollided && other.gameObject.CompareTag("Player"))
        {
            Fruit.SetTrigger("hit");


            Destroy(this.gameObject, 0.3f);
            ScoreManager.instance.UpdateScore(1);
            hasCollided = true;// Đánh dấu là đã va chạm
        }
    }
    }

