using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.MixedReality.Toolkit.Utilities;

namespace HoloToolkit.Unity.InputModule.Tests
{
   

    public class sizeHandler : MonoBehaviour, IMixedRealitySpeechHandler
    {

        private Material cachedMaterial;
        private GameObject vein, aneurysm, real_vein;
        private Vector3 scaleChange, positionChange;


        private void Awake()
        {
            
            //vein = GameObject.Find("grp1");
            vein = GameObject.Find("vein_set");
            real_vein = GameObject.Find("big_vein");
            cachedMaterial = real_vein.GetComponent<Renderer>().material;
            //aneurysm = GameObject.Find("");
            scaleChange = new Vector3(0.3f, 0.3f, 0.3f);
            //positionChange = new Vector3(108.7f, -37.2f, -180.14f);


        }

        public void Change(string color)
        {
            switch (color.ToLower())
            {

                case "red":
                    cachedMaterial.SetColor("_Color", Color.red);
                    break;

                case "bigger":
                    Boolean changeBig = true;
                    updateSize(changeBig);
                    Debug.Log($"Enlarge successfully");

                    break;

                case "smaller":
                    Boolean changeSmall = false;
                    updateSize(changeSmall);
                    Debug.Log($"smaller successfully");
                    break;



                default:

                    Debug.Log($"voice command caught " + color);

                    break;

            }
        }

        public void updateSize(Boolean bigOrSmall)
        {
            if (bigOrSmall == true)
            {

                //vein.transform.localScale += scaleChange;

                vein.transform.localScale += scaleChange;
            }
            else
            {
                //vein.transform.localScale -= scaleChange;

                vein.transform.localScale -= scaleChange;
            }
        }
            //public void closer()
           // {
            //    vein.transform.localPosition = positionChange;
          //  }
        public void OnSpeechKeywordRecognized(SpeechEventData eventData)

        {


            Change(eventData.Command.Keyword.ToLower());


        }

        // Start is called before the first frame update

    }
}
