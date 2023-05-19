using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    public Transform target;
    public float force;
    public Slider ForceUI;

    [Header("kaleci")]
    Goalkeepert goal;
    public GameObject Goalkeeper;
    Vector3 StartPos;
    Vector3 GoalPos;

    [Header("Topa Vuruþ Gücü")]
    public float topavurusgücü;
    private void Start()
    {
        StartPos = transform.position;
        GoalPos = Goalkeeper.transform.position;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            force++;
            slider();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if(force <= topavurusgücü)
            {
                shoot();
            }
            else
            {
                force = topavurusgücü;
                shoot();
            }
    
            StartCoroutine(Wait());
        }
    }
    void shoot()
    {
        Vector3 Shoot = (target.position - this.transform.position).normalized;
        //test sonrasý kullanýlacak ilk kýsým
        //GetComponent<Rigidbody>().AddForce(Shoot * force, ForceMode.Impulse);
        //aþaðýdaki kod daha iyi vuruþ için
        GetComponent<Rigidbody>().angularDrag = 1;
        GetComponent<Rigidbody>().AddForce(Shoot * force + new Vector3(0, 3f, 0), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        
    }

    public void slider()
    {
        ForceUI.value = force;
    }

    public void ResetGauge()
    {
        force = 0;
        ForceUI.value = 0;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.5f);
        shoot();
        yield return new WaitForSeconds(0.05f);
        FindObjectOfType<Goalkeepert>().GolMove();
        yield return new WaitForSeconds(1.5f);
        ResetGauge();

        GetComponent<Rigidbody>().angularDrag = 40;
        yield return new WaitForSeconds(3f);

        transform.position = StartPos;
        Goalkeeper.transform.position = GoalPos;

        FindObjectOfType<Goalkeepert>().Reset();
        FindObjectOfType<Goalkeepert>().Move = 0;
    
    
    
    
    }


}
