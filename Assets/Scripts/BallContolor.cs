using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManager;
using UnityEngine.UI;

public class BallContolor : MonoBehaviour
{
    public float speed=150f;
    public Rigidbody rb;
    private Vector2 lastMousePosition;

    public GameObject Endgame;
    public GameObject win;
    private float wallDistance = 4.5f;
    public float minCameraDistance = 3f;
    private int lavel=0;
    // Start is called before the first frame update
    void Start()
    {
        Endgame.SetActive(false);
        win.SetActive(false);
       // rb.AddForce(force);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 deltaposition = Vector2.zero;
        if(Input.GetMouseButton(0)){
            Vector2 currentMousePosition = Input.mousePosition;
            if(lastMousePosition == Vector2.zero){
                lastMousePosition = currentMousePosition;
            }
            deltaposition= currentMousePosition -lastMousePosition;
            lastMousePosition = currentMousePosition;
            Vector3 force = new Vector3(deltaposition.x,0, deltaposition.y)*speed ;
            rb.AddForce(force);
            }
            else {
                lastMousePosition = Vector2.zero;
            }
        }

    private void FixedUpdate() {
        Vector3 pos = transform.position;
        if(transform.position.x <-wallDistance){
            pos.x = - wallDistance;

        }
        else if(transform.position.x > wallDistance){ pos.x = wallDistance;
        }

        if(transform.position.z < Camera.main.transform.position.z+minCameraDistance)
        {
            pos.z =Camera.main.transform.position.z+minCameraDistance;
        } transform.position =pos;

    }
    
    private int count=0;
    private void OnCollisionEnter(Collision collision) {
        
        if(collision.gameObject.tag == "Enemy")
        {
            count++;
            Debug.Log(count);
            if(count>=5)
            {
                
                Endgame.SetActive (true);
                //Destroy(this);
            }
        }
        if(collision.gameObject.tag == "win"){
            win.SetActive (true);
        }
    } 
    public void RestartGame(int level){
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }  

    public void NextLevel(int level){
        level=level+ 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }   
}

