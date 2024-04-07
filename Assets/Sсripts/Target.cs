using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Material _baseMaterial; 
    [SerializeField] private Material _popMaterial; 
	[SerializeField] private float _popTime;

	private AudioSource _audio;
	private MeshRenderer _mesh;

	private void Start()
	{
		_audio = GetComponent<AudioSource>();
		_mesh = GetComponent<MeshRenderer>();
	}

	private void OnCollisionEnter(Collision collision)
	{ 
		if (collision.gameObject.TryGetComponent<MovementToDerection>(out MovementToDerection movementToDerection))
		{
			_audio.Play();
			_mesh.material = _popMaterial;
			Destroy(collision.gameObject);
			Invoke(nameof(ReturnToBase), _popTime);
		}
	}

    private void ReturnToBase()
    {
		_mesh.material = _baseMaterial;
    }
}