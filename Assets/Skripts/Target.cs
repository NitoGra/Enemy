using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Material _baseMaterial; 
    [SerializeField] private Material _popMaterial; 
	[SerializeField] private float _popTime;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Enemy")
			return;

		GetComponent<AudioSource>().Play();
		GetComponent<MeshRenderer>().material = _popMaterial;
		Destroy(collision.gameObject);

		Invoke(nameof(ReturnToBase), _popTime);
	}

    private void ReturnToBase()
    {
        gameObject.GetComponent<MeshRenderer>().material = _baseMaterial;
    }
}