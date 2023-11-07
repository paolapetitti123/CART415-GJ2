using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    public Camera mainCamera;
    public Camera deathCamera;
    public Camera graveCamera;
    public Camera houseCamera;

    public GameObject deathCamObj;
    public GameObject graveCamObj;
    public GameObject houseCamObj;

    [SerializeField] public AudioSource headBang;


    // Start is called before the first frame update
    void Start()
    {
       mainCamera.enabled = true;
       deathCamera.enabled = false;
        deathCamObj.SetActive(false);
       graveCamera.enabled = false;
        graveCamObj.SetActive(false);
        houseCamera.enabled = false;
        houseCamObj.SetActive(false);

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
        deathCamObj.SetActive(true);
        deathCamera.enabled = true;
        graveCamera.enabled = false;
        houseCamera.enabled = false;

        
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
        deathCamObj.SetActive(false);
        houseCamera.enabled = false;
        
        graveCamera.enabled = true;
        graveCamObj.SetActive(true);


        StartCoroutine(HouseCam());
    }

    private IEnumerator HouseCam()
    {
        yield return new WaitForSeconds(4f);
        GameObject ghost = GameObject.FindGameObjectWithTag("ghostHouse");
        Animator ghostAnimator = ghost.GetComponent<Animator>();

        if (ghost != null)
        {
            ghostAnimator.SetBool("revive", true);
            ghostAnimator.Play("ghost-house");
            Debug.Log("dead animation");
        }
        deathCamera.enabled = false;
        graveCamera.enabled = false;
        graveCamObj.SetActive(false);
        houseCamera.enabled = true;
        houseCamObj.SetActive(true);


        StartCoroutine(StartTutorial());
    }

    private IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(4f);

        GameStateManager.Instance.LoadScene(GameStateManager.Scene.Tutorial);
    }

}
