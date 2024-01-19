using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] Transform m_Target;
    [SerializeField] float m_Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var step = m_Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, m_Target.position, step);
    }
}
