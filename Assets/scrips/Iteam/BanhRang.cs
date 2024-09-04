using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BanhRang : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform PosA;
    [SerializeField] private Transform PosB;
    [SerializeField] private int TocDo;
    private Vector2 DiemMucTieu;
    void Start()
    {
        DiemMucTieu=PosA.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, PosA.position) < 0.1)
        {
            DiemMucTieu = PosB.position;
        }
        if (Vector2.Distance(transform.position, PosB.position) < 0.1)
        {
            DiemMucTieu = PosA.position;
        }
        transform.position = Vector2.MoveTowards(transform.position, DiemMucTieu, TocDo * Time.deltaTime);
    }
}

