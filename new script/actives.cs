using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actives : MonoBehaviour
{

    public int m_sec = 2;
    public int m_secEnd = 1;
    public bool moveTo5 = false;
    public bool moveTo1 = false;
    public bool moveTo2 = false;

    public bool moveTo0 = false;

    public UDPReceive udpreceive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(udpreceive.boolist[0]);
        if(udpreceive.boolist[0])
            {
                StartCoroutine(DelayedMovement0());
            }
        else
            {
                moveTo0 = false;
                m_secEnd = 1;
            }
        if(udpreceive.boolist[1])
            {
                StartCoroutine(DelayedMovement1());
            }
        else
            {
                moveTo1 = false;
                m_sec = 2;
            }
        if(udpreceive.boolist[2])
            {
                StartCoroutine(DelayedMovement2());
            }
        else
            {
                moveTo2 = false;
                m_sec = 2;
            }   
        if(udpreceive.boolist[5])
            {
                StartCoroutine(DelayedMovement5());
            }
        else
            {
                moveTo5 = false;
                m_sec = 2;
            }      
    }

    IEnumerator DelayedMovement0()
    {
        yield return new WaitForSeconds(1f);
        m_secEnd--;
        if(m_secEnd<=0)
        {
            moveTo0 = true;
        }
        else{
            moveTo0 = false;
        }
    }
    IEnumerator DelayedMovement1()
    {
        yield return new WaitForSeconds(1f);
        m_sec--;
        if(m_sec<=0)
        {
            moveTo1 = true;
        }
        else{
            moveTo1 = false;
        }
    }
    IEnumerator DelayedMovement2()
    {
        yield return new WaitForSeconds(1f);
        m_sec--;
        if(m_sec<=0)
        {
            moveTo2 = true;
        }
        else{
            moveTo2 = false;
        }
    }
    IEnumerator DelayedMovement5()
    {
        yield return new WaitForSeconds(1f);
        m_sec--;
        if(m_sec<=0)
        {
            moveTo5 = true;
        }
        else{
            moveTo5 = false;
        }
    }

}
