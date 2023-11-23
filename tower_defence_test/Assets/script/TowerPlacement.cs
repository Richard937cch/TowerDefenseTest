using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class TowerPlacement : MonoBehaviour
{

    [SerializeField] private Camera PlayerCamera;

    private GameObject CurrentPlacingTower;

    public GameObject PlacedTower;

    Vector3 inpp;

    public Material TG;
    public Material TR;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (CurrentPlacingTower != null)
        {
            Ray camray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(camray.origin, camray.direction * 10, Color.yellow);
            if (Physics.Raycast(camray, out RaycastHit hitInfo, 100f))
            {
                //Vector3 inp = hitInfo.point;
                //inpp = new Vector3(Convert.ToInt32(hitInfo.point[0]),Convert.ToInt32(hitInfo.point[1]),Convert.ToInt32(hitInfo.point[2]));
                inpp = new Vector3(Convert.ToInt32(hitInfo.point[0]),hitInfo.point[1]+0.0001f,Convert.ToInt32(hitInfo.point[2]));

                CurrentPlacingTower.transform.position = inpp;
                /*
                if (Physics.Raycast(camray, out hitInfo, 100.0f, LayerMask.GetMask("Map")))
                {
                    CurrentPlacingTower.GetComponent<MeshRenderer> ().material = TG;
                    Debug.Log("g");
                }
                if (Physics.Raycast(camray, out hitInfo, 100.0f, LayerMask.GetMask("path")))
                {
                    Destroy(CurrentPlacingTower.GetComponent<MeshRenderer> ().material);
                    CurrentPlacingTower.GetComponent<MeshRenderer> ().material = TR;
                    Debug.Log("r");
                }
                */
            }

            if (Input.GetMouseButtonDown(0) && !Physics.Raycast(CurrentPlacingTower.transform.position, CurrentPlacingTower.transform.up*-1.0f , out RaycastHit hit, 3f, LayerMask.GetMask("path")) && !Physics.Raycast(CurrentPlacingTower.transform.position, CurrentPlacingTower.transform.up , out RaycastHit hit2, 3f, LayerMask.GetMask("Ignore Raycast")) && !(EventSystem.current.IsPointerOverGameObject()))
            {
                //Destroy(CurrentPlacingTower);
                //CurrentPlacingTower = null;
                Vector3 inppp = inpp;
                inppp[1] = -0.5f;
                Instantiate(PlacedTower, inppp, Quaternion.identity);
            }
        }
        /*
        if (EventSystem. current. IsPointerOverGameObject())
        {
            Debug. Log("Its over UI elements");
        }
        */
        
    }

    public void SetTower(GameObject tower)
    {
        CurrentPlacingTower = Instantiate(tower, Vector3.zero, Quaternion.identity);
    }
    public void unablePlaceTower(bool isOn)
    {
        if (isOn)
        {

        }
        else
        {
            Debug.Log("disable");
            Destroy(CurrentPlacingTower);
            Destroy(GameObject.Find("turretPos(Clone)"));
            CurrentPlacingTower = null;
        }
        
    }

}
