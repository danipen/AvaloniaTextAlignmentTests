using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Media.TextFormatting;

namespace AvaloniaTextAlignmentTests
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            this.Content = new MyPanel();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        class MyPanel : DockPanel
        {
            public override void Render(DrawingContext context)
            {
                base.Render(context);

                FormattedText formattedText = new FormattedText(
                    "FormattedText -> | This is a sample text just to check the alignment 0123456789 |",
                    new Typeface("Inter"),
                    24,
                    TextAlignment.Left,
                    TextWrapping.NoWrap,
                    Size.Infinity);

                TextLayout textLayout = new TextLayout(
                    "TextLayout -> | This is a sample text just to check the alignment 0123456789 |",
                    new Typeface("Inter"),
                    24,
                    Brushes.Black);

                context.DrawText(
                    Brushes.Black,
                    new Point(10, 10),
                    formattedText);

                context.DrawRectangle(
                    new Pen(Brushes.Red, 1),
                    new Rect(10, 10, formattedText.Bounds.Width, formattedText.Bounds.Height));

                using (context.PushPreTransform(Avalonia.Matrix.CreateTranslation(new Vector(10, 50))))
                {
                    textLayout.Draw(context);
                }

                context.DrawRectangle(
                    new Pen(Brushes.Red, 1),
                    new Rect(10, 50, textLayout.Size.Width, textLayout.Size.Height));
            }
        }
    }
}