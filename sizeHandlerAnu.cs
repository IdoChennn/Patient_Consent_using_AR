using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.MixedReality.Toolkit.Utilities;

namespace HoloToolkit.Unity.InputModule.Tests
{


    public class sizeHandlerAnu : MonoBehaviour, IMixedRealitySpeechHandler
    {

        private Material cachedMaterial_vein, cachedMaterial_aneurysm;
        private GameObject vein_container, aneurysm_container, real_vein, real_aneurysm, head, brainVein;
        private Vector3 scaleChange;
        private Boolean changeSizeV;
        private Boolean changeSizeA;

        private void Awake()
        {

            vein_container = GameObject.Find("vein_set");
            aneurysm_container = GameObject.Find("aneurysm_set");
            real_vein = GameObject.Find("vein");
            real_aneurysm = GameObject.Find("aneurysm");
            head = GameObject.Find("headcontainer");
 
            cachedMaterial_vein = real_vein.GetComponent<Renderer>().material;
            cachedMaterial_aneurysm = real_aneurysm.GetComponent<Renderer>().material;
            scaleChange = new Vector3(0.1f, 0.1f, 0.1f);


        }

        public void Change(string commmands)
        {
            switch (commmands.ToLower())
            {

                

                case "bigger_vein":
                    changeSizeV = true;
                    updateSizeVein(changeSizeV);
                    Debug.Log($"Enlarge successfully");

                    break;

                case "smaller_vein":
                    changeSizeV = false;
                    updateSizeVein(changeSizeV);
                    Debug.Log($"smaller successfully");
                    break;

                case "bigger_aneurysm":
                    changeSizeA = true;
                    updateSizeAneurysm(changeSizeA);
                    Debug.Log($"Enlarge successfully");
                    break;

                case "smaller_aneurysm":
                    changeSizeA = false;
                    updateSizeAneurysm(changeSizeA);
                    Debug.Log($"Enlarge successfully");
                    break;

                case "big_head":
                    changeSizeA = true;
                    updateSizehead(changeSizeA);
                    break;

                case "small_head":
                    changeSizeA = false;
                    updateSizehead(changeSizeA);
                    break;

                case "attach":
                    attach();
                    Debug.Log($"attach successfully");
                    break;

                case "detach":
                    detach();
                    Debug.Log($"detach successfully");
                    break;

                case "aneurysm_red":
                    cachedMaterial_aneurysm.SetColor("_Color", Color.red);
                    break;

                case "vein_red":
                    cachedMaterial_vein.SetColor("_Color", Color.red);
                    break;

                case "vein_blue":
                    cachedMaterial_vein.SetColor("_Color", Color.blue);
                    break;
                case "vein_green":
                    cachedMaterial_vein.SetColor("_Color", Color.green);
                    break;
                case "aneurysm_blue":
                    cachedMaterial_aneurysm.SetColor("_Color", Color.blue);
                    break;
                case "aneurysm_green":
                    cachedMaterial_aneurysm.SetColor("_Color", Color.green);
                    break;

                default:

                    Debug.Log($"voice command caught " + commmands);

                    break;

            }
        }

        public void updateSizeVein(Boolean bigOrSmall)
        {
            if (bigOrSmall == true)
            {

                //vein.transform.localScale += scaleChange;

                vein_container.transform.localScale += scaleChange;
                //aneurysm_container.transform.localScale += scaleChange;
            }
            else
            {
                //vein.transform.localScale -= scaleChange;

                vein_container.transform.localScale -= scaleChange;
                //aneurysm_container.transform.localScale -= scaleChange;
            }
        }
        public void updateSizeAneurysm(Boolean bigOrSmall)
        {
            if (bigOrSmall == true)
            {

                //vein.transform.localScale += scaleChange;

                //vein_container.transform.localScale += scaleChange;
                aneurysm_container.transform.localScale += scaleChange;
            }
            else
            {
    
                aneurysm_container.transform.localScale -= scaleChange;
            }
        }

        public void updateSizehead(Boolean bigOrSmall)
        {
            if (bigOrSmall == true)
            {

                //vein.transform.localScale += scaleChange;

                head.transform.localScale += scaleChange;
                //aneurysm_container.transform.localScale += scaleChange;
            }
            else
            {
                //vein.transform.localScale -= scaleChange;

                head.transform.localScale -= scaleChange;
                //aneurysm_container.transform.localScale -= scaleChange;
            }
        }

        public void attach()
        {
            
            aneurysm_container.transform.parent = vein_container.transform;
            //aneurysm.transform.position = positionChange;

        }
        public void detach()
        {

            aneurysm_container.transform.SetParent(null);
            

        }

        public void OnSpeechKeywordRecognized(SpeechEventData eventData)

        {


            Change(eventData.Command.Keyword.ToLower());


        }

        // Start is called before the first frame update

    }
}
