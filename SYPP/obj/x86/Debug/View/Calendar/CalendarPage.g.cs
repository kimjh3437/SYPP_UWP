﻿#pragma checksum "C:\Users\kimjh\Desktop\SYPP\SYPP\SYPP\View\Calendar\CalendarPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9C3AD2B5F2AFB707133EB3CD56A3A2CB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SYPP.View.Calendar
{
    partial class CalendarPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // View\Calendar\CalendarPage.xaml line 67
                {
                    global::Windows.UI.Xaml.Controls.Button element2 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element2).Click += this.Today_Clicked;
                }
                break;
            case 3: // View\Calendar\CalendarPage.xaml line 90
                {
                    this.DayTitle = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 4: // View\Calendar\CalendarPage.xaml line 156
                {
                    this.CalendarMonth = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    ((global::Windows.UI.Xaml.Controls.GridView)this.CalendarMonth).SizeChanged += this.CalendarMonth_SizeChanged;
                }
                break;
            case 7: // View\Calendar\CalendarPage.xaml line 198
                {
                    global::Windows.UI.Xaml.Controls.Grid element7 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    ((global::Windows.UI.Xaml.Controls.Grid)element7).Tapped += this.Each_Calendar_Event_Tapped;
                }
                break;
            case 8: // View\Calendar\CalendarPage.xaml line 212
                {
                    global::Windows.UI.Xaml.Controls.Image element8 = (global::Windows.UI.Xaml.Controls.Image)(target);
                    ((global::Windows.UI.Xaml.Controls.Image)element8).Tapped += this.Icon_Favorite_Tapped;
                }
                break;
            case 9: // View\Calendar\CalendarPage.xaml line 31
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.LeftArrow_Clicked;
                }
                break;
            case 10: // View\Calendar\CalendarPage.xaml line 54
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.RightArrow_Clicked;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

