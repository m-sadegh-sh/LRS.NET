﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18051
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LRS.NET.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Messages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Messages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LRS.NET.Resources.Messages", typeof(Messages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} {1}
        /// 
        ///نسخه آزمایشی {2}.
        /// </summary>
        public static string AboutText {
            get {
                return ResourceManager.GetString("AboutText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}
        ///{1}
        ///.
        /// </summary>
        public static string EntityInvalid {
            get {
                return ResourceManager.GetString("EntityInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to تغییرات اعمال شده بر روی اطلاعات هنوز به صورت دائمی در سیستم ذخیره نشده اند. آیا واقعا قصد خروج از برنامه را دارید؟.
        /// </summary>
        public static string LoseChangesQuestion {
            get {
                return ResourceManager.GetString("LoseChangesQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to موجود نیست..
        /// </summary>
        public static string NotAvailable {
            get {
                return ResourceManager.GetString("NotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to آیا مایل به ذخیره سازی تغییرات هستید؟.
        /// </summary>
        public static string SaveChangesQuestion {
            get {
                return ResourceManager.GetString("SaveChangesQuestion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to عملیات ذخیره سازی بدلیل وجود خطا در اطلاعات ورودی لغو شد. لطفا خطاهای رخ داده را اصلاح نمائید:
        ///
        ///{0}.
        /// </summary>
        public static string SaveErrorInvalidEntities {
            get {
                return ResourceManager.GetString("SaveErrorInvalidEntities", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to خطایی ناشناخته رخ داده است:
        ///
        ///{0}.
        /// </summary>
        public static string UnknownError {
            get {
                return ResourceManager.GetString("UnknownError", resourceCulture);
            }
        }
    }
}