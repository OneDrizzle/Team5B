﻿#pragma checksum "..\..\..\ProjectChefWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D24D48423C38F1B051636A0712868F233AA26251"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MenuWindow;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace MenuWindow {
    
    
    /// <summary>
    /// ProjectChefWindow
    /// </summary>
    public partial class ProjectChefWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\ProjectChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_CreateAggregate;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ProjectChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_FindAggregate;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ProjectChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ben_access_sr;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\ProjectChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_create_sr;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\ProjectChefWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/MenuWindow;component/projectchefwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ProjectChefWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btn_CreateAggregate = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\ProjectChefWindow.xaml"
            this.btn_CreateAggregate.Click += new System.Windows.RoutedEventHandler(this.btn_CreateAggregate_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_FindAggregate = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\ProjectChefWindow.xaml"
            this.btn_FindAggregate.Click += new System.Windows.RoutedEventHandler(this.btn_FindAggregate_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ben_access_sr = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.btn_create_sr = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\ProjectChefWindow.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.Button_back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

