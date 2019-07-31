using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveSwitch : MonoBehaviour
{

    public GameObject firstObj;
    public GameObject thirdObj;
    public GameObject thirdCam;

    public bool firstView = true;
    public bool thirdView = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swticher();
    }

    public void Swticher()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {

            firstView = !firstView;
            thirdView = !thirdView;

        }
        if (firstView == true)
        {

            firstObj.SetActive(true);
            thirdObj.SetActive(false);
            thirdCam.SetActive(false);
            Debug.Log("First Person is Active");

        }
        if(thirdView == true)
        {

            firstObj.SetActive(false);
            thirdObj.SetActive(true);
            thirdCam.SetActive(true);
            Debug.Log("Third Person is Active");

        }

    }
}
