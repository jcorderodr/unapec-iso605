﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unapec.HumanResourcesM.Resources {
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
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Unapec.HumanResourcesM.Resources.Strings", typeof(Strings).Assembly);
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
        ///   Looks up a localized string similar to Todos.
        /// </summary>
        public static string All {
            get {
                return ResourceManager.GetString("All", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UNAPEC Gestor RRHH.
        /// </summary>
        public static string AppName {
            get {
                return ResourceManager.GetString("AppName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Candidato.
        /// </summary>
        public static string Candidate {
            get {
                return ResourceManager.GetString("Candidate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Empleado.
        /// </summary>
        public static string Employee {
            get {
                return ResourceManager.GetString("Employee", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Las credenciales de acceso introducidas son incorrectas..
        /// </summary>
        public static string Message_WrongCredentials {
            get {
                return ResourceManager.GetString("Message_WrongCredentials", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &quot;Estás a punto de cerrar el proceso y guardar tus datos. &quot; + Environment.NewLine +
        ///                            &quot;Estás seguro que has revisa y completado tu información correctamente?&quot;.
        /// </summary>
        public static string Question_WizardNewApplicationSubmit {
            get {
                return ResourceManager.GetString("Question_WizardNewApplicationSubmit", resourceCulture);
            }
        }
    }
}