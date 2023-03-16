using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.AI;

public class ChromaticControler : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public PostProcessVolume v;
    private ChromaticAberration ca;
        private Grain gra;
    public float maxDistance = 10f;
    public float maxChromaticAberration = 1f;

    private void Update()
    {
        v.profile.TryGetSettings(out ca);
                v.profile.TryGetSettings(out gra);
        float distance = Vector3.Distance(enemy.position, player.position);
        float chromaticAberrationValue = maxChromaticAberration * (1 - (distance / maxDistance));
        ca.intensity.value = chromaticAberrationValue;
                gra.intensity.value = chromaticAberrationValue;
    }
}
