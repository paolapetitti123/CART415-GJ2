using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public Camera mainCamera;
    public Camera deathCamera;
    public Camera graveCamera;


    // Start is called before the first frame update
    void Start()
    {
       mainCamera.enabled = true;
       deathCamera.enabled = false;
       graveCamera.enabled = false;

        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
       
        yield return new WaitForSeconds(1.5f);
      
        GameObject death = GameObject.FindGameObjectWithTag("death");
        Animator deathAnimator = death.GetComponent<Animator>();

        if (death != null)
        {
            deathAnimator.SetBool("isDead", true);
            Debug.Log("dead animation");
        }

        StartCoroutine(DeathCam());

   
    }
    private IEnumerator DeathCam()
    {
        yield return new WaitForSeconds(1f);

        mainCamera.enabled = false;
        deathCamera.enabled = true;
        graveCamera.enabled = false;

        StartCoroutine(GraveCam());

    }

    private IEnumerator GraveCam()
    {
        yield return new WaitForSeconds(3f);
        GameObject ghost = GameObject.FindGameObjectWithTag("ghost");
        Animator ghostAnimator = ghost.GetComponent<Animator>();

        if (ghost != null)
        {
            ghostAnimator.SetBool("revive", true);
            Debug.Log("dead animation");
        }
        deathCamera.enabled = false;
        graveCamera.enabled = true;


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
