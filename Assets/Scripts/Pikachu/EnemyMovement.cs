using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] GameObject m_Target;
    [SerializeField] float m_Speed;
    // Start is called before the first frame update
    void Awake()
    {
        m_Target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        var step = m_Speed * Time.deltaTime;

        // Move towards the player
        transform.position = Vector3.MoveTowards(transform.position, m_Target.transform.position, step);

        // Rotate to face the player
        transform.LookAt(m_Target.transform.position);
    }
}
