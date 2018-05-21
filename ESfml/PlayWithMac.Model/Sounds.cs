using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;

namespace PlayWithMac.Model
{
    public class Sounds
    {
        bool on = true;
        public enum MacSounds
        {
            Jump,
            Kick
        }
        Dictionary<MacSounds, Sound> sound;

        public Sounds()
        {
            string path = @".\Ressources\Sounds/";

            sound = new Dictionary<MacSounds, Sound>();

            sound.Add(MacSounds.Jump, new Sound(new SoundBuffer(path + "jump.wav")));
            sound.Add(MacSounds.Kick, new Sound(new SoundBuffer(path + "kick.wav")));
        }
        public void GetActionSound()
        {
            if (on == true)
                sound[MacSounds.Jump].Play();
            else { }
        }
        public void CheckCollisionSound()
        {
            if (on == true)
            {
                if (sound[MacSounds.Kick].Status != SoundStatus.Playing)
                {
                    sound[MacSounds.Kick].Play();
                }
            }
            else { }
        }
    }
}
