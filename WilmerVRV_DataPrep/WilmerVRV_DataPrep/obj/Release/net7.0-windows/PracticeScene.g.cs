﻿#pragma checksum "..\..\..\PracticeScene.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A9F27170C8D55A4693D679E4970317E4656035A6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using WilmerVRV_DataPrep;


namespace WilmerVRV_DataPrep {
    
    
    /// <summary>
    /// PracticeScene
    /// </summary>
    public partial class PracticeScene : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition LabelsGR;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition ListGR;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition OptionsGR;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition SubmitGR;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox TaskListBox;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TestNameBtn;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\PracticeScene.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Select;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WilmerVRV_DataPrep;V2.0.0.0;component/practicescene.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PracticeScene.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.7.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.LabelsGR = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.ListGR = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 4:
            this.OptionsGR = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 5:
            this.SubmitGR = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 6:
            this.TaskListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            this.TestNameBtn = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\PracticeScene.xaml"
            this.TestNameBtn.Click += new System.Windows.RoutedEventHandler(this.TestNameBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Select = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\PracticeScene.xaml"
            this.Select.Click += new System.Windows.RoutedEventHandler(this.Select_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

