using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   private Transform _t;
   public float Speed; 
   public GameObject Spawn;
    private Rigidbody rb;

     void Start ()
    {
       _t = this.gameObject.GetComponent<Transform>();
    }


    void FixedUpdate ()
    {
        
        Vector3 dir = Vector3.zero;
        if(Input.GetKey(KeyCode.LeftArrow))
            dir = Vector3.left;
        if(Input.GetKey(KeyCode.UpArrow))
            dir = Vector3.forward;
        if(Input.GetKey(KeyCode.DownArrow))
            dir = Vector3.back;
        if(Input.GetKey(KeyCode.RightArrow))
            dir = Vector3.right;
        _t.position += dir * Time.deltaTime * Speed;
    }
}