using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnnemyController : MonoBehaviour
{
    public float Speed = 1f;
    private Grille grille;
    private Path m_Path;
    private Tuile m_CurrentTarget;
    [SerializeField]
    private GameObject m_cible;
    private AudioSource m_AudioSource;
    [SerializeField] private List<AudioClip> m_SpawnSounds;

    public Path Path
    {
        set { m_Path = value; }
    }

    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        m_CurrentTarget = m_Path?.GetNextTuile(m_CurrentTarget);

        if (m_Path == null || m_CurrentTarget == null)
        {
            Debug.LogWarning("Ennemy has no possible path.");
            gameObject.SetActive(false);
            return;
        }

        //Teleporte sur le point de départ
        transform.position = m_CurrentTarget.transform.position;

        m_AudioSource.pitch = Random.Range(0.9f, 1.1f);
        m_AudioSource.PlayOneShot(m_SpawnSounds[Random.Range(0, m_SpawnSounds.Count)]);
    }

    void Update()
    {
        //(grille.WorldToGrid(m_cible.transform.position).x,grille.WorldToGrid(m_cible.transform.position).y);
        float t_DistanceAFaire = Speed * Time.deltaTime;
         
        Vector3 t_StartPoint = transform.position;
        Vector3 T_MoveToNextCheckpoint = m_CurrentTarget.transform.position - t_StartPoint;

        while (t_DistanceAFaire * t_DistanceAFaire >= T_MoveToNextCheckpoint.sqrMagnitude && m_CurrentTarget != null)
        {
            t_DistanceAFaire -= T_MoveToNextCheckpoint.magnitude;
            t_StartPoint = m_CurrentTarget.transform.position;
            m_CurrentTarget = m_Path.GetNextTuile(m_CurrentTarget);

            if (m_CurrentTarget == null)
                continue;

            T_MoveToNextCheckpoint = m_CurrentTarget.transform.position - t_StartPoint;
        }

        //Je suis au bout du Path
        if (m_CurrentTarget == null)
        {
            transform.position = t_StartPoint;
            TargetReached();
        }
        else
        {
            transform.position = t_StartPoint + (m_CurrentTarget.transform.position - t_StartPoint).normalized * t_DistanceAFaire;
        }
    }

    private void TargetReached()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        if (m_Path == null || m_Path.Checkpoints.Count < 2)
            return;

        Gizmos.color = Color.cyan;

        for (int i = 0; i < m_Path.Checkpoints.Count - 1; i++)
        {
            Gizmos.DrawLine(m_Path.Checkpoints[i].transform.position, m_Path.Checkpoints[i + 1].transform.position);
        }
    }
}
