﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Common.Resources {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class DataMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal DataMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Common.Resources.DataMessages", typeof(DataMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
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
        ///   Consulta uma cadeia de caracteres localizada semelhante a {0} gravados de {1} lidos.
        /// </summary>
        public static string DataMessage_Counters {
            get {
                return ResourceManager.GetString("DataMessage_Counters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a &apos;{0}&apos; deve ser maior que &apos;{1}&apos;!.
        /// </summary>
        public static string ErrorMessage_GreaterThan {
            get {
                return ResourceManager.GetString("ErrorMessage_GreaterThan", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a &apos;{0}&apos; pode ter no máximo {1} caracteres!.
        /// </summary>
        public static string ErrorMessage_MaxLength {
            get {
                return ResourceManager.GetString("ErrorMessage_MaxLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a &apos;{0}&apos; pode ter no mínimo {1} caracteres!.
        /// </summary>
        public static string ErrorMessage_MinLength {
            get {
                return ResourceManager.GetString("ErrorMessage_MinLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Entre com pelo menos um &apos;{0}&apos;!.
        /// </summary>
        public static string ErrorMessage_NoRecord {
            get {
                return ResourceManager.GetString("ErrorMessage_NoRecord", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a &apos;{0}&apos; deve estar entre {1} e {2}!.
        /// </summary>
        public static string ErrorMessage_Range {
            get {
                return ResourceManager.GetString("ErrorMessage_Range", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Inclusão não permitida! Registro já existe na base de dados!.
        /// </summary>
        public static string ErrorMessage_RecordFound {
            get {
                return ResourceManager.GetString("ErrorMessage_RecordFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Registro não existe na base de dados!.
        /// </summary>
        public static string ErrorMessage_RecordNotFound {
            get {
                return ResourceManager.GetString("ErrorMessage_RecordNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Exclusão não permitida! Existe(m) registro(s) relacionado(s) na base de dados!.
        /// </summary>
        public static string ErrorMessage_RecordRelated {
            get {
                return ResourceManager.GetString("ErrorMessage_RecordRelated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Somente os valores &apos;{1}&apos; são permitidos para &apos;{0}&apos;!.
        /// </summary>
        public static string ErrorMessage_RegularExpression {
            get {
                return ResourceManager.GetString("ErrorMessage_RegularExpression", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a &apos;{0}&apos; é um atributo obrigatório!.
        /// </summary>
        public static string ErrorMessage_Required {
            get {
                return ResourceManager.GetString("ErrorMessage_Required", resourceCulture);
            }
        }
    }
}
