using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 dragPercent;
    public float maxFallSpeed;
    public float minFallSpeed;
    public Vector3 recoil;
    public Lasers lasers;
    public int health;
    public int maxHealth;
    public float iframeSeconds;
    [HideInInspector] public bool bossKilled;

    //public Transform lookAtPoint;

    private Rigidbody rb;

    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        GameManager.overlay.UpdatePlayerHealth(health);
    }

    private void FixedUpdate()
    {
        //transform.LookAt(lookAtPoint, Vector3.forward);
        rb.AddForce((movement * movementSpeed));
        rb.velocity = new Vector3(rb.velocity.x * dragPercent.x, Mathf.Clamp(rb.velocity.y, maxFallSpeed, minFallSpeed), rb.velocity.z * dragPercent.z);
    }

    public void Movement(Vector2 inputMovement)
    {
        movement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void Fire()
    {
        rb.AddForce(recoil);
        lasers.Fire(new Vector3(GameManager.fireCursor.transform.position.x,GameManager.fireCursor.transform.position.y,0));//    Random.Range(0,300),Random.Range(0,300),0));
    }

    private bool invincible;

    public void Damage(int damage)
    {
        if(!invincible)
        {
            
            health -= damage;
            if(health <= 0)
            {
                GameManager.endingScreen.EndGame(false);
            }
            else
            {
                GameManager.scoreManager.resetCombo();
                GameManager.overlay.UpdatePlayerHealth(health);
                StartCoroutine(Invincibility(GetComponentsInChildren<SkinnedMeshRenderer>(), iframeSeconds, 0.05f));
            }

            
        }
         
    }

    private IEnumerator Invincibility(SkinnedMeshRenderer[] rendererToFlash, float flashTime, float flashSpeed)
    {
        invincible = true;
        int numOfFlashes = Mathf.RoundToInt(flashTime / flashSpeed);
        for(int i = 0; i < numOfFlashes; i++)
        {
            foreach(SkinnedMeshRenderer renderer in rendererToFlash)
            {
                renderer.enabled = !renderer.enabled;
            }
            yield return new WaitForSeconds(flashSpeed);
        }
        foreach(SkinnedMeshRenderer renderer in rendererToFlash)
        {
            renderer.enabled = true;
        }
        invincible = false;
    }

}
