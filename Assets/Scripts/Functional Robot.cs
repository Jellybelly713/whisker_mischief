using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamePlay;
using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine.Playables;

public class FunctionalRobot : MonoBehaviour, IHear
{
    [SerializeField] private NavMeshAgent agent = null;

    //void Awake()
    //{
    //    if (!TryGetComponent(out agent))
    //    {
    //        Debug.LogWarning(name + "doesnt have an agent");
    //    }
    //}


    public void RespondToSound(Sound sound)
    {
        if (sound.soundType == Sound.SoundType.Interesting)
            MoveTo(sound.pos);

    }

    private void MoveTo(Vector3 pos)
    {
        agent.SetDestination(pos);
        agent.isStopped = false;
    }
}
