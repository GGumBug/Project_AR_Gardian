using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDone : MonoBehaviour
{
    public UITitle uiTitle;

    public void OnParticleSystemStopped()
    {
        Debug.Log("OnParticleSystemStopped");
        uiTitle.AppearLogo();
    }
}
