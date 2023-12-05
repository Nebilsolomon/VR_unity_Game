using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Saber : MonoBehaviour
{

    public AudioSource source; 
    //public AudioClip clip;
    private int destroyedObjectCount = 0;
    private int higherScore = 0;
   
    public float sensitivity = 2.0f;
    public TextMeshProUGUI  scoreUI;
    public TextMeshProUGUI  hightScoreUI;


   private void Start() {
    
     if (!PlayerPrefs.HasKey("score"))
        {
            PlayerPrefs.SetFloat("score",0);
           loadScore();
        }
        else {
            loadScore();
        }
  



   }



    void Update()
    {
   
   if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the method to load the next level
            LoadNextLevel();
        }
   

        this.controllerSaberWithMouse();
    }


    void controllerSaberWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Adjust the hand anchor position based on mouse movement
        Vector3 newPosition = transform.position + new Vector3(mouseX * sensitivity, mouseY * sensitivity, 0f);
        transform.position = newPosition;
    }




private void OnTriggerEnter(Collider other)
{
    if (other.gameObject.tag == "CubeTag")
    {           
                //source.Play();
               StartCoroutine(PlayAndPauseSound());


                destroyedObjectCount++;

               if(destroyedObjectCount > higherScore) {
                higherScore = destroyedObjectCount;

                saveHigherScore();
                loadScore();


               }

              // source.Pause();
               
                scoreUI.text = destroyedObjectCount.ToString();
               //  hightScoreUI.text = higherScore.ToString();
                

            Debug.Log("Destroyed objects: " + destroyedObjectCount);
             Destroy(other.gameObject);


             if (destroyedObjectCount > 50)
             {
                LoadNextLevel();
                
             }
     
    }
}


IEnumerator PlayAndPauseSound()
{
   // source.PlayOneShot(clip);
     source.Play();
    yield return new WaitForSeconds(0.5f); // Adjust the duration as needed
    source.Pause();
}




    private void saveHigherScore() {

    PlayerPrefs.SetInt("score", higherScore);


    }


        private void loadScore() {


      higherScore = PlayerPrefs.GetInt("score", 0); 
      hightScoreUI.text = higherScore.ToString();



     

    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if there's another scene in the build
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels in build!");
        }
    }


}








