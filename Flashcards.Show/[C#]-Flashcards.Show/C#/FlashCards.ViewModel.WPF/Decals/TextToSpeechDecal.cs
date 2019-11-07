using System;
using System.Windows.Input;
using System.Xml.Serialization;
#if !SILVERLIGHT
using System.Speech.Synthesis;
using FlashCards.Commands;
using System.Reflection;
#endif

namespace FlashCards.ViewModel
{
    public class TextToSpeechDecal : Decal
    {
#if !SILVERLIGHT
        private SpeechSynthesizer synthesizer;
        private bool _isSpeaking;
#endif

        public TextToSpeechDecal()
        {
            MetaData = new AudioMetaData();
            CanResize = false;
            Stretch = System.Windows.Media.Stretch.None;
            Center = new System.Windows.Point(0.5,1);
            PinPoint = new System.Windows.Point(0.5,1);
            CanMove = false;

#if !SILVERLIGHT
            Play = new DelegateCommand(() =>
            {
                if (!string.IsNullOrEmpty(MetaData.Source) && !_isSpeaking)
                {
                    synthesizer = new SpeechSynthesizer();
                    synthesizer.Rate = -1;

                    synthesizer.SpeakAsync(MetaData.Source);
                    _isSpeaking = true;
                    // always dispose resources!
                    synthesizer.SpeakCompleted += new EventHandler<System.Speech.Synthesis.SpeakCompletedEventArgs>(task_SpeakCompleted);
                }
            }, () =>
            {
                return !string.IsNullOrEmpty(MetaData.Source);
            });
#endif
        }

 #if !SILVERLIGHT
        void task_SpeakCompleted(object sender, System.Speech.Synthesis.SpeakCompletedEventArgs e)
        {
            _isSpeaking = false;
            ((SpeechSynthesizer)sender).Dispose();
        }

        protected override void  OnUnSelected()
        {
            _isSpeaking = false;

 	        if (synthesizer == null) return;

            try
            {
                if (synthesizer.State == SynthesizerState.Speaking)
                    synthesizer.Pause();

                synthesizer.Dispose();
            }
            catch (Exception e)
            {
                Utils.LogException(MethodBase.GetCurrentMethod(), e);
            }
        }
#endif

        [XmlIgnore]
        public ICommand Play { get; private set; }
    }
}
