namespace Gu.Wpf.FlipView.Demo.Misc
{
    using System.Windows.Input;
    using Gu.Wpf.FlipView.Gestures;

    public partial class MouseBox : EventBox
    {
        private readonly MouseGestureTracker tracker;
        private bool gestureStarted;

        public MouseBox()
        {
            this.InitializeComponent();
            this.tracker = new MouseGestureTracker { InputElement = this.InputElement };
            this.tracker.Gestured += (_, g) => this.Args.Add(new ArgsVm(g));
        }

        protected override void OnStarted(object sender, InputEventArgs e)
        {
            this.gestureStarted = true;
            base.OnStarted(sender, e);
        }

        protected override void OnInput(object sender, InputEventArgs e)
        {
            if (this.gestureStarted)
            {
                base.OnInput(sender, e);
            }
        }

        protected override void OnEnded(object sender, InputEventArgs e)
        {
            this.gestureStarted = false;
            base.OnEnded(sender, e);
        }
    }
}
