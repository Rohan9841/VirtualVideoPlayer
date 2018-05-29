using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ARBcardScript : MonoBehaviour, IVirtualButtonEventHandler {

    public GameObject developerGo, trainerGo, travelerGo;

	// Use this for initialization
	void Start () {

        //setting all the gameobjects inactive
        developerGo.SetActive(false);
        trainerGo.SetActive(false);
        travelerGo.SetActive(false);

        //Getting all the scripts of virtual buttons and storing in vbb array
        VirtualButtonBehaviour[] vbb = GetComponentsInChildren<VirtualButtonBehaviour>();

        for(int i = 0; i< vbb.Length; i++)
        {
            //registering all the buttons
            vbb[i].RegisterEventHandler(this);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        if (vb.VirtualButtonName == "DeveloperVB")
        {
            developerGo.SetActive(true);
            trainerGo.SetActive(false);
            travelerGo.SetActive(false);
        }

        else if (vb.VirtualButtonName == "TrainerVB")
        {
            developerGo.SetActive(false);
            trainerGo.SetActive(true);
            travelerGo.SetActive(false);
        }

        else if (vb.VirtualButtonName == "TravelerVB")
        {
            developerGo.SetActive(false);
            trainerGo.SetActive(false);
            travelerGo.SetActive(true);
        }

        //if the virtual button pressed do not have a name 
        else
        {
            throw new UnityException(vb.VirtualButtonName + "Virtual Button Not Supported");
        }

    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Virtual button released");
    }
}
