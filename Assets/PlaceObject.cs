using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;


public class PlaceObject : MonoBehaviour
{

    public GameObject ObjectToPlace;
    private MLInput.Controller controller;
    bool flag = true;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        controller = MLInput.GetController(MLInput.Hand.Left);

    }

    void OnButtonDown(byte controler_id, MLInput.Controller.Button button)
    {

        if(button == MLInput.Controller.Button.Bumper)
        {
            if (flag == true)
            {
                ObjectToPlace.SetActive(false);
                flag = false;
            }
            else
            {
                ObjectToPlace.SetActive(true);
                flag = true;

            }

            /*            RaycastHit hit;

                        if (Physics.Raycast(controller.Position, transform.forward, out hit))
                        {
                            //GameObject placeObject = Instantiate(ObjectToPlace, hit.point, Quaternion.Euler(hit.normal));
                            ObjectToPlace.SetActive(false);
                            if(flag == true)
                            {
                                ObjectToPlace.SetActive(false);
                                flag = false;
                            }
                            else
                            {
                                ObjectToPlace.SetActive(true);
                                flag = true;

                            }
                        }*/
        }
    
    }

    private void OnDestroy()
    {
        MLInput.Stop();
        MLInput.OnControllerButtonDown -= OnButtonDown;
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}
