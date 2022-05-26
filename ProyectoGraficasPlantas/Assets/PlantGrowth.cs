using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{

    private int currentProgression = 0;
    public int timeBetweenGrowths;
    public ParticleSystem wateringParticles; 
    public int maxGrowth;
    private float MustWaterTimer;
    private float MustWaterDefault; 
    

    // Start is called before the first frame update
    void Start()
    {
        MustWaterTimer = MustWaterDefault;
        InvokeRepeating("Growth", timeBetweenGrowths, timeBetweenGrowths);
    }

    // Update is called once per frame
    void Update()
    {
        MustWaterTimer -= Time.deltaTime; 
        if (MustWaterTimer < 0)
        {
            PlantDie();
            //our plant it's going to die

        }
        
    }

    public void Growth() {

        if (currentProgression != maxGrowth)
        {
            gameObject.transform.GetChild(currentProgression).gameObject.SetActive(true);
        }
        if(currentProgression > 0 && currentProgression < maxGrowth){
            gameObject.transform.GetChild(currentProgression - 1).gameObject.SetActive(false);
        }
        if(currentProgression < maxGrowth){
            currentProgression++;
        }
    }
    public void PlantDie(){
        for(int i = 0; i< transform.childCount; i++){


            gameObject.transform.GetChild(i).gameObject.SetActive(false);


        }



        gameObject.transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);


    }
    public void OnTriggerStay(Collider other){

        if (other.CompareTag("Cloud"))
        {

            // cambiar a nuestro slider en este punto
            if (Input.GetKeyboard(KeyCode.P))
            {
                wateringParticles.Play();
                MustWaterTimer = MustWaterDefault;  
            }
        }
    }
}
