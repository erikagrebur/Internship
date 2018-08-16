
namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;

  
    public class AugmentedImageVisualizer : MonoBehaviour
    {
        /// The AugmentedImage to visualize.
        public AugmentedImage Image;
        // Cat model which will be shown
        public GameObject Cat;

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {
                Cat.SetActive(false);
                return;
            }
            GameObject objectToFollow = GameObject.FindWithTag("MainCamera");
            var lookPos = objectToFollow.transform.position - Cat.transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            Cat.transform.rotation = Quaternion.Slerp(Cat.transform.rotation, rotation, Time.deltaTime * 5F);

            float halfWidth = Image.ExtentX / 2;
            float halfHeight = Image.ExtentZ / 2;
            Cat.transform.localPosition = (halfWidth * Vector3.up) + (halfHeight * Vector3.down);

            Cat.SetActive(true);
        }
    }
}
