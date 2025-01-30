using UnityEngine;

namespace GD.Selection
{
    /// <summary>
    /// Allows us to attach multiple responses to a selected object
    /// </summary>
    public class AdvancedSelectionManager : MonoBehaviour
    {
        [SerializeField]
        private IRayProvider rayProvider;

        [SerializeField]
        private ISelector selector;

        [SerializeField]
        private ISelectionResponse response;

        private Transform currentSelection;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            //get a ray provider
            rayProvider = GetComponent<IRayProvider>();

            //get a selector
            selector = GetComponent<ISelector>();

            //get a reponse
            response = GetComponent<ISelectionResponse>();
        }

        private void Update()
        {
            //set de-selected
            if (currentSelection != null)
                response.OnDeselect(currentSelection);

            //create/get ray
            selector.Check(rayProvider.CreateRay());

            //get current selection (cast ray, do tag/layer comparison)
            currentSelection = selector.GetSelection();

            //set selected
            if (currentSelection != null)
                response.OnSelect(currentSelection);
        }
    }
}