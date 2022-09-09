using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //public string nombreObjeto;
    public GameObject objeto;
    public int cantObjeto;
    public bool AlinearConPadre = true;
    private GameObject padre;

    public Queue<GameObject> colaOBjeto;
    private List<GameObject> listaOBJEliminacion;
    [SerializeField] private bool With_startCola;
    public void startCola(int cantidadPool)
    {
        padre = gameObject;
        //print("Nombre padre : "+ padre);
        listaOBJEliminacion = new List<GameObject>();
        cantObjeto = cantidadPool;
        colaOBjeto = new Queue<GameObject>();
        for (int i = 0; i < cantObjeto; i++)
        {
            GameObject newPolvo = Instantiate(objeto);

            newPolvo.GetComponent<retornarObjectPooling>().setObjectPoolingMASTER(this);
            


            if (AlinearConPadre)
                newPolvo.transform.SetParent(padre.transform);
            colaOBjeto.Enqueue(newPolvo);
            newPolvo.SetActive(false);

            listaOBJEliminacion.Add(newPolvo);
        }

    }
    /*
    public void startCola_BALA(float duracion)
    {
        colaOBjeto = new Queue<GameObject>();
        for (int i = 0; i < cantObjeto; i++)
        {
            GameObject newPolvo = Instantiate(objeto);

            //balaMovement _balaMovement = newPolvo.GetComponent<balaMovement>();
            //_balaMovement.setObjectPoolingReference(this);
            //_balaMovement.setDuracion(duracion);

            colaOBjeto.Enqueue(newPolvo);
            newPolvo.SetActive(false);
        }
    }*/
    void Start()
    {
        if(With_startCola) startCola(cantObjeto);
    }

    private GameObject getObjPool()
    {
        GameObject newObj;
        if (cantObjeto > 1)
        {
            cantObjeto--;
            newObj = colaOBjeto.Dequeue();
            newObj.SetActive(true);
            newObj.transform.SetPositionAndRotation(transform.position, Quaternion.identity);

            return newObj;
        }
        return null;
    }

    public void ReturnObjPool(GameObject go)
    {
        if (AlinearConPadre)
            go.transform.SetParent(padre.transform);
        cantObjeto++;
        go.SetActive(false);
        this.colaOBjeto.Enqueue(go);
    }
    //obtener
    public GameObject emitirObj(float tiempo, bool withTime)
    {
        GameObject objA = this.getObjPool();
        objA.transform.SetParent(null);
        //objA.GetComponent<retornarObjectPooling>().setObjectPoolingMASTER(this);
        if (objA != null)
            StartCoroutine(retornarObjPool(tiempo, objA, withTime));
        //print("emitiendo : " + cantObjeto);
        return objA;
    }
    /*
    public void emitirObj_BALA(float tiempo, bool withTime)
    {
        GameObject objA = getObjPool();
        if (objA != null)
            StartCoroutine(retornarObjPool(1, objA, withTime));
    }*/
    IEnumerator retornarObjPool(float tiempo, GameObject miObj, bool withTime)
    {
        yield return new WaitForSecondsRealtime(tiempo);
        if(withTime)
            ReturnObjPool(miObj);
    }


    /*
    public string getNombre()
    {
        return nombreObjeto;
    }*/

    public void DestruirPool()
    {
        /*
        while (colaOBjeto.Count > 0)
        {
            GameObject currentOBJ = colaOBjeto.Dequeue();
            Destroy(currentOBJ);
        }*/
        foreach (GameObject item in listaOBJEliminacion)
        {
            Destroy(item);
        }
    }
}
