﻿#pragma checksum "..\..\..\FindAgregate.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "666087C1598DFB3A6BB012837A57368A8A015355"
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
    /// FindAgregate
    /// </summary>
    public partial class FindAgregate : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\..\FindAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FindOrderNumber;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\FindAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_saveNewAgregat;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\FindAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_back;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\FindAgregate.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_SearchForAgregate;
        
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
            System.Uri resourceLocater = new System.Uri("/MenuWindow;component/findagregate.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\FindAgregate.xaml"
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
            this.FindOrderNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\..\FindAgregate.xaml"
            this.FindOrderNumber.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.GetOrderNumber_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_saveNewAgregat = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\FindAgregate.xaml"
            this.btn_saveNewAgregat.Click += new System.Windows.RoutedEventHandler(this.btn_saveNewAgregat_Click_);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_back = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\FindAgregate.xaml"
            this.btn_back.Click += new System.Windows.RoutedEventHandler(this.Button_back_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_SearchForAgregate = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\FindAgregate.xaml"
            this.btn_SearchForAgregate.Click += new System.Windows.RoutedEventHandler(this.btn_SearchorAgregate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
