using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Brail
{
    public static class BrailPaint
    {
        public static int Width = 10;
        public static int Height = 10;
        public static int StrokeThickness = 1;
        public static SolidColorBrush StrokeBrush = Brushes.Black;
        public static Brush FillBrush = Brushes.Black;
        public static Brush NotFillBrush = Brushes.White;

        public static void Paint(List<BrailLetter> brailText, Canvas canvas)
        {
            canvas.Children.Clear();
            for (int i = 0; i < brailText.Count; i++)
            {
                int spacer = 0;
                if (brailText[i].Letter != null)
                {
                    for (int j = 0; j < brailText[i].Letter.GetLength(0); j++)
                    {
                        for (int k = 0; k < brailText[i].Letter.GetLength(1); k++)
                        {
                            Ellipse circle = new Ellipse()
                            {
                                Width = Width,
                                Height = Height,
                                Stroke = StrokeBrush,
                                StrokeThickness = StrokeThickness,
                                Fill = brailText[i].Letter[j, k] == 1 ? FillBrush : NotFillBrush
                            };

                            canvas.Children.Add(circle);

                            circle.SetValue(Canvas.LeftProperty, (double)((j + 2 + 2 * i) * Width + spacer));
                            circle.SetValue(Canvas.TopProperty, (double)((k + 2) * Height));
                        }
                    }
                }
                else
                {
                    spacer += Width * 2;
                }
            }
        }
    }
}