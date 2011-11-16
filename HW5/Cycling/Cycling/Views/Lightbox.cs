using System;
using System.Windows;
using System.Windows.Controls;

namespace Cycling.Views
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Cycling.Views"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Cycling.Views;assembly=Cycling.Views"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:Lightbox/>
    ///
    /// </summary>
    [TemplatePart(Name="CloseButton", Type=typeof(Button))]
    [TemplatePart(Name = "LightboxGrid", Type = typeof(Grid))]
    public class Lightbox : Control
    {
        static Lightbox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Lightbox), new FrameworkPropertyMetadata(typeof(Lightbox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button closeButton = GetTemplateChild("CloseButton") as Button;
            if (closeButton != null)
            {
                closeButton.Click += CloseButtonClick;
            }
            _lightboxGrid = GetTemplateChild("LightboxGrid") as Grid;

        }


        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            _lightboxGrid.Visibility = Visibility.Collapsed;
            if (CloseClicked != null)
            {
                CloseClicked(this, EventArgs.Empty);
            }
        }

        public event EventHandler CloseClicked;

        public static readonly DependencyProperty ButtonsPanelProperty = DependencyProperty.Register("ButtonsPanel",
                                                                                                 typeof(Panel),
                                                                                                 typeof(Lightbox),
                                                                                                 new FrameworkPropertyMetadata
                                                                                                    (null,
                                                                                                     FrameworkPropertyMetadataOptions
                                                                                                        .AffectsRender));

        public static readonly DependencyProperty MainContentProperty = DependencyProperty.Register("MainContent",
                                                                                         typeof(Panel),
                                                                                         typeof(Lightbox),
                                                                                         new FrameworkPropertyMetadata
                                                                                            (null,
                                                                                             FrameworkPropertyMetadataOptions
                                                                                                .AffectsRender));

        public static readonly DependencyProperty HeaderTextProperty = DependencyProperty.Register("HeaderText",
                                                                                           typeof(string),
                                                                                           typeof(Lightbox),
                                                                                           new FrameworkPropertyMetadata
                                                                                              ("Header Text",
                                                                                               FrameworkPropertyMetadataOptions
                                                                                                  .AffectsRender));

        public new static readonly DependencyProperty VisibilityProperty = DependencyProperty.Register("Visibility",
                                                                                           typeof(Visibility),
                                                                                           typeof(Lightbox),
                                                                                          null);

        private Grid _lightboxGrid;

        public new Visibility Visibility
        {
            get { return _lightboxGrid.Visibility; }
            set { _lightboxGrid.Visibility = value; }
        }

        public string HeaderText
        {
            get { return (string)GetValue(HeaderTextProperty); }
            set { SetValue(HeaderTextProperty, value); }
        }

        public Panel ButtonsPanel
        {
            get { return (Panel)GetValue(ButtonsPanelProperty); }
            set { SetValue(ButtonsPanelProperty, value); }
        }

        public FrameworkElement MainContent
        {
            get { return (Panel)GetValue(MainContentProperty); }
            set { SetValue(MainContentProperty, value); }
        }

    }
}
