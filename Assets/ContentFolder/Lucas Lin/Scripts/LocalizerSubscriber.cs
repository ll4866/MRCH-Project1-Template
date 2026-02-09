using Immersal;
using Immersal.XR;
using UnityEngine;

public class LocalizerSubscriber : MonoBehaviour
{
    [SerializeField]
    private Localizer localizer;
    [SerializeField]
    private bool hideThisBeforeLocalization = true;

    private void Start()
    {
        if (!hideThisBeforeLocalization) return;
        
        if (!localizer)
        {
            localizer = GameObject.Find("Localizer").GetComponent<Localizer>();
            if(!localizer)
            {
                Debug.LogError("Localizer component not found in the scene.");
                return;
            }
        }
        localizer.OnFirstSuccessfulLocalization.AddListener(OnFirstSuccessfulLocalization);
        gameObject.SetActive(false);
    }

    private void OnFirstSuccessfulLocalization()
    {
        gameObject.SetActive(true);
    }
    
    private void OnDestroy()
    {
        if (localizer && hideThisBeforeLocalization)
        {
            localizer.OnFirstSuccessfulLocalization.RemoveListener(OnFirstSuccessfulLocalization);
        }
    }
}
