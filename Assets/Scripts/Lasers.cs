using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lasers : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] lasersCannons;
    public float maxFireDistance = 10f;
    public GameObject bullet;

    public Vector3 projectileOffset;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Fire(Vector3 cursorPos) {

        int layerMask =  ~((1 << 5) | (1 << 6) | (1 << 7) | (1 << 8));

        Ray targetRay = Camera.main.ScreenPointToRay(new Vector3(cursorPos.x, cursorPos.y, 0));
        Vector3 target; 
        //Debug.DrawRay(targetRay,);
        RaycastHit hit;
        if (Physics.Raycast(targetRay, out hit, Mathf.Infinity, layerMask)) {
            target = hit.point;
        } else {
            target = Camera.main.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, maxFireDistance));
        }

        Debug.Log(target);
        
        foreach (GameObject laser in lasersCannons)
        {
            //Debug.DrawLine(laser.transform.position, target, Color.red, 3f);  
            GameObject laserProjectile = Instantiate(bullet, laser.transform.position + projectileOffset, laser.transform.rotation);
            laserProjectile.GetComponent<LaserProjectile>().setDestination(target);

        }
    }
}