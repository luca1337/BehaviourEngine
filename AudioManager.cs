using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Aiv.Vorbis;
using NUnit.Framework;

namespace BehaviourEngine
{
    public enum AudioType
    {
        SOUND_MENU,
        SOUND_BACKGROUND,
        SOUND_EXPLOSION,
        SOUND_WALK_SLOW,
        SOUND_WALK_FAST,
        SOUND_DROP,
        SOUND_DIE,
        SOUND_PICKUP
    }

    public static class AudioManager
    {
        private static Dictionary < AudioType, AudioSource > audioSource;
        private static Dictionary < AudioType, AudioClip > audioClip;

        static AudioManager( )
        {
            Console.WriteLine(AudioDevice.Name);
            audioSource = new Dictionary < AudioType, AudioSource >( );
            audioClip   = new Dictionary < AudioType, AudioClip >( );
        }

        public static AudioSource AddSource( AudioType eTypeToAdd )
        {
            if (!audioSource.ContainsKey(eTypeToAdd))
                 audioSource[eTypeToAdd] = new AudioSource( );
            return audioSource[ eTypeToAdd ];
        }

        public static AudioSource GetSource( AudioType eSourceType )
        {
            return !audioSource.ContainsKey(eSourceType) ? null : audioSource[ eSourceType ];
        }

        public static AudioClip AddClip( string fileName, AudioType eType )
        {
            if(!audioClip.ContainsKey( eType ))
                audioClip[eType] = new AudioClip( fileName );
            return audioClip[ eType ];
        }

        public static AudioClip GetClip( AudioType eType )
        {
            return !audioClip.ContainsKey( eType ) ? null : audioClip[ eType ];
        }

        public static void PlayClip( AudioType eType, bool loop = false )
        {
            try
            {
                if ( !audioSource[ eType ].IsPlaying )
                    GetSource( eType ).Play( GetClip( eType ), loop );
            }
            catch ( Exception )
            {
                throw new KeyNotFoundException( "Probably the specified AudioType does not exist!" );
            }
        }

        public static void PlayStream( AudioType eType, string fileName )
        {
            try
            {
                if ( !GetPlaying( eType ) )
                    GetSource( eType ).Stream( fileName );
            }
            catch ( Exception )
            {
                throw new KeyNotFoundException( "Probably the specified AudioType does not exist!" );
            }
        }

        public static void Stop(AudioType eType )
        {
            try
            {
                if ( GetPlaying( eType ) )
                    GetSource( eType ).Stop( );

            }
            catch ( Exception )
            {
                throw new KeyNotFoundException( "Probably the specified AudioType does not exist!" );
            }
        }

        private static bool GetPlaying( AudioType eType )
        {
            try
            {
                return GetSource( eType ).IsPlaying;
            }
            catch ( Exception )
            {
                throw new KeyNotFoundException("Probably the specified AudioType does not exist!");
            }
        }

        public static void Pause(AudioType eType)
        {
            try
            {
                if ( GetPlaying( eType ) )
                    GetSource( eType ).Pause( );

            }
            catch (Exception)
            {
                throw new KeyNotFoundException("Probably the specified AudioType does not exist!");
            }
        }

        public static void Resume(AudioType eType)
        {
            try
            {
                if (!GetPlaying( eType ))
                    GetSource( eType ).Resume( );

            }
            catch (Exception)
            {
                throw new KeyNotFoundException("Probably the specified AudioType does not exist!");
            }
        }

        public static void SetVolume( AudioType eType, float volume )
        {
            try
            {
                if ( GetPlaying( eType ) )
                    GetSource( eType ).Volume = volume;
            }
            catch ( Exception  )
            {
                throw new KeyNotFoundException("Probably the specified AudioType does not exist!");
            }
        }

        public static void SetSpeed( AudioType eType, float speed )
        {
            try
            {
                if (GetPlaying(eType))
                    GetSource(eType).Speed = speed;
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("Probably the specified AudioType does not exist!");
            }
        }
    }
}
