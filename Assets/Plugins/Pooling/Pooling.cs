using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooling : MonoBehaviour {


    enum INSTANCE_OPTIONS
    {
        RETURN_INSTANCES,
        NO_RETURN
    }


    public GameObject prefab;
    public Transform parent;

    public int instances = 5;


    public bool onDemand;

    public int maxinstances = 10;

    List<GameObject> pool;

	// Use this for initialization
	void Start () {

        pool = new List<GameObject>(  (onDemand? maxinstances : instances)  );

        FillPool();
    }


    private void FillPool()
    {

        for (int i = 0; i < instances; i++)
        {
            GameObject instance;
            CreateInstance(out instance);
            //pool.Add(instance);
        }

    }

    private void CreateInstance(out GameObject instance)
    {
        instance = Instantiate(prefab) as GameObject;

        if (parent != null)
        {
            instance.transform.SetParent(parent);
        }

        instance.GetComponent<Pooled>().pooling = this;
        instance.SetActive(false);

        pool.Add(instance);

    }


    public GameObject Pull()
    {

        GameObject instance = null;

        foreach (GameObject go in pool)
        {
            if (!go.gameObject.activeSelf)
            {
                instance = go;
                break;
            }
        }

        if (instance == null )
        {
            if (onDemand && pool.Count < maxinstances)
            {
                CreateInstance(out instance);
            }
            
        }

        return instance;
    }

	
    public void Return(GameObject go)
    {
        go.SetActive(false);
    }

}
