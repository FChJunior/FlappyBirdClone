using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Gerenciador de Audio")]  // Define uma seção de cabeçalho para os componentes de áudio.
    [SerializeField] private AudioSource _bird;  // Referência ao AudioSource para os efeitos sonoros do pássaro.
    [SerializeField] private AudioSource _system;  // Referência ao AudioSource para outros efeitos sonoros do sistema.
    [SerializeField] private AudioClip[] _audios = new AudioClip[5];  // Array de clipes de áudio para diferentes efeitos sonoros.

    public static AudioSource bird, system;  // Referências estáticas aos AudioSource.
    public static AudioClip[] audios;  // Referência estática ao array de clipes de áudio.

    private void Start()
    {
        bird = _bird;  // Inicializa a referência estática do AudioSource do pássaro.
        system = _system;  // Inicializa a referência estática do AudioSource do sistema.
        audios = _audios;  // Inicializa a referência estática ao array de clipes de áudio.
    }

    // Métodos estáticos para reproduzir diferentes efeitos sonoros:

    public static void Wing()
    {
        bird.clip = audios[0];  // Define o clipe de áudio do pássaro como o clipe de asa.
        bird.Play();  // Reproduz o som.
    }

    public static void Swoosh()
    {
        system.clip = audios[1];  // Define o clipe de áudio do sistema como o clipe de "swoosh".
        system.Play();  // Reproduz o som.
    }

    public static void Point()
    {
        system.clip = audios[2];  // Define o clipe de áudio do sistema como o clipe de "point".
        system.Play();  // Reproduz o som.
    }

    public static void Hit()
    {
        bird.clip = audios[3];  // Define o clipe de áudio do pássaro como o clipe de "hit".
        bird.Play();  // Reproduz o som.
    }

    public static void Die()
    {
        system.clip = audios[4];  // Define o clipe de áudio do sistema como o clipe de "die".
        system.Play();  // Reproduz o som.
    }
}
