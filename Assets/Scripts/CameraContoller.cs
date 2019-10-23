using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Player;
    private Vector3 offset;

    public bool LookAtPlayer = false;

    [Range(0.01f,1f)]
    public float Smootfactor = 0.5f;

    void Start()
    {
        offset = transform.position - Player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Player.position + offset;
        transform.position = Vector3.Slerp(transform.position, newPos,Smootfactor * Time.deltaTime);
        if(LookAtPlayer)
        {
            transform.LookAt(Player);
        }
    }
}
