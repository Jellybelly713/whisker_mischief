using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace GamePlay
{
    public class Throwable : MonoBehaviour
    {
        [SerializeField] private UnityEvent onCollideWith = new UnityEvent();
        [SerializeField] private LayerMask collisionLayerMask = ~0;
        [SerializeField] private bool destroyOnCollide = false;

        [SerializeField] private AudioSource source = null;
        [SerializeField] private float soundRange = 15f;
        [SerializeField] private Sound.SoundType soundType = Sound.SoundType.Interesting;

        private void OnCollisionEnter(Collision collision)
        {
            if (collisionLayerMask == (collisionLayerMask | (1 << collision.gameObject.layer)))
            {
                if (source.isPlaying) //If already playing a sound, don't allow overlapping sounds 
                    return;
                source.Play();

                var sound = new Sound(transform.position, soundRange, soundType);

                Sounds.MakeSound(sound);
            }
        }

        public void MakeAnInterestingSound(float range)
        {
            var sound = new Sound(transform.position, range, Sound.SoundType.Interesting);
            Sounds.MakeSound(sound);
        }
    }
}

