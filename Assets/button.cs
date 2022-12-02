using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    private Material cachedMaterial_vein;
    private GameObject vein, vein_container;
    private Vector3 scaleChange;

    // Start is called before the first frame update
    private void Awake()
    {

        vein = GameObject.Find("vein");
        vein_container = GameObject.Find("vein_set");
        cachedMaterial_vein = vein.GetComponent<Renderer>().material;
        scaleChange = new Vector3(0.3f, 0.3f, 0.3f);
    }
    public void changeVein(string color)
    {

        switch (color.ToLower())
        {
            case "red":
                cachedMaterial_vein.SetColor("_Color", Color.red);
                break;
            case "yellow":
                cachedMaterial_vein.SetColor("_Color", Color.yellow);
                break;
            case "green":
                cachedMaterial_vein.SetColor("_Color", Color.green);
                break;
            case "bigger":
                vein_container.transform.localScale += scaleChange;
                break;
            case "smaller":
                vein_container.transform.localScale -= scaleChange;
                break;
            default:
                Debug.Log($"voice command caught " + color);
                break;

        }

    }
}
