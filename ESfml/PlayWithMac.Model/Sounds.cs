using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;
using SFML.Audio;
using PlayWithMac;

namespace PlayWithMac.Model
{

    public class Sounds
    {
        static List<bool> sou;

        public void OnOff(bool on)
        {
            sou = new List<bool>();
            sou.Add(on);
        }

        public enum MacSounds
        {
            Jump,
            Kick,
            background
        }

        Dictionary<MacSounds, Sound> sound;

        public Sounds()
        {
            string path = @".\Sounds/";

            sound = new Dictionary<MacSounds, Sound>();

            sound.Add(MacSounds.Jump, new Sound(new SoundBuffer(path + "jump.wav")));
            sound.Add(MacSounds.Kick, new Sound(new SoundBuffer(path + "kick.wav")));
            sound.Add(MacSounds.background, new Sound(new SoundBuffer(path + "bg2.wav")));

        }
        public void GetActionSound()
        {
            if (sou != null)
            {
                foreach (var item in sou)
                {
                    if (item == true)
                        sound[MacSounds.Jump].Play();
                }
            }
        }
        public void CheckCollisionSound()
        {
            if (sou != null)
            {
                foreach (var item in sou)
                {
                    if (item == true)
                    {
                        if (sound[MacSounds.Kick].Status != SoundStatus.Playing)
                        {
                            sound[MacSounds.Kick].Play();
                        }
                    }
                }
            }
        }
        public void BackGroundMusic()
        {
            if (sou != null)
            {
                foreach (var item in sou)
                {
                    if (item == true)
                    {
                        sound[MacSounds.background].Play();
                    }
                }
            }
        }
    }
}
