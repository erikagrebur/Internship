//-----------------------------------------------------------------------
// <copyright file="AugmentedImageExampleController.cs" company="Google">
//
// Copyright 2018 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleARCore.Examples.AugmentedImage
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using UnityEngine;
    using UnityEngine.UI;
    using GoogleARCore.Examples.AugmentedImage;

    /// <summary>
    /// Controller for AugmentedImage example.
    /// </summary>
    public class AugmentedImageExampleController : MonoBehaviour
    {
        /// <summary>
        /// A prefab for visualizing an AugmentedImage.
        /// </summary>
        public AugmentedImageVisualizer AugmentedImageVisualizerPrefab;

        /// <summary>
        /// The overlay containing the fit to scan user guide.
        /// </summary>
        public GameObject FitToScanOverlay;

        public bool MapOn = false;

        public GameObject HejSpeech;
        public GameObject HejSpeechButton;
        private bool HejSpeechOn = false;

        private string customCatNameWelcome;

        private Dictionary<int, AugmentedImageVisualizer> m_Visualizers
            = new Dictionary<int, AugmentedImageVisualizer>();

        private List<AugmentedImage> m_TempAugmentedImages = new List<AugmentedImage>();

        /// <summary>
        /// The Unity Update method.
        /// </summary>
        public void Update()
        {
            
            // Exit the app when the 'back' button is pressed.
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

            // Check that motion tracking is tracking.
            if (Session.Status != SessionStatus.Tracking)
            {
                return;
            }

            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            // Get updated augmented images for this frame.
            Session.GetTrackables<AugmentedImage>(m_TempAugmentedImages, TrackableQueryFilter.Updated);

            // Create visualizers and anchors for updated augmented images that are tracking and do not previously
            // have a visualizer. Remove visualizers for stopped images.
            foreach (var image in m_TempAugmentedImages)
            {
                AugmentedImageVisualizer visualizer = null;
                m_Visualizers.TryGetValue(image.DatabaseIndex, out visualizer);
                if (image.TrackingState == TrackingState.Tracking && visualizer == null)
                {
                    // Create an anchor to ensure that ARCore keeps tracking this augmented image.
                    Anchor anchor = image.CreateAnchor(image.CenterPose);
                    visualizer = (AugmentedImageVisualizer)Instantiate(AugmentedImageVisualizerPrefab, anchor.transform);
                    visualizer.Image = image;
                    m_Visualizers.Add(image.DatabaseIndex, visualizer);
                }
                else if (image.TrackingState == TrackingState.Stopped && visualizer != null)
                {
                    m_Visualizers.Remove(image.DatabaseIndex);
                    GameObject.Destroy(visualizer.gameObject);
                }
            }

            // Show the fit-to-scan overlay if there are no images that are Tracking.
            foreach (var visualizer in m_Visualizers.Values)
            {
                if (visualizer.Image.TrackingState == TrackingState.Tracking)
                {
                    FitToScanOverlay.SetActive(false);

                    if(!HejSpeechOn)
                    {
                        StartCoroutine(ForwardToAfterS());
                        HejSpeechOn = true;
                    }
                    
                    return;
                }
            }
            
            if(!MapOn)
            {
                FitToScanOverlay.SetActive(true);
            }
        }

        IEnumerator ForwardToAfterS()
        {
            if(PlayerPrefs.GetString("catName") != null)
            {
                customCatNameWelcome = "My name is " + PlayerPrefs.GetString("catName") + ".";
            } else
            {
                customCatNameWelcome = "My name is Misser";
            }
            GameObject.FindGameObjectWithTag("Cnv").transform.Find("Hej_Speech_Cat_Txt").GetComponent<Text>().text = customCatNameWelcome;
            
            yield return new WaitForSeconds(3);
            GameObject.FindGameObjectWithTag("Cnv").transform.Find("Hej_Speech_Txt").gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Cnv").transform.Find("Hej_Speech_Cat_Txt").gameObject.SetActive(true);
            HejSpeech.SetActive(true);
            /*
            yield return new WaitForSeconds(0.81f);
            
            if(PlayerPrefs.GetString("appLang") != null)
            {
                switch (PlayerPrefs.GetString("appLang"))
                {
                    case "German":
                        HejSpeechButton.transform.Find("Text").GetComponent<Text>().text = "Machen wir das";
                        break;
                    case "Danish":
                        HejSpeechButton.transform.Find("Text").GetComponent<Text>().text = "Lad os goere det";
                        break;
                    default:
                        HejSpeechButton.transform.Find("Text").GetComponent<Text>().text = "Let's do it";
                        break;
                }
            }*/

            HejSpeechButton.SetActive(true);
        }
    }
}
