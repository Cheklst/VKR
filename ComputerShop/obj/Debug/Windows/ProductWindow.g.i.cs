#pragma checksum "..\..\..\Windows\ProductWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E0CC889FF7D388A017AFF3B485652122152826998456F840E147FAF6B7AD6C80"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ComputerShop.Windows;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace ComputerShop.Windows {
    
    
    /// <summary>
    /// ProductWindow
    /// </summary>
    public partial class ProductWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Windows\ProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Frame fMain;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\ProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAccount;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Windows\ProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddProduct;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Windows\ProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnShowHistory;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Windows\ProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEmployee;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Windows\ProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnProductFrame;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Windows\ProductWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ComputerShop;component/windows/productwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\ProductWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 7 "..\..\..\Windows\ProductWindow.xaml"
            ((ComputerShop.Windows.ProductWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.fMain = ((System.Windows.Controls.Frame)(target));
            return;
            case 3:
            this.btnAccount = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Windows\ProductWindow.xaml"
            this.btnAccount.Click += new System.Windows.RoutedEventHandler(this.btnAccount_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAddProduct = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\Windows\ProductWindow.xaml"
            this.btnAddProduct.Click += new System.Windows.RoutedEventHandler(this.btnAddProduct_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnShowHistory = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\Windows\ProductWindow.xaml"
            this.btnShowHistory.Click += new System.Windows.RoutedEventHandler(this.btnShowHistory_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEmployee = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Windows\ProductWindow.xaml"
            this.btnEmployee.Click += new System.Windows.RoutedEventHandler(this.btnEmployee_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnProductFrame = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\Windows\ProductWindow.xaml"
            this.btnProductFrame.Click += new System.Windows.RoutedEventHandler(this.btnProductFrame_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 48 "..\..\..\Windows\ProductWindow.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

