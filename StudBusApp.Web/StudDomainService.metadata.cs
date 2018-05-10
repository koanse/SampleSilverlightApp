
namespace StudBusApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies ГруппаMetadata as the class
    // that carries additional metadata for the Группа class.
    [MetadataTypeAttribute(typeof(Группа.ГруппаMetadata))]
    public partial class Группа
    {

        // This class allows you to attach custom attributes to properties
        // of the Группа class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ГруппаMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ГруппаMetadata()
            {
            }

            [Display(AutoGenerateField=false)]
            public int Код { get; set; }

            public string Наименование { get; set; }
            [Display(AutoGenerateField = false)]
            public EntityCollection<Студент> Студент { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ДисциплинаMetadata as the class
    // that carries additional metadata for the Дисциплина class.
    [MetadataTypeAttribute(typeof(Дисциплина.ДисциплинаMetadata))]
    public partial class Дисциплина
    {

        // This class allows you to attach custom attributes to properties
        // of the Дисциплина class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ДисциплинаMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ДисциплинаMetadata()
            {
            }
            [Display(AutoGenerateField = false)]
            public int Код { get; set; }

            public string Наименование { get; set; }
            [Display(AutoGenerateField = false)]
            public EntityCollection<Оценка> Оценка { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ОценкаMetadata as the class
    // that carries additional metadata for the Оценка class.
    [MetadataTypeAttribute(typeof(Оценка.ОценкаMetadata))]
    public partial class Оценка
    {

        // This class allows you to attach custom attributes to properties
        // of the Оценка class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ОценкаMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ОценкаMetadata()
            {
            }
            
            public Дисциплина Дисциплина { get; set; }
            
            public int КодДисциплины { get; set; }
            
            public int КодСтудента { get; set; }

            public int Оценка1 { get; set; }

            public Студент Студент { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies ОценкаПодробноMetadata as the class
    // that carries additional metadata for the ОценкаПодробно class.
    [MetadataTypeAttribute(typeof(ОценкаПодробно.ОценкаПодробноMetadata))]
    public partial class ОценкаПодробно
    {

        // This class allows you to attach custom attributes to properties
        // of the ОценкаПодробно class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class ОценкаПодробноMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private ОценкаПодробноMetadata()
            {
            }
            
            public string Группа { get; set; }
            
            public string Дисциплина { get; set; }
            [Display(AutoGenerateField = false)]
            public Nullable<int> КодГруппы { get; set; }
            [Display(AutoGenerateField = false)]
            public int КодДисциплины { get; set; }
            [Display(AutoGenerateField = false)]
            public int КодСтудента { get; set; }

            public int Оценка { get; set; }

            public string ФИО { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies СтудентMetadata as the class
    // that carries additional metadata for the Студент class.
    [MetadataTypeAttribute(typeof(Студент.СтудентMetadata))]
    public partial class Студент
    {

        // This class allows you to attach custom attributes to properties
        // of the Студент class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class СтудентMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private СтудентMetadata()
            {
            }
            [Display(AutoGenerateField = false)]
            public Группа Группа { get; set; }
            [Display(AutoGenerateField = false)]
            public int Код { get; set; }
            [Display(Name="Группа")]
            public Nullable<int> КодГруппы { get; set; }
            [Display(AutoGenerateField = false)]
            public EntityCollection<Оценка> Оценка { get; set; }

            public string ФИО { get; set; }
        }
    }

    // The MetadataTypeAttribute identifies СтудентГруппаMetadata as the class
    // that carries additional metadata for the СтудентГруппа class.
    [MetadataTypeAttribute(typeof(СтудентГруппа.СтудентГруппаMetadata))]
    public partial class СтудентГруппа
    {

        // This class allows you to attach custom attributes to properties
        // of the СтудентГруппа class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class СтудентГруппаMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private СтудентГруппаMetadata()
            {
            }
            
            public int Код { get; set; }
            
            public Nullable<int> КодГруппы { get; set; }

            public string Наименование { get; set; }

            public string ФИО { get; set; }
        }
    }
}
