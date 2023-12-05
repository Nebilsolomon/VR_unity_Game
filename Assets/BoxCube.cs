
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxCube : MonoBehaviour
{
    float speedOfBox = 4f;
    static int boxCubeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Increment boxCubeCount when a new instance is created
        boxCubeCount++;

        // Increase speedOfBox for demonstration purposes
        

        // Check if 50 instances have been created, and if so, start the movement
        if (boxCubeCount > 20)
        {
            InvokeRepeating("RandomlyMove", 2f, 2f);
            
            
                speedOfBox =+ 4;
        } 
      

        Debug.Log(boxCubeCount);
    }

    // Function to start randomly moving up or down
    void RandomlyMove()
    {
        // Generate a random adjustment factor between -0.3 and 0.3
        float adjustmentFactor = Random.Range(-0.3f, 0.3f);

        // Apply the adjustment to the position
        transform.position += new Vector3(0f, adjustmentFactor, 0f) * speedOfBox;
    }

    // Update is called once per frame
    void Update()
    {
        // Move forward continuously
        transform.position += Time.deltaTime * transform.forward * speedOfBox;
    }



   
}












































// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BoxCube : MonoBehaviour
// {

//     float speedOfBox = 4f;
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {


//         transform.position += Time.deltaTime * transform.forward * this.speedOfBox;
        


//     }
// }
