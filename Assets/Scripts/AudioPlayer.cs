using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArgonAssault
{
    public class AudioPlayer : MonoBehaviour
    {
        private void Awake()
        {
            int numAudioPlayers = FindObjectsOfType<AudioPlayer>().Length;

            if (numAudioPlayers > 1)
                Destroy(gameObject);
            else
                DontDestroyOnLoad(gameObject);
        }
    }
}
