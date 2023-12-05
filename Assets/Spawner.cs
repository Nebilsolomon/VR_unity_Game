

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] cubes;

    public Transform[] points;
    public float beats = (120 / 130 ) * 2;

    private float timer;

    // Start is called before the first frame update
   
    void Start()
    {




    // Add this line to ensure there's a Rigidbody component
   
    Rigidbody rb = gameObject.AddComponent<Rigidbody>();
   
    rb.isKinematic = true; // Set it to kinematic if you don't want physics interactions


        // Initialize the timer
       
        timer = 0f;
    }

    // Update is called once per frame
    
    void Update()
    {
        // Uncomment the timer logic if you want to spawn cubes at intervals
       
         timer += Time.deltaTime * 10;

        // Check if the timer has exceeded the beats interval
       
         if (timer > beats)
       
         {
        //     // Reset the timer
          
             timer = 0f;

     
        // Instantiate the cube at the chosen position
       
       GameObject cube =  Instantiate(cubes[Random.Range(0, 2)], points[Random.Range(0,4)]);
       
        cube.transform.localPosition = Vector3.zero; 
        //cube.transform.Rotate(transform.forward, 90 * Random.Range(0,4));
       
           cube.tag = "CubeTag";


        timer -= beats; 
         }

         timer += Time.deltaTime; 
    }



}
