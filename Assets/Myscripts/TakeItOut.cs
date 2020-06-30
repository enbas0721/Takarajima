using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TakeItOut : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObj;

    [SerializeField]
    private float changeDis;

    [SerializeField]
    private GameObject changedObj;

    [SerializeField]
    private TextMeshProUGUI distanceUI;

    private float colliderOffset;

    // Start is called before the first frame update
    private void Start()
    {
        colliderOffset = GetComponent<CapsuleCollider>().radius + targetObj.GetComponent<CapsuleCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(transform.position, targetObj.transform.position) - colliderOffset;

        if(distanceUI != null)
        {
            distanceUI.text = distance.ToString("0.00m");
        }
        else
        {
            Debug.Log(distance.ToString("0.00m"));
        }

        if(distance > changeDis)
        {
            targetObj.SetActive(false);
            changedObj.SetActive(true);
        }
    }
}
