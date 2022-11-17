using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

// Hold CTRL , Press K , Press D
public class PlayerCamera : MonoBehaviour
{
    Volume volume;
    Vignette vignette;
    ChromaticAberration chromaticAberration;
    LensDistortion lensDistortion;
    Player player;
    [SerializeField] Transform target;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        volume = GetComponent<Volume>();
        volume.profile.TryGet(out vignette);
        volume.profile.TryGet(out chromaticAberration);
        volume.profile.TryGet(out lensDistortion);
        
    }
    private void Update()
    {
        vignette.intensity.Override(1 - player.GetHPRatio());
        chromaticAberration.intensity.Override(1 - player.GetHPRatio());
        if(player.playerHP < 3)
        {
            beat();
        }
        //Make camera follow the player
        if (target == null)
        {
            return;
        }

        transform.position = new Vector3(target.position.x, target.position.y, -10);
        
    }
    public void beat()
    {
        StartCoroutine(theworldoCoroutine());
    }
    public IEnumerator theworldoCoroutine()
    {
        while (true)
        {
            //up
            if (player.playerHP <= player.playerMaxHP / 2)
            {
                lensDistortion.intensity.Override(0.1f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.2f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.3f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.4f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.5f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.4f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.3f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.2f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0.1f);
                yield return new WaitForSeconds(0.01f);
                lensDistortion.intensity.Override(0f);
                yield return new WaitForSeconds(1f);
                
            }
        }
    }
}
