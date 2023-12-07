using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tataruca_Mihai_Lab7
{
    class ValidationBehaviour : Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }
        protected override void OnDetachingFrom(Editor entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var entry = (Editor)sender;
            entry.BackgroundColor = string.IsNullOrEmpty(args.NewTextValue)
                ? Color.FromRgba(170, 74, 68, 255)  // Reddish color with full opacity
                : Color.FromRgba(255, 255, 255, 255);  // White color with full opacity

            entry.TextColor = string.IsNullOrEmpty(args.NewTextValue)
                ? Color.FromRgba(255, 255, 255, 255)  // White color with full opacity
                : Color.FromRgba(0, 0, 0, 255);  // Bla
        }
    }

}
