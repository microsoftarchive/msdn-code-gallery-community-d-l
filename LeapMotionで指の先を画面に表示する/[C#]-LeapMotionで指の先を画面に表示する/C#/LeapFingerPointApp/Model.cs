using Codeplex.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace LeapFingerPointApp
{
    public class Model
    {
        internal ReactiveProperty<Leap.Frame> Frame { get; private set; }

        public ReactiveProperty<List<FingerPoint>> LeftHandFingers { get; private set; }

        public ReactiveProperty<List<FingerPoint>> RightHandFingers { get; private set; }

        public Model()
        {
            this.Frame = new ReactiveProperty<Leap.Frame>();
            var frames = this.Frame
                .Where(f => f != null)
                .Sample(TimeSpan.FromSeconds(1 / 60.0));

            var leftHand = frames
                .Select(f => f.Hands)
                .Select(hs => hs.FirstOrDefault(h => h.IsLeft));

            var rightHand = frames
                .Select(f => f.Hands)
                .Select(hs => hs.FirstOrDefault(h => h.IsRight));

            this.LeftHandFingers = leftHand
                .Where(h => h != null)
                .Select(h => h.Fingers)
                .Select(fs =>
                {
                    var frame = fs.Leftmost.Frame;
                    return fs
                        .Select(f => frame.InteractionBox.NormalizePoint(f.TipPosition))
                        .Select(v => new FingerPoint { X = v.x, Y = v.y, Z = v.z })
                        .ToList();
                })
                .ToReactiveProperty();

            this.RightHandFingers = rightHand
                .Where(h => h != null)
                .Select(h => h.Fingers)
                .Select(fs =>
                {
                    var frame = fs.Leftmost.Frame;
                    return fs
                        .Select(f => frame.InteractionBox.NormalizePoint(f.TipPosition))
                        .Select(v => new FingerPoint { X = v.x, Y = v.y, Z = v.z })
                        .ToList();
                })
                .ToReactiveProperty();
        }
    }
}
