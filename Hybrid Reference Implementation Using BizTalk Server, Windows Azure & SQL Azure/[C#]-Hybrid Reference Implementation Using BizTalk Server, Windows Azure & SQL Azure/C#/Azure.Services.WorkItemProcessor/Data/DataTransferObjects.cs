//==================================================================================
// Contoso Cloud Integration Service Layer Solution
//
// The Work Item Processor worker role implementation
//
//==================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=================================================================================
using System.Runtime.Serialization;
using System;

namespace Contoso.Cloud.Integration.Azure.Services.WorkItemProcessor.Data
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ProductData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class ProductData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProductPartyLocation_DTO PPL_ProductPartyLocationObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private BrandCodeData_DTO PRB_ProductBrandCodeObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProductCategoryData_DTO PRC_ProductCategoryObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProductDetailsData_DTO PRD_ProductDetailsObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProductStatusData_DTO PRS_ProductStatusObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UOMTypesData_DTO PRUOM_ProductUOMObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_BrandCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_CatalogPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_CategoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_CountryOfOriginField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_IndustryPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PR_LastUpdatedTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_ManufacturerPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_NoteField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_PartOwnerIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_ProductDescriptionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_ProductIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_ProductNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_ProductStatusIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_SupersededPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_UOMWeightField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_UPC_Code_GTINField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PR_UnitHeightField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PR_UnitLengthField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PR_UnitWeightField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProductPartyLocation_DTO PPL_ProductPartyLocationObj
        {
            get
            {
                return this.PPL_ProductPartyLocationObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PPL_ProductPartyLocationObjField, value) != true))
                {
                    this.PPL_ProductPartyLocationObjField = value;
                    this.RaisePropertyChanged("PPL_ProductPartyLocationObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public BrandCodeData_DTO PRB_ProductBrandCodeObj
        {
            get
            {
                return this.PRB_ProductBrandCodeObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRB_ProductBrandCodeObjField, value) != true))
                {
                    this.PRB_ProductBrandCodeObjField = value;
                    this.RaisePropertyChanged("PRB_ProductBrandCodeObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProductCategoryData_DTO PRC_ProductCategoryObj
        {
            get
            {
                return this.PRC_ProductCategoryObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRC_ProductCategoryObjField, value) != true))
                {
                    this.PRC_ProductCategoryObjField = value;
                    this.RaisePropertyChanged("PRC_ProductCategoryObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProductDetailsData_DTO PRD_ProductDetailsObj
        {
            get
            {
                return this.PRD_ProductDetailsObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_ProductDetailsObjField, value) != true))
                {
                    this.PRD_ProductDetailsObjField = value;
                    this.RaisePropertyChanged("PRD_ProductDetailsObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProductStatusData_DTO PRS_ProductStatusObj
        {
            get
            {
                return this.PRS_ProductStatusObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRS_ProductStatusObjField, value) != true))
                {
                    this.PRS_ProductStatusObjField = value;
                    this.RaisePropertyChanged("PRS_ProductStatusObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public UOMTypesData_DTO PRUOM_ProductUOMObj
        {
            get
            {
                return this.PRUOM_ProductUOMObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRUOM_ProductUOMObjField, value) != true))
                {
                    this.PRUOM_ProductUOMObjField = value;
                    this.RaisePropertyChanged("PRUOM_ProductUOMObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_BrandCode
        {
            get
            {
                return this.PR_BrandCodeField;
            }
            set
            {
                if ((this.PR_BrandCodeField.Equals(value) != true))
                {
                    this.PR_BrandCodeField = value;
                    this.RaisePropertyChanged("PR_BrandCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_CatalogPartNum
        {
            get
            {
                return this.PR_CatalogPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_CatalogPartNumField, value) != true))
                {
                    this.PR_CatalogPartNumField = value;
                    this.RaisePropertyChanged("PR_CatalogPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_CategoryId
        {
            get
            {
                return this.PR_CategoryIdField;
            }
            set
            {
                if ((this.PR_CategoryIdField.Equals(value) != true))
                {
                    this.PR_CategoryIdField = value;
                    this.RaisePropertyChanged("PR_CategoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_CountryOfOrigin
        {
            get
            {
                return this.PR_CountryOfOriginField;
            }
            set
            {
                if ((this.PR_CountryOfOriginField.Equals(value) != true))
                {
                    this.PR_CountryOfOriginField = value;
                    this.RaisePropertyChanged("PR_CountryOfOrigin");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_IndustryPartNum
        {
            get
            {
                return this.PR_IndustryPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_IndustryPartNumField, value) != true))
                {
                    this.PR_IndustryPartNumField = value;
                    this.RaisePropertyChanged("PR_IndustryPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PR_LastUpdatedTime
        {
            get
            {
                return this.PR_LastUpdatedTimeField;
            }
            set
            {
                if ((this.PR_LastUpdatedTimeField.Equals(value) != true))
                {
                    this.PR_LastUpdatedTimeField = value;
                    this.RaisePropertyChanged("PR_LastUpdatedTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_ManufacturerPartNum
        {
            get
            {
                return this.PR_ManufacturerPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ManufacturerPartNumField, value) != true))
                {
                    this.PR_ManufacturerPartNumField = value;
                    this.RaisePropertyChanged("PR_ManufacturerPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_Note
        {
            get
            {
                return this.PR_NoteField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_NoteField, value) != true))
                {
                    this.PR_NoteField = value;
                    this.RaisePropertyChanged("PR_Note");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_PartOwnerId
        {
            get
            {
                return this.PR_PartOwnerIdField;
            }
            set
            {
                if ((this.PR_PartOwnerIdField.Equals(value) != true))
                {
                    this.PR_PartOwnerIdField = value;
                    this.RaisePropertyChanged("PR_PartOwnerId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_ProductDescription
        {
            get
            {
                return this.PR_ProductDescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ProductDescriptionField, value) != true))
                {
                    this.PR_ProductDescriptionField = value;
                    this.RaisePropertyChanged("PR_ProductDescription");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_ProductID
        {
            get
            {
                return this.PR_ProductIDField;
            }
            set
            {
                if ((this.PR_ProductIDField.Equals(value) != true))
                {
                    this.PR_ProductIDField = value;
                    this.RaisePropertyChanged("PR_ProductID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_ProductName
        {
            get
            {
                return this.PR_ProductNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ProductNameField, value) != true))
                {
                    this.PR_ProductNameField = value;
                    this.RaisePropertyChanged("PR_ProductName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_ProductStatusId
        {
            get
            {
                return this.PR_ProductStatusIdField;
            }
            set
            {
                if ((this.PR_ProductStatusIdField.Equals(value) != true))
                {
                    this.PR_ProductStatusIdField = value;
                    this.RaisePropertyChanged("PR_ProductStatusId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_SupersededPartNum
        {
            get
            {
                return this.PR_SupersededPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_SupersededPartNumField, value) != true))
                {
                    this.PR_SupersededPartNumField = value;
                    this.RaisePropertyChanged("PR_SupersededPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_UOMWeight
        {
            get
            {
                return this.PR_UOMWeightField;
            }
            set
            {
                if ((this.PR_UOMWeightField.Equals(value) != true))
                {
                    this.PR_UOMWeightField = value;
                    this.RaisePropertyChanged("PR_UOMWeight");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_UPC_Code_GTIN
        {
            get
            {
                return this.PR_UPC_Code_GTINField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_UPC_Code_GTINField, value) != true))
                {
                    this.PR_UPC_Code_GTINField = value;
                    this.RaisePropertyChanged("PR_UPC_Code_GTIN");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PR_UnitHeight
        {
            get
            {
                return this.PR_UnitHeightField;
            }
            set
            {
                if ((this.PR_UnitHeightField.Equals(value) != true))
                {
                    this.PR_UnitHeightField = value;
                    this.RaisePropertyChanged("PR_UnitHeight");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PR_UnitLength
        {
            get
            {
                return this.PR_UnitLengthField;
            }
            set
            {
                if ((this.PR_UnitLengthField.Equals(value) != true))
                {
                    this.PR_UnitLengthField = value;
                    this.RaisePropertyChanged("PR_UnitLength");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PR_UnitWeight
        {
            get
            {
                return this.PR_UnitWeightField;
            }
            set
            {
                if ((this.PR_UnitWeightField.Equals(value) != true))
                {
                    this.PR_UnitWeightField = value;
                    this.RaisePropertyChanged("PR_UnitWeight");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ProductPartyLocation_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class ProductPartyLocation_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LocationData_DTO LOC_LocationDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PPL_LocationField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PPL_PartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PPL_Prod_Party_LocIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PPL_ProductIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProductData_DTO PR_ProductDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public LocationData_DTO LOC_LocationDataObj
        {
            get
            {
                return this.LOC_LocationDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_LocationDataObjField, value) != true))
                {
                    this.LOC_LocationDataObjField = value;
                    this.RaisePropertyChanged("LOC_LocationDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PPL_Location
        {
            get
            {
                return this.PPL_LocationField;
            }
            set
            {
                if ((this.PPL_LocationField.Equals(value) != true))
                {
                    this.PPL_LocationField = value;
                    this.RaisePropertyChanged("PPL_Location");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PPL_PartyId
        {
            get
            {
                return this.PPL_PartyIdField;
            }
            set
            {
                if ((this.PPL_PartyIdField.Equals(value) != true))
                {
                    this.PPL_PartyIdField = value;
                    this.RaisePropertyChanged("PPL_PartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PPL_Prod_Party_LocId
        {
            get
            {
                return this.PPL_Prod_Party_LocIdField;
            }
            set
            {
                if ((this.PPL_Prod_Party_LocIdField.Equals(value) != true))
                {
                    this.PPL_Prod_Party_LocIdField = value;
                    this.RaisePropertyChanged("PPL_Prod_Party_LocId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PPL_ProductId
        {
            get
            {
                return this.PPL_ProductIdField;
            }
            set
            {
                if ((this.PPL_ProductIdField.Equals(value) != true))
                {
                    this.PPL_ProductIdField = value;
                    this.RaisePropertyChanged("PPL_ProductId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProductData_DTO PR_ProductDataObj
        {
            get
            {
                return this.PR_ProductDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ProductDataObjField, value) != true))
                {
                    this.PR_ProductDataObjField = value;
                    this.RaisePropertyChanged("PR_ProductDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "BrandCodeData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class BrandCodeData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int BC_BrandCodeIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_BrandIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_BrandNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_BrandOwnerIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_BrandOwnerNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_ParentCompanyField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_ParentIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BC_RevisionDateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_SubBrandIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BC_SubBrandNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int BC_BrandCodeId
        {
            get
            {
                return this.BC_BrandCodeIdField;
            }
            set
            {
                if ((this.BC_BrandCodeIdField.Equals(value) != true))
                {
                    this.BC_BrandCodeIdField = value;
                    this.RaisePropertyChanged("BC_BrandCodeId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_BrandId
        {
            get
            {
                return this.BC_BrandIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_BrandIdField, value) != true))
                {
                    this.BC_BrandIdField = value;
                    this.RaisePropertyChanged("BC_BrandId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_BrandName
        {
            get
            {
                return this.BC_BrandNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_BrandNameField, value) != true))
                {
                    this.BC_BrandNameField = value;
                    this.RaisePropertyChanged("BC_BrandName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_BrandOwnerId
        {
            get
            {
                return this.BC_BrandOwnerIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_BrandOwnerIdField, value) != true))
                {
                    this.BC_BrandOwnerIdField = value;
                    this.RaisePropertyChanged("BC_BrandOwnerId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_BrandOwnerName
        {
            get
            {
                return this.BC_BrandOwnerNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_BrandOwnerNameField, value) != true))
                {
                    this.BC_BrandOwnerNameField = value;
                    this.RaisePropertyChanged("BC_BrandOwnerName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_ParentCompany
        {
            get
            {
                return this.BC_ParentCompanyField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_ParentCompanyField, value) != true))
                {
                    this.BC_ParentCompanyField = value;
                    this.RaisePropertyChanged("BC_ParentCompany");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_ParentId
        {
            get
            {
                return this.BC_ParentIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_ParentIdField, value) != true))
                {
                    this.BC_ParentIdField = value;
                    this.RaisePropertyChanged("BC_ParentId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime BC_RevisionDate
        {
            get
            {
                return this.BC_RevisionDateField;
            }
            set
            {
                if ((this.BC_RevisionDateField.Equals(value) != true))
                {
                    this.BC_RevisionDateField = value;
                    this.RaisePropertyChanged("BC_RevisionDate");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_SubBrandId
        {
            get
            {
                return this.BC_SubBrandIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_SubBrandIdField, value) != true))
                {
                    this.BC_SubBrandIdField = value;
                    this.RaisePropertyChanged("BC_SubBrandId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string BC_SubBrandName
        {
            get
            {
                return this.BC_SubBrandNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.BC_SubBrandNameField, value) != true))
                {
                    this.BC_SubBrandNameField = value;
                    this.RaisePropertyChanged("BC_SubBrandName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ProductCategoryData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class ProductCategoryData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ProductDetailsData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class ProductDetailsData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRD_ColorField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool PRD_HazzardIndicatorField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_MakeNumberField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_ModelNumberField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_ModelYearField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_PictureURLField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRD_ProductDetailIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRD_ProductIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRD_RankingField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRD_SizeField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRD_Color
        {
            get
            {
                return this.PRD_ColorField;
            }
            set
            {
                if ((this.PRD_ColorField.Equals(value) != true))
                {
                    this.PRD_ColorField = value;
                    this.RaisePropertyChanged("PRD_Color");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PRD_HazzardIndicator
        {
            get
            {
                return this.PRD_HazzardIndicatorField;
            }
            set
            {
                if ((this.PRD_HazzardIndicatorField.Equals(value) != true))
                {
                    this.PRD_HazzardIndicatorField = value;
                    this.RaisePropertyChanged("PRD_HazzardIndicator");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_MakeNumber
        {
            get
            {
                return this.PRD_MakeNumberField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_MakeNumberField, value) != true))
                {
                    this.PRD_MakeNumberField = value;
                    this.RaisePropertyChanged("PRD_MakeNumber");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_ModelNumber
        {
            get
            {
                return this.PRD_ModelNumberField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_ModelNumberField, value) != true))
                {
                    this.PRD_ModelNumberField = value;
                    this.RaisePropertyChanged("PRD_ModelNumber");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_ModelYear
        {
            get
            {
                return this.PRD_ModelYearField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_ModelYearField, value) != true))
                {
                    this.PRD_ModelYearField = value;
                    this.RaisePropertyChanged("PRD_ModelYear");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_PictureURL
        {
            get
            {
                return this.PRD_PictureURLField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_PictureURLField, value) != true))
                {
                    this.PRD_PictureURLField = value;
                    this.RaisePropertyChanged("PRD_PictureURL");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRD_ProductDetailId
        {
            get
            {
                return this.PRD_ProductDetailIdField;
            }
            set
            {
                if ((this.PRD_ProductDetailIdField.Equals(value) != true))
                {
                    this.PRD_ProductDetailIdField = value;
                    this.RaisePropertyChanged("PRD_ProductDetailId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRD_ProductId
        {
            get
            {
                return this.PRD_ProductIdField;
            }
            set
            {
                if ((this.PRD_ProductIdField.Equals(value) != true))
                {
                    this.PRD_ProductIdField = value;
                    this.RaisePropertyChanged("PRD_ProductId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRD_Ranking
        {
            get
            {
                return this.PRD_RankingField;
            }
            set
            {
                if ((this.PRD_RankingField.Equals(value) != true))
                {
                    this.PRD_RankingField = value;
                    this.RaisePropertyChanged("PRD_Ranking");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRD_Size
        {
            get
            {
                return this.PRD_SizeField;
            }
            set
            {
                if ((this.PRD_SizeField.Equals(value) != true))
                {
                    this.PRD_SizeField = value;
                    this.RaisePropertyChanged("PRD_Size");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "ProductStatusData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class ProductStatusData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PS_ProductStatusCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PS_ProductStatusNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RPS_ProductStatusIdField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PS_ProductStatusCode
        {
            get
            {
                return this.PS_ProductStatusCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PS_ProductStatusCodeField, value) != true))
                {
                    this.PS_ProductStatusCodeField = value;
                    this.RaisePropertyChanged("PS_ProductStatusCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PS_ProductStatusName
        {
            get
            {
                return this.PS_ProductStatusNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PS_ProductStatusNameField, value) != true))
                {
                    this.PS_ProductStatusNameField = value;
                    this.RaisePropertyChanged("PS_ProductStatusName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RPS_ProductStatusId
        {
            get
            {
                return this.RPS_ProductStatusIdField;
            }
            set
            {
                if ((this.RPS_ProductStatusIdField.Equals(value) != true))
                {
                    this.RPS_ProductStatusIdField = value;
                    this.RaisePropertyChanged("RPS_ProductStatusId");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "UOMTypesData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class UOMTypesData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UOM_DescriptionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UOM_GTINPackLevelField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UOM_UOM_CodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int UOM_UOM_IdField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UOM_Description
        {
            get
            {
                return this.UOM_DescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.UOM_DescriptionField, value) != true))
                {
                    this.UOM_DescriptionField = value;
                    this.RaisePropertyChanged("UOM_Description");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UOM_GTINPackLevel
        {
            get
            {
                return this.UOM_GTINPackLevelField;
            }
            set
            {
                if ((this.UOM_GTINPackLevelField.Equals(value) != true))
                {
                    this.UOM_GTINPackLevelField = value;
                    this.RaisePropertyChanged("UOM_GTINPackLevel");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UOM_UOM_Code
        {
            get
            {
                return this.UOM_UOM_CodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.UOM_UOM_CodeField, value) != true))
                {
                    this.UOM_UOM_CodeField = value;
                    this.RaisePropertyChanged("UOM_UOM_Code");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int UOM_UOM_Id
        {
            get
            {
                return this.UOM_UOM_IdField;
            }
            set
            {
                if ((this.UOM_UOM_IdField.Equals(value) != true))
                {
                    this.UOM_UOM_IdField = value;
                    this.RaisePropertyChanged("UOM_UOM_Id");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "LocationData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class LocationData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_Address1Field;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_Address2Field;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_CityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_CompanyNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_ContactField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_CountryField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LOC_LocationIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_LocationNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LOC_LocationTypeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_ProvinceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LOC_RegionIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_StateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_TimeZoneField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LOC_ZipCodeField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_Address1
        {
            get
            {
                return this.LOC_Address1Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_Address1Field, value) != true))
                {
                    this.LOC_Address1Field = value;
                    this.RaisePropertyChanged("LOC_Address1");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_Address2
        {
            get
            {
                return this.LOC_Address2Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_Address2Field, value) != true))
                {
                    this.LOC_Address2Field = value;
                    this.RaisePropertyChanged("LOC_Address2");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_City
        {
            get
            {
                return this.LOC_CityField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_CityField, value) != true))
                {
                    this.LOC_CityField = value;
                    this.RaisePropertyChanged("LOC_City");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_CompanyName
        {
            get
            {
                return this.LOC_CompanyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_CompanyNameField, value) != true))
                {
                    this.LOC_CompanyNameField = value;
                    this.RaisePropertyChanged("LOC_CompanyName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_Contact
        {
            get
            {
                return this.LOC_ContactField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_ContactField, value) != true))
                {
                    this.LOC_ContactField = value;
                    this.RaisePropertyChanged("LOC_Contact");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_Country
        {
            get
            {
                return this.LOC_CountryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_CountryField, value) != true))
                {
                    this.LOC_CountryField = value;
                    this.RaisePropertyChanged("LOC_Country");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LOC_LocationID
        {
            get
            {
                return this.LOC_LocationIDField;
            }
            set
            {
                if ((this.LOC_LocationIDField.Equals(value) != true))
                {
                    this.LOC_LocationIDField = value;
                    this.RaisePropertyChanged("LOC_LocationID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_LocationName
        {
            get
            {
                return this.LOC_LocationNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_LocationNameField, value) != true))
                {
                    this.LOC_LocationNameField = value;
                    this.RaisePropertyChanged("LOC_LocationName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LOC_LocationType
        {
            get
            {
                return this.LOC_LocationTypeField;
            }
            set
            {
                if ((this.LOC_LocationTypeField.Equals(value) != true))
                {
                    this.LOC_LocationTypeField = value;
                    this.RaisePropertyChanged("LOC_LocationType");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_Province
        {
            get
            {
                return this.LOC_ProvinceField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_ProvinceField, value) != true))
                {
                    this.LOC_ProvinceField = value;
                    this.RaisePropertyChanged("LOC_Province");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LOC_RegionId
        {
            get
            {
                return this.LOC_RegionIdField;
            }
            set
            {
                if ((this.LOC_RegionIdField.Equals(value) != true))
                {
                    this.LOC_RegionIdField = value;
                    this.RaisePropertyChanged("LOC_RegionId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_State
        {
            get
            {
                return this.LOC_StateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_StateField, value) != true))
                {
                    this.LOC_StateField = value;
                    this.RaisePropertyChanged("LOC_State");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_TimeZone
        {
            get
            {
                return this.LOC_TimeZoneField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_TimeZoneField, value) != true))
                {
                    this.LOC_TimeZoneField = value;
                    this.RaisePropertyChanged("LOC_TimeZone");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LOC_ZipCode
        {
            get
            {
                return this.LOC_ZipCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_ZipCodeField, value) != true))
                {
                    this.LOC_ZipCodeField = value;
                    this.RaisePropertyChanged("LOC_ZipCode");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PartyData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class PartyData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CurrencyData_DTO CUR_CurrencyObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LanguageData_DTO LAN_LanguageDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyCategoryData_DTO PC_PartyCategoryObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_CurrencyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTY_IPOVersionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_LanguageIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_NetworkParticipantIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_PartyCategoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_PartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTY_PartyNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_PartyTypeIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTY_PassthroughLoopUpURLField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool PTY_ShowAdjustedQuantityField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public CurrencyData_DTO CUR_CurrencyObj
        {
            get
            {
                return this.CUR_CurrencyObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CUR_CurrencyObjField, value) != true))
                {
                    this.CUR_CurrencyObjField = value;
                    this.RaisePropertyChanged("CUR_CurrencyObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public LanguageData_DTO LAN_LanguageDataObj
        {
            get
            {
                return this.LAN_LanguageDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LAN_LanguageDataObjField, value) != true))
                {
                    this.LAN_LanguageDataObjField = value;
                    this.RaisePropertyChanged("LAN_LanguageDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyCategoryData_DTO PC_PartyCategoryObj
        {
            get
            {
                return this.PC_PartyCategoryObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PC_PartyCategoryObjField, value) != true))
                {
                    this.PC_PartyCategoryObjField = value;
                    this.RaisePropertyChanged("PC_PartyCategoryObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_CurrencyId
        {
            get
            {
                return this.PTY_CurrencyIdField;
            }
            set
            {
                if ((this.PTY_CurrencyIdField.Equals(value) != true))
                {
                    this.PTY_CurrencyIdField = value;
                    this.RaisePropertyChanged("PTY_CurrencyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTY_IPOVersion
        {
            get
            {
                return this.PTY_IPOVersionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_IPOVersionField, value) != true))
                {
                    this.PTY_IPOVersionField = value;
                    this.RaisePropertyChanged("PTY_IPOVersion");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_LanguageId
        {
            get
            {
                return this.PTY_LanguageIdField;
            }
            set
            {
                if ((this.PTY_LanguageIdField.Equals(value) != true))
                {
                    this.PTY_LanguageIdField = value;
                    this.RaisePropertyChanged("PTY_LanguageId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_NetworkParticipantId
        {
            get
            {
                return this.PTY_NetworkParticipantIdField;
            }
            set
            {
                if ((this.PTY_NetworkParticipantIdField.Equals(value) != true))
                {
                    this.PTY_NetworkParticipantIdField = value;
                    this.RaisePropertyChanged("PTY_NetworkParticipantId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_PartyCategoryId
        {
            get
            {
                return this.PTY_PartyCategoryIdField;
            }
            set
            {
                if ((this.PTY_PartyCategoryIdField.Equals(value) != true))
                {
                    this.PTY_PartyCategoryIdField = value;
                    this.RaisePropertyChanged("PTY_PartyCategoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_PartyId
        {
            get
            {
                return this.PTY_PartyIdField;
            }
            set
            {
                if ((this.PTY_PartyIdField.Equals(value) != true))
                {
                    this.PTY_PartyIdField = value;
                    this.RaisePropertyChanged("PTY_PartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTY_PartyName
        {
            get
            {
                return this.PTY_PartyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyNameField, value) != true))
                {
                    this.PTY_PartyNameField = value;
                    this.RaisePropertyChanged("PTY_PartyName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_PartyTypeId
        {
            get
            {
                return this.PTY_PartyTypeIdField;
            }
            set
            {
                if ((this.PTY_PartyTypeIdField.Equals(value) != true))
                {
                    this.PTY_PartyTypeIdField = value;
                    this.RaisePropertyChanged("PTY_PartyTypeId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTY_PassthroughLoopUpURL
        {
            get
            {
                return this.PTY_PassthroughLoopUpURLField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PassthroughLoopUpURLField, value) != true))
                {
                    this.PTY_PassthroughLoopUpURLField = value;
                    this.RaisePropertyChanged("PTY_PassthroughLoopUpURL");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PTY_ShowAdjustedQuantity
        {
            get
            {
                return this.PTY_ShowAdjustedQuantityField;
            }
            set
            {
                if ((this.PTY_ShowAdjustedQuantityField.Equals(value) != true))
                {
                    this.PTY_ShowAdjustedQuantityField = value;
                    this.RaisePropertyChanged("PTY_ShowAdjustedQuantity");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "CurrencyData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class CurrencyData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CUR_ConversionValueField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CUR_CountryField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CUR_CurrencyCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CUR_CurrencyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CUR_CurrencyNameField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CUR_ConversionValue
        {
            get
            {
                return this.CUR_ConversionValueField;
            }
            set
            {
                if ((this.CUR_ConversionValueField.Equals(value) != true))
                {
                    this.CUR_ConversionValueField = value;
                    this.RaisePropertyChanged("CUR_ConversionValue");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CUR_Country
        {
            get
            {
                return this.CUR_CountryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CUR_CountryField, value) != true))
                {
                    this.CUR_CountryField = value;
                    this.RaisePropertyChanged("CUR_Country");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CUR_CurrencyCode
        {
            get
            {
                return this.CUR_CurrencyCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CUR_CurrencyCodeField, value) != true))
                {
                    this.CUR_CurrencyCodeField = value;
                    this.RaisePropertyChanged("CUR_CurrencyCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int CUR_CurrencyId
        {
            get
            {
                return this.CUR_CurrencyIdField;
            }
            set
            {
                if ((this.CUR_CurrencyIdField.Equals(value) != true))
                {
                    this.CUR_CurrencyIdField = value;
                    this.RaisePropertyChanged("CUR_CurrencyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CUR_CurrencyName
        {
            get
            {
                return this.CUR_CurrencyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CUR_CurrencyNameField, value) != true))
                {
                    this.CUR_CurrencyNameField = value;
                    this.RaisePropertyChanged("CUR_CurrencyName");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "LanguageData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class LanguageData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LAN_CountryField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LAN_LanguageCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LAN_LanguageIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LAN_LanguageNameField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LAN_Country
        {
            get
            {
                return this.LAN_CountryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LAN_CountryField, value) != true))
                {
                    this.LAN_CountryField = value;
                    this.RaisePropertyChanged("LAN_Country");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LAN_LanguageCode
        {
            get
            {
                return this.LAN_LanguageCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LAN_LanguageCodeField, value) != true))
                {
                    this.LAN_LanguageCodeField = value;
                    this.RaisePropertyChanged("LAN_LanguageCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LAN_LanguageId
        {
            get
            {
                return this.LAN_LanguageIdField;
            }
            set
            {
                if ((this.LAN_LanguageIdField.Equals(value) != true))
                {
                    this.LAN_LanguageIdField = value;
                    this.RaisePropertyChanged("LAN_LanguageId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LAN_LanguageName
        {
            get
            {
                return this.LAN_LanguageNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LAN_LanguageNameField, value) != true))
                {
                    this.LAN_LanguageNameField = value;
                    this.RaisePropertyChanged("LAN_LanguageName");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "PartyCategoryData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class PartyCategoryData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTC_Address1Field;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTC_Address2Field;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTC_CityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTC_CountryField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTC_NetworkParticipantIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTC_PartyCategoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTC_PartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTC_PartyNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTC_StateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTC_ZipCodeField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTC_Address1
        {
            get
            {
                return this.PTC_Address1Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTC_Address1Field, value) != true))
                {
                    this.PTC_Address1Field = value;
                    this.RaisePropertyChanged("PTC_Address1");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTC_Address2
        {
            get
            {
                return this.PTC_Address2Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTC_Address2Field, value) != true))
                {
                    this.PTC_Address2Field = value;
                    this.RaisePropertyChanged("PTC_Address2");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTC_City
        {
            get
            {
                return this.PTC_CityField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTC_CityField, value) != true))
                {
                    this.PTC_CityField = value;
                    this.RaisePropertyChanged("PTC_City");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTC_Country
        {
            get
            {
                return this.PTC_CountryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTC_CountryField, value) != true))
                {
                    this.PTC_CountryField = value;
                    this.RaisePropertyChanged("PTC_Country");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTC_NetworkParticipantId
        {
            get
            {
                return this.PTC_NetworkParticipantIdField;
            }
            set
            {
                if ((this.PTC_NetworkParticipantIdField.Equals(value) != true))
                {
                    this.PTC_NetworkParticipantIdField = value;
                    this.RaisePropertyChanged("PTC_NetworkParticipantId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTC_PartyCategoryId
        {
            get
            {
                return this.PTC_PartyCategoryIdField;
            }
            set
            {
                if ((this.PTC_PartyCategoryIdField.Equals(value) != true))
                {
                    this.PTC_PartyCategoryIdField = value;
                    this.RaisePropertyChanged("PTC_PartyCategoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTC_PartyId
        {
            get
            {
                return this.PTC_PartyIdField;
            }
            set
            {
                if ((this.PTC_PartyIdField.Equals(value) != true))
                {
                    this.PTC_PartyIdField = value;
                    this.RaisePropertyChanged("PTC_PartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTC_PartyName
        {
            get
            {
                return this.PTC_PartyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTC_PartyNameField, value) != true))
                {
                    this.PTC_PartyNameField = value;
                    this.RaisePropertyChanged("PTC_PartyName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTC_State
        {
            get
            {
                return this.PTC_StateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTC_StateField, value) != true))
                {
                    this.PTC_StateField = value;
                    this.RaisePropertyChanged("PTC_State");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTC_ZipCode
        {
            get
            {
                return this.PTC_ZipCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTC_ZipCodeField, value) != true))
                {
                    this.PTC_ZipCodeField = value;
                    this.RaisePropertyChanged("PTC_ZipCode");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "InventorySearch_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class InventorySearch_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AuthorizationData_DTO ATH_AuthorizationObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_AdjustedAvailableQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string INV_AvailableQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double INV_BreakPackPriceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool INV_BuiltOrderField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_BuyerPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_CurrencyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool INV_DropShipmentField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_InventoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime INV_LastUpdatedTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime INV_LeadTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_MinimumOrderQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_QuantityPerUnitField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_RequestedQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_UnitOfMeasureField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double INV_UnitPriceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_VendorPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_Address1Field;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_Address2Field;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_CityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_CompanyNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_ContactField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_CountryField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int LCT_LocationIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_ProvinceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_StateField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LCT_ZipCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRB_BrandIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRB_BrandNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRB_ParentCompanyField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRC_CategoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRC_CategoryNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRC_DescriptionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_ColorField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool PRD_HazzardIndicatorField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_MakeNumberField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_ModelNumberField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_ModelYearField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRD_PictureURLField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRD_RankingField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRD_SizeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRS_ProductStatusCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRS_ProductStatusIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRS_ProductStatusNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRUOM_GTINPackLevelField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PRUOM_UOMCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PRUOM_UOMDescriptionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_BrandCodeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_BrandNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_CatalogPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_CategoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_CategoryNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_CountryOfOriginField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_IndustryPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime PR_LastUpdatedTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_ManufacturerPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_NoteField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_PartOwnerIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_ProductDescriptionField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_ProductIDField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_ProductNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_ProductStatusIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_ProductStatusNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_SupersededPartNumField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PR_UOMWeightField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PR_UPC_Code_GTINField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PR_UnitHeightField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PR_UnitLengthField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double PR_UnitWeightField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_CurrencyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTY_CurrencyNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_LanguageIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTY_LanguageNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PTY_PartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PTY_PartyNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool PTY_ShowAdjustedQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SearchPartField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SearchPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SearchPartyNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SearchQtyField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public AuthorizationData_DTO ATH_AuthorizationObj
        {
            get
            {
                return this.ATH_AuthorizationObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATH_AuthorizationObjField, value) != true))
                {
                    this.ATH_AuthorizationObjField = value;
                    this.RaisePropertyChanged("ATH_AuthorizationObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_AdjustedAvailableQuantity
        {
            get
            {
                return this.INV_AdjustedAvailableQuantityField;
            }
            set
            {
                if ((this.INV_AdjustedAvailableQuantityField.Equals(value) != true))
                {
                    this.INV_AdjustedAvailableQuantityField = value;
                    this.RaisePropertyChanged("INV_AdjustedAvailableQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string INV_AvailableQuantity
        {
            get
            {
                return this.INV_AvailableQuantityField;
            }
            set
            {
                if ((object.ReferenceEquals(this.INV_AvailableQuantityField, value) != true))
                {
                    this.INV_AvailableQuantityField = value;
                    this.RaisePropertyChanged("INV_AvailableQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double INV_BreakPackPrice
        {
            get
            {
                return this.INV_BreakPackPriceField;
            }
            set
            {
                if ((this.INV_BreakPackPriceField.Equals(value) != true))
                {
                    this.INV_BreakPackPriceField = value;
                    this.RaisePropertyChanged("INV_BreakPackPrice");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool INV_BuiltOrder
        {
            get
            {
                return this.INV_BuiltOrderField;
            }
            set
            {
                if ((this.INV_BuiltOrderField.Equals(value) != true))
                {
                    this.INV_BuiltOrderField = value;
                    this.RaisePropertyChanged("INV_BuiltOrder");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_BuyerPartyId
        {
            get
            {
                return this.INV_BuyerPartyIdField;
            }
            set
            {
                if ((this.INV_BuyerPartyIdField.Equals(value) != true))
                {
                    this.INV_BuyerPartyIdField = value;
                    this.RaisePropertyChanged("INV_BuyerPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_CurrencyId
        {
            get
            {
                return this.INV_CurrencyIdField;
            }
            set
            {
                if ((this.INV_CurrencyIdField.Equals(value) != true))
                {
                    this.INV_CurrencyIdField = value;
                    this.RaisePropertyChanged("INV_CurrencyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool INV_DropShipment
        {
            get
            {
                return this.INV_DropShipmentField;
            }
            set
            {
                if ((this.INV_DropShipmentField.Equals(value) != true))
                {
                    this.INV_DropShipmentField = value;
                    this.RaisePropertyChanged("INV_DropShipment");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_InventoryId
        {
            get
            {
                return this.INV_InventoryIdField;
            }
            set
            {
                if ((this.INV_InventoryIdField.Equals(value) != true))
                {
                    this.INV_InventoryIdField = value;
                    this.RaisePropertyChanged("INV_InventoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime INV_LastUpdatedTime
        {
            get
            {
                return this.INV_LastUpdatedTimeField;
            }
            set
            {
                if ((this.INV_LastUpdatedTimeField.Equals(value) != true))
                {
                    this.INV_LastUpdatedTimeField = value;
                    this.RaisePropertyChanged("INV_LastUpdatedTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime INV_LeadTime
        {
            get
            {
                return this.INV_LeadTimeField;
            }
            set
            {
                if ((this.INV_LeadTimeField.Equals(value) != true))
                {
                    this.INV_LeadTimeField = value;
                    this.RaisePropertyChanged("INV_LeadTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_MinimumOrderQuantity
        {
            get
            {
                return this.INV_MinimumOrderQuantityField;
            }
            set
            {
                if ((this.INV_MinimumOrderQuantityField.Equals(value) != true))
                {
                    this.INV_MinimumOrderQuantityField = value;
                    this.RaisePropertyChanged("INV_MinimumOrderQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_QuantityPerUnit
        {
            get
            {
                return this.INV_QuantityPerUnitField;
            }
            set
            {
                if ((this.INV_QuantityPerUnitField.Equals(value) != true))
                {
                    this.INV_QuantityPerUnitField = value;
                    this.RaisePropertyChanged("INV_QuantityPerUnit");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_RequestedQuantity
        {
            get
            {
                return this.INV_RequestedQuantityField;
            }
            set
            {
                if ((this.INV_RequestedQuantityField.Equals(value) != true))
                {
                    this.INV_RequestedQuantityField = value;
                    this.RaisePropertyChanged("INV_RequestedQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_UnitOfMeasure
        {
            get
            {
                return this.INV_UnitOfMeasureField;
            }
            set
            {
                if ((this.INV_UnitOfMeasureField.Equals(value) != true))
                {
                    this.INV_UnitOfMeasureField = value;
                    this.RaisePropertyChanged("INV_UnitOfMeasure");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double INV_UnitPrice
        {
            get
            {
                return this.INV_UnitPriceField;
            }
            set
            {
                if ((this.INV_UnitPriceField.Equals(value) != true))
                {
                    this.INV_UnitPriceField = value;
                    this.RaisePropertyChanged("INV_UnitPrice");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_VendorPartyId
        {
            get
            {
                return this.INV_VendorPartyIdField;
            }
            set
            {
                if ((this.INV_VendorPartyIdField.Equals(value) != true))
                {
                    this.INV_VendorPartyIdField = value;
                    this.RaisePropertyChanged("INV_VendorPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_Address1
        {
            get
            {
                return this.LCT_Address1Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_Address1Field, value) != true))
                {
                    this.LCT_Address1Field = value;
                    this.RaisePropertyChanged("LCT_Address1");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_Address2
        {
            get
            {
                return this.LCT_Address2Field;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_Address2Field, value) != true))
                {
                    this.LCT_Address2Field = value;
                    this.RaisePropertyChanged("LCT_Address2");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_City
        {
            get
            {
                return this.LCT_CityField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_CityField, value) != true))
                {
                    this.LCT_CityField = value;
                    this.RaisePropertyChanged("LCT_City");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_CompanyName
        {
            get
            {
                return this.LCT_CompanyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_CompanyNameField, value) != true))
                {
                    this.LCT_CompanyNameField = value;
                    this.RaisePropertyChanged("LCT_CompanyName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_Contact
        {
            get
            {
                return this.LCT_ContactField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_ContactField, value) != true))
                {
                    this.LCT_ContactField = value;
                    this.RaisePropertyChanged("LCT_Contact");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_Country
        {
            get
            {
                return this.LCT_CountryField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_CountryField, value) != true))
                {
                    this.LCT_CountryField = value;
                    this.RaisePropertyChanged("LCT_Country");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int LCT_LocationId
        {
            get
            {
                return this.LCT_LocationIdField;
            }
            set
            {
                if ((this.LCT_LocationIdField.Equals(value) != true))
                {
                    this.LCT_LocationIdField = value;
                    this.RaisePropertyChanged("LCT_LocationId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_Province
        {
            get
            {
                return this.LCT_ProvinceField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_ProvinceField, value) != true))
                {
                    this.LCT_ProvinceField = value;
                    this.RaisePropertyChanged("LCT_Province");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_State
        {
            get
            {
                return this.LCT_StateField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_StateField, value) != true))
                {
                    this.LCT_StateField = value;
                    this.RaisePropertyChanged("LCT_State");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LCT_ZipCode
        {
            get
            {
                return this.LCT_ZipCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LCT_ZipCodeField, value) != true))
                {
                    this.LCT_ZipCodeField = value;
                    this.RaisePropertyChanged("LCT_ZipCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRB_BrandId
        {
            get
            {
                return this.PRB_BrandIdField;
            }
            set
            {
                if ((this.PRB_BrandIdField.Equals(value) != true))
                {
                    this.PRB_BrandIdField = value;
                    this.RaisePropertyChanged("PRB_BrandId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRB_BrandName
        {
            get
            {
                return this.PRB_BrandNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRB_BrandNameField, value) != true))
                {
                    this.PRB_BrandNameField = value;
                    this.RaisePropertyChanged("PRB_BrandName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRB_ParentCompany
        {
            get
            {
                return this.PRB_ParentCompanyField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRB_ParentCompanyField, value) != true))
                {
                    this.PRB_ParentCompanyField = value;
                    this.RaisePropertyChanged("PRB_ParentCompany");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRC_CategoryId
        {
            get
            {
                return this.PRC_CategoryIdField;
            }
            set
            {
                if ((this.PRC_CategoryIdField.Equals(value) != true))
                {
                    this.PRC_CategoryIdField = value;
                    this.RaisePropertyChanged("PRC_CategoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRC_CategoryName
        {
            get
            {
                return this.PRC_CategoryNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRC_CategoryNameField, value) != true))
                {
                    this.PRC_CategoryNameField = value;
                    this.RaisePropertyChanged("PRC_CategoryName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRC_Description
        {
            get
            {
                return this.PRC_DescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRC_DescriptionField, value) != true))
                {
                    this.PRC_DescriptionField = value;
                    this.RaisePropertyChanged("PRC_Description");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_Color
        {
            get
            {
                return this.PRD_ColorField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_ColorField, value) != true))
                {
                    this.PRD_ColorField = value;
                    this.RaisePropertyChanged("PRD_Color");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PRD_HazzardIndicator
        {
            get
            {
                return this.PRD_HazzardIndicatorField;
            }
            set
            {
                if ((this.PRD_HazzardIndicatorField.Equals(value) != true))
                {
                    this.PRD_HazzardIndicatorField = value;
                    this.RaisePropertyChanged("PRD_HazzardIndicator");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_MakeNumber
        {
            get
            {
                return this.PRD_MakeNumberField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_MakeNumberField, value) != true))
                {
                    this.PRD_MakeNumberField = value;
                    this.RaisePropertyChanged("PRD_MakeNumber");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_ModelNumber
        {
            get
            {
                return this.PRD_ModelNumberField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_ModelNumberField, value) != true))
                {
                    this.PRD_ModelNumberField = value;
                    this.RaisePropertyChanged("PRD_ModelNumber");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_ModelYear
        {
            get
            {
                return this.PRD_ModelYearField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_ModelYearField, value) != true))
                {
                    this.PRD_ModelYearField = value;
                    this.RaisePropertyChanged("PRD_ModelYear");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRD_PictureURL
        {
            get
            {
                return this.PRD_PictureURLField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRD_PictureURLField, value) != true))
                {
                    this.PRD_PictureURLField = value;
                    this.RaisePropertyChanged("PRD_PictureURL");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRD_Ranking
        {
            get
            {
                return this.PRD_RankingField;
            }
            set
            {
                if ((this.PRD_RankingField.Equals(value) != true))
                {
                    this.PRD_RankingField = value;
                    this.RaisePropertyChanged("PRD_Ranking");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRD_Size
        {
            get
            {
                return this.PRD_SizeField;
            }
            set
            {
                if ((this.PRD_SizeField.Equals(value) != true))
                {
                    this.PRD_SizeField = value;
                    this.RaisePropertyChanged("PRD_Size");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRS_ProductStatusCode
        {
            get
            {
                return this.PRS_ProductStatusCodeField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRS_ProductStatusCodeField, value) != true))
                {
                    this.PRS_ProductStatusCodeField = value;
                    this.RaisePropertyChanged("PRS_ProductStatusCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRS_ProductStatusId
        {
            get
            {
                return this.PRS_ProductStatusIdField;
            }
            set
            {
                if ((this.PRS_ProductStatusIdField.Equals(value) != true))
                {
                    this.PRS_ProductStatusIdField = value;
                    this.RaisePropertyChanged("PRS_ProductStatusId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRS_ProductStatusName
        {
            get
            {
                return this.PRS_ProductStatusNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRS_ProductStatusNameField, value) != true))
                {
                    this.PRS_ProductStatusNameField = value;
                    this.RaisePropertyChanged("PRS_ProductStatusName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRUOM_GTINPackLevel
        {
            get
            {
                return this.PRUOM_GTINPackLevelField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRUOM_GTINPackLevelField, value) != true))
                {
                    this.PRUOM_GTINPackLevelField = value;
                    this.RaisePropertyChanged("PRUOM_GTINPackLevel");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PRUOM_UOMCode
        {
            get
            {
                return this.PRUOM_UOMCodeField;
            }
            set
            {
                if ((this.PRUOM_UOMCodeField.Equals(value) != true))
                {
                    this.PRUOM_UOMCodeField = value;
                    this.RaisePropertyChanged("PRUOM_UOMCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PRUOM_UOMDescription
        {
            get
            {
                return this.PRUOM_UOMDescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRUOM_UOMDescriptionField, value) != true))
                {
                    this.PRUOM_UOMDescriptionField = value;
                    this.RaisePropertyChanged("PRUOM_UOMDescription");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_BrandCode
        {
            get
            {
                return this.PR_BrandCodeField;
            }
            set
            {
                if ((this.PR_BrandCodeField.Equals(value) != true))
                {
                    this.PR_BrandCodeField = value;
                    this.RaisePropertyChanged("PR_BrandCode");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_BrandName
        {
            get
            {
                return this.PR_BrandNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_BrandNameField, value) != true))
                {
                    this.PR_BrandNameField = value;
                    this.RaisePropertyChanged("PR_BrandName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_CatalogPartNum
        {
            get
            {
                return this.PR_CatalogPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_CatalogPartNumField, value) != true))
                {
                    this.PR_CatalogPartNumField = value;
                    this.RaisePropertyChanged("PR_CatalogPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_CategoryId
        {
            get
            {
                return this.PR_CategoryIdField;
            }
            set
            {
                if ((this.PR_CategoryIdField.Equals(value) != true))
                {
                    this.PR_CategoryIdField = value;
                    this.RaisePropertyChanged("PR_CategoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_CategoryName
        {
            get
            {
                return this.PR_CategoryNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_CategoryNameField, value) != true))
                {
                    this.PR_CategoryNameField = value;
                    this.RaisePropertyChanged("PR_CategoryName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_CountryOfOrigin
        {
            get
            {
                return this.PR_CountryOfOriginField;
            }
            set
            {
                if ((this.PR_CountryOfOriginField.Equals(value) != true))
                {
                    this.PR_CountryOfOriginField = value;
                    this.RaisePropertyChanged("PR_CountryOfOrigin");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_IndustryPartNum
        {
            get
            {
                return this.PR_IndustryPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_IndustryPartNumField, value) != true))
                {
                    this.PR_IndustryPartNumField = value;
                    this.RaisePropertyChanged("PR_IndustryPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime PR_LastUpdatedTime
        {
            get
            {
                return this.PR_LastUpdatedTimeField;
            }
            set
            {
                if ((this.PR_LastUpdatedTimeField.Equals(value) != true))
                {
                    this.PR_LastUpdatedTimeField = value;
                    this.RaisePropertyChanged("PR_LastUpdatedTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_ManufacturerPartNum
        {
            get
            {
                return this.PR_ManufacturerPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ManufacturerPartNumField, value) != true))
                {
                    this.PR_ManufacturerPartNumField = value;
                    this.RaisePropertyChanged("PR_ManufacturerPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_Note
        {
            get
            {
                return this.PR_NoteField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_NoteField, value) != true))
                {
                    this.PR_NoteField = value;
                    this.RaisePropertyChanged("PR_Note");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_PartOwnerId
        {
            get
            {
                return this.PR_PartOwnerIdField;
            }
            set
            {
                if ((this.PR_PartOwnerIdField.Equals(value) != true))
                {
                    this.PR_PartOwnerIdField = value;
                    this.RaisePropertyChanged("PR_PartOwnerId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_ProductDescription
        {
            get
            {
                return this.PR_ProductDescriptionField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ProductDescriptionField, value) != true))
                {
                    this.PR_ProductDescriptionField = value;
                    this.RaisePropertyChanged("PR_ProductDescription");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_ProductID
        {
            get
            {
                return this.PR_ProductIDField;
            }
            set
            {
                if ((this.PR_ProductIDField.Equals(value) != true))
                {
                    this.PR_ProductIDField = value;
                    this.RaisePropertyChanged("PR_ProductID");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_ProductName
        {
            get
            {
                return this.PR_ProductNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ProductNameField, value) != true))
                {
                    this.PR_ProductNameField = value;
                    this.RaisePropertyChanged("PR_ProductName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_ProductStatusId
        {
            get
            {
                return this.PR_ProductStatusIdField;
            }
            set
            {
                if ((this.PR_ProductStatusIdField.Equals(value) != true))
                {
                    this.PR_ProductStatusIdField = value;
                    this.RaisePropertyChanged("PR_ProductStatusId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_ProductStatusName
        {
            get
            {
                return this.PR_ProductStatusNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ProductStatusNameField, value) != true))
                {
                    this.PR_ProductStatusNameField = value;
                    this.RaisePropertyChanged("PR_ProductStatusName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_SupersededPartNum
        {
            get
            {
                return this.PR_SupersededPartNumField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_SupersededPartNumField, value) != true))
                {
                    this.PR_SupersededPartNumField = value;
                    this.RaisePropertyChanged("PR_SupersededPartNum");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PR_UOMWeight
        {
            get
            {
                return this.PR_UOMWeightField;
            }
            set
            {
                if ((this.PR_UOMWeightField.Equals(value) != true))
                {
                    this.PR_UOMWeightField = value;
                    this.RaisePropertyChanged("PR_UOMWeight");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PR_UPC_Code_GTIN
        {
            get
            {
                return this.PR_UPC_Code_GTINField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_UPC_Code_GTINField, value) != true))
                {
                    this.PR_UPC_Code_GTINField = value;
                    this.RaisePropertyChanged("PR_UPC_Code_GTIN");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PR_UnitHeight
        {
            get
            {
                return this.PR_UnitHeightField;
            }
            set
            {
                if ((this.PR_UnitHeightField.Equals(value) != true))
                {
                    this.PR_UnitHeightField = value;
                    this.RaisePropertyChanged("PR_UnitHeight");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PR_UnitLength
        {
            get
            {
                return this.PR_UnitLengthField;
            }
            set
            {
                if ((this.PR_UnitLengthField.Equals(value) != true))
                {
                    this.PR_UnitLengthField = value;
                    this.RaisePropertyChanged("PR_UnitLength");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double PR_UnitWeight
        {
            get
            {
                return this.PR_UnitWeightField;
            }
            set
            {
                if ((this.PR_UnitWeightField.Equals(value) != true))
                {
                    this.PR_UnitWeightField = value;
                    this.RaisePropertyChanged("PR_UnitWeight");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_CurrencyId
        {
            get
            {
                return this.PTY_CurrencyIdField;
            }
            set
            {
                if ((this.PTY_CurrencyIdField.Equals(value) != true))
                {
                    this.PTY_CurrencyIdField = value;
                    this.RaisePropertyChanged("PTY_CurrencyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTY_CurrencyName
        {
            get
            {
                return this.PTY_CurrencyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_CurrencyNameField, value) != true))
                {
                    this.PTY_CurrencyNameField = value;
                    this.RaisePropertyChanged("PTY_CurrencyName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_LanguageId
        {
            get
            {
                return this.PTY_LanguageIdField;
            }
            set
            {
                if ((this.PTY_LanguageIdField.Equals(value) != true))
                {
                    this.PTY_LanguageIdField = value;
                    this.RaisePropertyChanged("PTY_LanguageId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTY_LanguageName
        {
            get
            {
                return this.PTY_LanguageNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_LanguageNameField, value) != true))
                {
                    this.PTY_LanguageNameField = value;
                    this.RaisePropertyChanged("PTY_LanguageName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PTY_PartyId
        {
            get
            {
                return this.PTY_PartyIdField;
            }
            set
            {
                if ((this.PTY_PartyIdField.Equals(value) != true))
                {
                    this.PTY_PartyIdField = value;
                    this.RaisePropertyChanged("PTY_PartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PTY_PartyName
        {
            get
            {
                return this.PTY_PartyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyNameField, value) != true))
                {
                    this.PTY_PartyNameField = value;
                    this.RaisePropertyChanged("PTY_PartyName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool PTY_ShowAdjustedQuantity
        {
            get
            {
                return this.PTY_ShowAdjustedQuantityField;
            }
            set
            {
                if ((this.PTY_ShowAdjustedQuantityField.Equals(value) != true))
                {
                    this.PTY_ShowAdjustedQuantityField = value;
                    this.RaisePropertyChanged("PTY_ShowAdjustedQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SearchPart
        {
            get
            {
                return this.SearchPartField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SearchPartField, value) != true))
                {
                    this.SearchPartField = value;
                    this.RaisePropertyChanged("SearchPart");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SearchPartyId
        {
            get
            {
                return this.SearchPartyIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SearchPartyIdField, value) != true))
                {
                    this.SearchPartyIdField = value;
                    this.RaisePropertyChanged("SearchPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SearchPartyName
        {
            get
            {
                return this.SearchPartyNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SearchPartyNameField, value) != true))
                {
                    this.SearchPartyNameField = value;
                    this.RaisePropertyChanged("SearchPartyName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SearchQty
        {
            get
            {
                return this.SearchQtyField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SearchQtyField, value) != true))
                {
                    this.SearchQtyField = value;
                    this.RaisePropertyChanged("SearchQty");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AuthorizationData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class AuthorizationData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AuthorizationInventoryGroupsData_DTO ATHIG_AuthorizationInventoryGroupDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private AuthorizationPartyGroupsData_DTO ATHPG_AuthorizationPartyGroupDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_AuthorizationIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_BuyerGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_BuyerPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_Fixed_QuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_InventoryGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_InventoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_Max_QuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_Min_QuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_QuantityRequiredField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_ShowAvailableQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_ShowUnitPriceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_ShowYesNoField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_VendorPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private InventoryData_DTO INV_InventoryDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public AuthorizationInventoryGroupsData_DTO ATHIG_AuthorizationInventoryGroupDataObj
        {
            get
            {
                return this.ATHIG_AuthorizationInventoryGroupDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHIG_AuthorizationInventoryGroupDataObjField, value) != true))
                {
                    this.ATHIG_AuthorizationInventoryGroupDataObjField = value;
                    this.RaisePropertyChanged("ATHIG_AuthorizationInventoryGroupDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public AuthorizationPartyGroupsData_DTO ATHPG_AuthorizationPartyGroupDataObj
        {
            get
            {
                return this.ATHPG_AuthorizationPartyGroupDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHPG_AuthorizationPartyGroupDataObjField, value) != true))
                {
                    this.ATHPG_AuthorizationPartyGroupDataObjField = value;
                    this.RaisePropertyChanged("ATHPG_AuthorizationPartyGroupDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_AuthorizationId
        {
            get
            {
                return this.ATH_AuthorizationIdField;
            }
            set
            {
                if ((this.ATH_AuthorizationIdField.Equals(value) != true))
                {
                    this.ATH_AuthorizationIdField = value;
                    this.RaisePropertyChanged("ATH_AuthorizationId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_BuyerGroupId
        {
            get
            {
                return this.ATH_BuyerGroupIdField;
            }
            set
            {
                if ((this.ATH_BuyerGroupIdField.Equals(value) != true))
                {
                    this.ATH_BuyerGroupIdField = value;
                    this.RaisePropertyChanged("ATH_BuyerGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_BuyerPartyId
        {
            get
            {
                return this.ATH_BuyerPartyIdField;
            }
            set
            {
                if ((this.ATH_BuyerPartyIdField.Equals(value) != true))
                {
                    this.ATH_BuyerPartyIdField = value;
                    this.RaisePropertyChanged("ATH_BuyerPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_Fixed_Quantity
        {
            get
            {
                return this.ATH_Fixed_QuantityField;
            }
            set
            {
                if ((this.ATH_Fixed_QuantityField.Equals(value) != true))
                {
                    this.ATH_Fixed_QuantityField = value;
                    this.RaisePropertyChanged("ATH_Fixed_Quantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_InventoryGroupId
        {
            get
            {
                return this.ATH_InventoryGroupIdField;
            }
            set
            {
                if ((this.ATH_InventoryGroupIdField.Equals(value) != true))
                {
                    this.ATH_InventoryGroupIdField = value;
                    this.RaisePropertyChanged("ATH_InventoryGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_InventoryId
        {
            get
            {
                return this.ATH_InventoryIdField;
            }
            set
            {
                if ((this.ATH_InventoryIdField.Equals(value) != true))
                {
                    this.ATH_InventoryIdField = value;
                    this.RaisePropertyChanged("ATH_InventoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_Max_Quantity
        {
            get
            {
                return this.ATH_Max_QuantityField;
            }
            set
            {
                if ((this.ATH_Max_QuantityField.Equals(value) != true))
                {
                    this.ATH_Max_QuantityField = value;
                    this.RaisePropertyChanged("ATH_Max_Quantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_Min_Quantity
        {
            get
            {
                return this.ATH_Min_QuantityField;
            }
            set
            {
                if ((this.ATH_Min_QuantityField.Equals(value) != true))
                {
                    this.ATH_Min_QuantityField = value;
                    this.RaisePropertyChanged("ATH_Min_Quantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_QuantityRequired
        {
            get
            {
                return this.ATH_QuantityRequiredField;
            }
            set
            {
                if ((this.ATH_QuantityRequiredField.Equals(value) != true))
                {
                    this.ATH_QuantityRequiredField = value;
                    this.RaisePropertyChanged("ATH_QuantityRequired");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_ShowAvailableQuantity
        {
            get
            {
                return this.ATH_ShowAvailableQuantityField;
            }
            set
            {
                if ((this.ATH_ShowAvailableQuantityField.Equals(value) != true))
                {
                    this.ATH_ShowAvailableQuantityField = value;
                    this.RaisePropertyChanged("ATH_ShowAvailableQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_ShowUnitPrice
        {
            get
            {
                return this.ATH_ShowUnitPriceField;
            }
            set
            {
                if ((this.ATH_ShowUnitPriceField.Equals(value) != true))
                {
                    this.ATH_ShowUnitPriceField = value;
                    this.RaisePropertyChanged("ATH_ShowUnitPrice");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_ShowYesNo
        {
            get
            {
                return this.ATH_ShowYesNoField;
            }
            set
            {
                if ((this.ATH_ShowYesNoField.Equals(value) != true))
                {
                    this.ATH_ShowYesNoField = value;
                    this.RaisePropertyChanged("ATH_ShowYesNo");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_VendorPartyId
        {
            get
            {
                return this.ATH_VendorPartyIdField;
            }
            set
            {
                if ((this.ATH_VendorPartyIdField.Equals(value) != true))
                {
                    this.ATH_VendorPartyIdField = value;
                    this.RaisePropertyChanged("ATH_VendorPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public InventoryData_DTO INV_InventoryDataObj
        {
            get
            {
                return this.INV_InventoryDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.INV_InventoryDataObjField, value) != true))
                {
                    this.INV_InventoryDataObjField = value;
                    this.RaisePropertyChanged("INV_InventoryDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AuthorizationInventoryGroupsData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class AuthorizationInventoryGroupsData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHIG_InventoryGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHIG_InventoryGroupNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHIG_VendorPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHIG_InventoryGroupId
        {
            get
            {
                return this.ATHIG_InventoryGroupIdField;
            }
            set
            {
                if ((this.ATHIG_InventoryGroupIdField.Equals(value) != true))
                {
                    this.ATHIG_InventoryGroupIdField = value;
                    this.RaisePropertyChanged("ATHIG_InventoryGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHIG_InventoryGroupName
        {
            get
            {
                return this.ATHIG_InventoryGroupNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHIG_InventoryGroupNameField, value) != true))
                {
                    this.ATHIG_InventoryGroupNameField = value;
                    this.RaisePropertyChanged("ATHIG_InventoryGroupName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHIG_VendorPartyId
        {
            get
            {
                return this.ATHIG_VendorPartyIdField;
            }
            set
            {
                if ((this.ATHIG_VendorPartyIdField.Equals(value) != true))
                {
                    this.ATHIG_VendorPartyIdField = value;
                    this.RaisePropertyChanged("ATHIG_VendorPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AuthorizationPartyGroupsData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class AuthorizationPartyGroupsData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHPG_PartyGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHPG_PartyGroupNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHPG_VendorPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHPG_PartyGroupId
        {
            get
            {
                return this.ATHPG_PartyGroupIdField;
            }
            set
            {
                if ((this.ATHPG_PartyGroupIdField.Equals(value) != true))
                {
                    this.ATHPG_PartyGroupIdField = value;
                    this.RaisePropertyChanged("ATHPG_PartyGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHPG_PartyGroupName
        {
            get
            {
                return this.ATHPG_PartyGroupNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHPG_PartyGroupNameField, value) != true))
                {
                    this.ATHPG_PartyGroupNameField = value;
                    this.RaisePropertyChanged("ATHPG_PartyGroupName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHPG_VendorPartyId
        {
            get
            {
                return this.ATHPG_VendorPartyIdField;
            }
            set
            {
                if ((this.ATHPG_VendorPartyIdField.Equals(value) != true))
                {
                    this.ATHPG_VendorPartyIdField = value;
                    this.RaisePropertyChanged("ATHPG_VendorPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "InventoryData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class InventoryData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private CurrencyData_DTO CUR_CurrencyObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_AdjustedAvailableQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_AvailableQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double INV_BreakPackPriceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool INV_BuiltOrderField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_CurrencyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool INV_DropShipmentField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_InventoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime INV_LastUpdatedTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime INV_LeadTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_MinimumOrderQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_ProductIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_QuantityPerUnitField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_RequestedQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_UnitOfMeasureField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double INV_UnitPriceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int INV_VendorPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private LocationData_DTO LOC_LocationDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProductPartyLocation_DTO PPL_ProductPartyLocationObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private UOMTypesData_DTO PRUOM_ProductUOMObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ProductData_DTO PR_ProductDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public CurrencyData_DTO CUR_CurrencyObj
        {
            get
            {
                return this.CUR_CurrencyObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.CUR_CurrencyObjField, value) != true))
                {
                    this.CUR_CurrencyObjField = value;
                    this.RaisePropertyChanged("CUR_CurrencyObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_AdjustedAvailableQuantity
        {
            get
            {
                return this.INV_AdjustedAvailableQuantityField;
            }
            set
            {
                if ((this.INV_AdjustedAvailableQuantityField.Equals(value) != true))
                {
                    this.INV_AdjustedAvailableQuantityField = value;
                    this.RaisePropertyChanged("INV_AdjustedAvailableQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_AvailableQuantity
        {
            get
            {
                return this.INV_AvailableQuantityField;
            }
            set
            {
                if ((this.INV_AvailableQuantityField.Equals(value) != true))
                {
                    this.INV_AvailableQuantityField = value;
                    this.RaisePropertyChanged("INV_AvailableQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double INV_BreakPackPrice
        {
            get
            {
                return this.INV_BreakPackPriceField;
            }
            set
            {
                if ((this.INV_BreakPackPriceField.Equals(value) != true))
                {
                    this.INV_BreakPackPriceField = value;
                    this.RaisePropertyChanged("INV_BreakPackPrice");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool INV_BuiltOrder
        {
            get
            {
                return this.INV_BuiltOrderField;
            }
            set
            {
                if ((this.INV_BuiltOrderField.Equals(value) != true))
                {
                    this.INV_BuiltOrderField = value;
                    this.RaisePropertyChanged("INV_BuiltOrder");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_CurrencyId
        {
            get
            {
                return this.INV_CurrencyIdField;
            }
            set
            {
                if ((this.INV_CurrencyIdField.Equals(value) != true))
                {
                    this.INV_CurrencyIdField = value;
                    this.RaisePropertyChanged("INV_CurrencyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool INV_DropShipment
        {
            get
            {
                return this.INV_DropShipmentField;
            }
            set
            {
                if ((this.INV_DropShipmentField.Equals(value) != true))
                {
                    this.INV_DropShipmentField = value;
                    this.RaisePropertyChanged("INV_DropShipment");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_InventoryId
        {
            get
            {
                return this.INV_InventoryIdField;
            }
            set
            {
                if ((this.INV_InventoryIdField.Equals(value) != true))
                {
                    this.INV_InventoryIdField = value;
                    this.RaisePropertyChanged("INV_InventoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime INV_LastUpdatedTime
        {
            get
            {
                return this.INV_LastUpdatedTimeField;
            }
            set
            {
                if ((this.INV_LastUpdatedTimeField.Equals(value) != true))
                {
                    this.INV_LastUpdatedTimeField = value;
                    this.RaisePropertyChanged("INV_LastUpdatedTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime INV_LeadTime
        {
            get
            {
                return this.INV_LeadTimeField;
            }
            set
            {
                if ((this.INV_LeadTimeField.Equals(value) != true))
                {
                    this.INV_LeadTimeField = value;
                    this.RaisePropertyChanged("INV_LeadTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_MinimumOrderQuantity
        {
            get
            {
                return this.INV_MinimumOrderQuantityField;
            }
            set
            {
                if ((this.INV_MinimumOrderQuantityField.Equals(value) != true))
                {
                    this.INV_MinimumOrderQuantityField = value;
                    this.RaisePropertyChanged("INV_MinimumOrderQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_ProductId
        {
            get
            {
                return this.INV_ProductIdField;
            }
            set
            {
                if ((this.INV_ProductIdField.Equals(value) != true))
                {
                    this.INV_ProductIdField = value;
                    this.RaisePropertyChanged("INV_ProductId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_QuantityPerUnit
        {
            get
            {
                return this.INV_QuantityPerUnitField;
            }
            set
            {
                if ((this.INV_QuantityPerUnitField.Equals(value) != true))
                {
                    this.INV_QuantityPerUnitField = value;
                    this.RaisePropertyChanged("INV_QuantityPerUnit");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_RequestedQuantity
        {
            get
            {
                return this.INV_RequestedQuantityField;
            }
            set
            {
                if ((this.INV_RequestedQuantityField.Equals(value) != true))
                {
                    this.INV_RequestedQuantityField = value;
                    this.RaisePropertyChanged("INV_RequestedQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_UnitOfMeasure
        {
            get
            {
                return this.INV_UnitOfMeasureField;
            }
            set
            {
                if ((this.INV_UnitOfMeasureField.Equals(value) != true))
                {
                    this.INV_UnitOfMeasureField = value;
                    this.RaisePropertyChanged("INV_UnitOfMeasure");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public double INV_UnitPrice
        {
            get
            {
                return this.INV_UnitPriceField;
            }
            set
            {
                if ((this.INV_UnitPriceField.Equals(value) != true))
                {
                    this.INV_UnitPriceField = value;
                    this.RaisePropertyChanged("INV_UnitPrice");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int INV_VendorPartyId
        {
            get
            {
                return this.INV_VendorPartyIdField;
            }
            set
            {
                if ((this.INV_VendorPartyIdField.Equals(value) != true))
                {
                    this.INV_VendorPartyIdField = value;
                    this.RaisePropertyChanged("INV_VendorPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public LocationData_DTO LOC_LocationDataObj
        {
            get
            {
                return this.LOC_LocationDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.LOC_LocationDataObjField, value) != true))
                {
                    this.LOC_LocationDataObjField = value;
                    this.RaisePropertyChanged("LOC_LocationDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProductPartyLocation_DTO PPL_ProductPartyLocationObj
        {
            get
            {
                return this.PPL_ProductPartyLocationObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PPL_ProductPartyLocationObjField, value) != true))
                {
                    this.PPL_ProductPartyLocationObjField = value;
                    this.RaisePropertyChanged("PPL_ProductPartyLocationObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public UOMTypesData_DTO PRUOM_ProductUOMObj
        {
            get
            {
                return this.PRUOM_ProductUOMObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PRUOM_ProductUOMObjField, value) != true))
                {
                    this.PRUOM_ProductUOMObjField = value;
                    this.RaisePropertyChanged("PRUOM_ProductUOMObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProductData_DTO PR_ProductDataObj
        {
            get
            {
                return this.PR_ProductDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PR_ProductDataObjField, value) != true))
                {
                    this.PR_ProductDataObjField = value;
                    this.RaisePropertyChanged("PR_ProductDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "QuoteData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class QuoteData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private QuoteStatusDataED QTS_QuoteStatusObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QT_BuyerPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QT_QuoteIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime QT_QuoteRequestedTimeField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QT_QuoteStatusIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QT_VendorPartyIdField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public QuoteStatusDataED QTS_QuoteStatusObj
        {
            get
            {
                return this.QTS_QuoteStatusObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QTS_QuoteStatusObjField, value) != true))
                {
                    this.QTS_QuoteStatusObjField = value;
                    this.RaisePropertyChanged("QTS_QuoteStatusObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QT_BuyerPartyId
        {
            get
            {
                return this.QT_BuyerPartyIdField;
            }
            set
            {
                if ((this.QT_BuyerPartyIdField.Equals(value) != true))
                {
                    this.QT_BuyerPartyIdField = value;
                    this.RaisePropertyChanged("QT_BuyerPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QT_QuoteId
        {
            get
            {
                return this.QT_QuoteIdField;
            }
            set
            {
                if ((this.QT_QuoteIdField.Equals(value) != true))
                {
                    this.QT_QuoteIdField = value;
                    this.RaisePropertyChanged("QT_QuoteId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime QT_QuoteRequestedTime
        {
            get
            {
                return this.QT_QuoteRequestedTimeField;
            }
            set
            {
                if ((this.QT_QuoteRequestedTimeField.Equals(value) != true))
                {
                    this.QT_QuoteRequestedTimeField = value;
                    this.RaisePropertyChanged("QT_QuoteRequestedTime");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QT_QuoteStatusId
        {
            get
            {
                return this.QT_QuoteStatusIdField;
            }
            set
            {
                if ((this.QT_QuoteStatusIdField.Equals(value) != true))
                {
                    this.QT_QuoteStatusIdField = value;
                    this.RaisePropertyChanged("QT_QuoteStatusId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QT_VendorPartyId
        {
            get
            {
                return this.QT_VendorPartyIdField;
            }
            set
            {
                if ((this.QT_VendorPartyIdField.Equals(value) != true))
                {
                    this.QT_VendorPartyIdField = value;
                    this.RaisePropertyChanged("QT_VendorPartyId");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "QuoteStatusDataED", Namespace = "http://schemas.datacontract.org/2004/07/Contoso.Cloud.Data.EntityData.Store")]
    [System.SerializableAttribute()]
    internal partial class QuoteStatusDataED : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QTS_QuoteStatusIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QTS_StatusNameField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QTS_QuoteStatusId
        {
            get
            {
                return this.QTS_QuoteStatusIdField;
            }
            set
            {
                if ((this.QTS_QuoteStatusIdField.Equals(value) != true))
                {
                    this.QTS_QuoteStatusIdField = value;
                    this.RaisePropertyChanged("QTS_QuoteStatusId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string QTS_StatusName
        {
            get
            {
                return this.QTS_StatusNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QTS_StatusNameField, value) != true))
                {
                    this.QTS_StatusNameField = value;
                    this.RaisePropertyChanged("QTS_StatusName");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "QuoteSearch_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class QuoteSearch_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private QuoteDetailData_DTO[] QTD_QuoteDetailListField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private QuoteData_DTO QT_QuoteObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public QuoteDetailData_DTO[] QTD_QuoteDetailList
        {
            get
            {
                return this.QTD_QuoteDetailListField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QTD_QuoteDetailListField, value) != true))
                {
                    this.QTD_QuoteDetailListField = value;
                    this.RaisePropertyChanged("QTD_QuoteDetailList");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public QuoteData_DTO QT_QuoteObj
        {
            get
            {
                return this.QT_QuoteObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QT_QuoteObjField, value) != true))
                {
                    this.QT_QuoteObjField = value;
                    this.RaisePropertyChanged("QT_QuoteObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "QuoteDetailData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class QuoteDetailData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private InventoryData_DTO Inv_InventoryObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QTD_InventoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QTD_QuoteDetailIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QTD_QuoteIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QTD_QuoteStatusIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QTD_RequestedQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private QuoteStatusDataED QTS_QuoteStatusObjField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private QuoteData_DTO QT_QuoteObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public InventoryData_DTO Inv_InventoryObj
        {
            get
            {
                return this.Inv_InventoryObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.Inv_InventoryObjField, value) != true))
                {
                    this.Inv_InventoryObjField = value;
                    this.RaisePropertyChanged("Inv_InventoryObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QTD_InventoryId
        {
            get
            {
                return this.QTD_InventoryIdField;
            }
            set
            {
                if ((this.QTD_InventoryIdField.Equals(value) != true))
                {
                    this.QTD_InventoryIdField = value;
                    this.RaisePropertyChanged("QTD_InventoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QTD_QuoteDetailId
        {
            get
            {
                return this.QTD_QuoteDetailIdField;
            }
            set
            {
                if ((this.QTD_QuoteDetailIdField.Equals(value) != true))
                {
                    this.QTD_QuoteDetailIdField = value;
                    this.RaisePropertyChanged("QTD_QuoteDetailId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QTD_QuoteId
        {
            get
            {
                return this.QTD_QuoteIdField;
            }
            set
            {
                if ((this.QTD_QuoteIdField.Equals(value) != true))
                {
                    this.QTD_QuoteIdField = value;
                    this.RaisePropertyChanged("QTD_QuoteId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QTD_QuoteStatusId
        {
            get
            {
                return this.QTD_QuoteStatusIdField;
            }
            set
            {
                if ((this.QTD_QuoteStatusIdField.Equals(value) != true))
                {
                    this.QTD_QuoteStatusIdField = value;
                    this.RaisePropertyChanged("QTD_QuoteStatusId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int QTD_RequestedQuantity
        {
            get
            {
                return this.QTD_RequestedQuantityField;
            }
            set
            {
                if ((this.QTD_RequestedQuantityField.Equals(value) != true))
                {
                    this.QTD_RequestedQuantityField = value;
                    this.RaisePropertyChanged("QTD_RequestedQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public QuoteStatusDataED QTS_QuoteStatusObj
        {
            get
            {
                return this.QTS_QuoteStatusObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QTS_QuoteStatusObjField, value) != true))
                {
                    this.QTS_QuoteStatusObjField = value;
                    this.RaisePropertyChanged("QTS_QuoteStatusObj");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public QuoteData_DTO QT_QuoteObj
        {
            get
            {
                return this.QT_QuoteObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.QT_QuoteObjField, value) != true))
                {
                    this.QT_QuoteObjField = value;
                    this.RaisePropertyChanged("QT_QuoteObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AuthorizationRulesSearch_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class AuthorizationRulesSearch_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHIG_InventoryGroupNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHPG_PartyGroupNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHPG_ProductIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHPG_ProductNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_AuthorizationIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_BuyerGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_BuyerPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_Fixed_QuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_InventoryGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_InventoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_Max_QuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_Min_QuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_QuantityRequiredField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_ShowAvailableQuantityField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_ShowUnitPriceField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ATH_ShowYesNoField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATH_VendorPartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SearchPartyIdField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHIG_InventoryGroupName
        {
            get
            {
                return this.ATHIG_InventoryGroupNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHIG_InventoryGroupNameField, value) != true))
                {
                    this.ATHIG_InventoryGroupNameField = value;
                    this.RaisePropertyChanged("ATHIG_InventoryGroupName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHPG_PartyGroupName
        {
            get
            {
                return this.ATHPG_PartyGroupNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHPG_PartyGroupNameField, value) != true))
                {
                    this.ATHPG_PartyGroupNameField = value;
                    this.RaisePropertyChanged("ATHPG_PartyGroupName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHPG_ProductId
        {
            get
            {
                return this.ATHPG_ProductIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHPG_ProductIdField, value) != true))
                {
                    this.ATHPG_ProductIdField = value;
                    this.RaisePropertyChanged("ATHPG_ProductId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHPG_ProductName
        {
            get
            {
                return this.ATHPG_ProductNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHPG_ProductNameField, value) != true))
                {
                    this.ATHPG_ProductNameField = value;
                    this.RaisePropertyChanged("ATHPG_ProductName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_AuthorizationId
        {
            get
            {
                return this.ATH_AuthorizationIdField;
            }
            set
            {
                if ((this.ATH_AuthorizationIdField.Equals(value) != true))
                {
                    this.ATH_AuthorizationIdField = value;
                    this.RaisePropertyChanged("ATH_AuthorizationId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_BuyerGroupId
        {
            get
            {
                return this.ATH_BuyerGroupIdField;
            }
            set
            {
                if ((this.ATH_BuyerGroupIdField.Equals(value) != true))
                {
                    this.ATH_BuyerGroupIdField = value;
                    this.RaisePropertyChanged("ATH_BuyerGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_BuyerPartyId
        {
            get
            {
                return this.ATH_BuyerPartyIdField;
            }
            set
            {
                if ((this.ATH_BuyerPartyIdField.Equals(value) != true))
                {
                    this.ATH_BuyerPartyIdField = value;
                    this.RaisePropertyChanged("ATH_BuyerPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_Fixed_Quantity
        {
            get
            {
                return this.ATH_Fixed_QuantityField;
            }
            set
            {
                if ((this.ATH_Fixed_QuantityField.Equals(value) != true))
                {
                    this.ATH_Fixed_QuantityField = value;
                    this.RaisePropertyChanged("ATH_Fixed_Quantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_InventoryGroupId
        {
            get
            {
                return this.ATH_InventoryGroupIdField;
            }
            set
            {
                if ((this.ATH_InventoryGroupIdField.Equals(value) != true))
                {
                    this.ATH_InventoryGroupIdField = value;
                    this.RaisePropertyChanged("ATH_InventoryGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_InventoryId
        {
            get
            {
                return this.ATH_InventoryIdField;
            }
            set
            {
                if ((this.ATH_InventoryIdField.Equals(value) != true))
                {
                    this.ATH_InventoryIdField = value;
                    this.RaisePropertyChanged("ATH_InventoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_Max_Quantity
        {
            get
            {
                return this.ATH_Max_QuantityField;
            }
            set
            {
                if ((this.ATH_Max_QuantityField.Equals(value) != true))
                {
                    this.ATH_Max_QuantityField = value;
                    this.RaisePropertyChanged("ATH_Max_Quantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_Min_Quantity
        {
            get
            {
                return this.ATH_Min_QuantityField;
            }
            set
            {
                if ((this.ATH_Min_QuantityField.Equals(value) != true))
                {
                    this.ATH_Min_QuantityField = value;
                    this.RaisePropertyChanged("ATH_Min_Quantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_QuantityRequired
        {
            get
            {
                return this.ATH_QuantityRequiredField;
            }
            set
            {
                if ((this.ATH_QuantityRequiredField.Equals(value) != true))
                {
                    this.ATH_QuantityRequiredField = value;
                    this.RaisePropertyChanged("ATH_QuantityRequired");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_ShowAvailableQuantity
        {
            get
            {
                return this.ATH_ShowAvailableQuantityField;
            }
            set
            {
                if ((this.ATH_ShowAvailableQuantityField.Equals(value) != true))
                {
                    this.ATH_ShowAvailableQuantityField = value;
                    this.RaisePropertyChanged("ATH_ShowAvailableQuantity");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_ShowUnitPrice
        {
            get
            {
                return this.ATH_ShowUnitPriceField;
            }
            set
            {
                if ((this.ATH_ShowUnitPriceField.Equals(value) != true))
                {
                    this.ATH_ShowUnitPriceField = value;
                    this.RaisePropertyChanged("ATH_ShowUnitPrice");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool ATH_ShowYesNo
        {
            get
            {
                return this.ATH_ShowYesNoField;
            }
            set
            {
                if ((this.ATH_ShowYesNoField.Equals(value) != true))
                {
                    this.ATH_ShowYesNoField = value;
                    this.RaisePropertyChanged("ATH_ShowYesNo");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATH_VendorPartyId
        {
            get
            {
                return this.ATH_VendorPartyIdField;
            }
            set
            {
                if ((this.ATH_VendorPartyIdField.Equals(value) != true))
                {
                    this.ATH_VendorPartyIdField = value;
                    this.RaisePropertyChanged("ATH_VendorPartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SearchPartyId
        {
            get
            {
                return this.SearchPartyIdField;
            }
            set
            {
                if ((object.ReferenceEquals(this.SearchPartyIdField, value) != true))
                {
                    this.SearchPartyIdField = value;
                    this.RaisePropertyChanged("SearchPartyId");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AuthInventoryGroupAssociationData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class AuthInventoryGroupAssociationData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHIGA_InventoryGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHIGA_InventoryGroupNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHIGA_InventoryIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private InventoryData_DTO INV_InvDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHIGA_InventoryGroupId
        {
            get
            {
                return this.ATHIGA_InventoryGroupIdField;
            }
            set
            {
                if ((this.ATHIGA_InventoryGroupIdField.Equals(value) != true))
                {
                    this.ATHIGA_InventoryGroupIdField = value;
                    this.RaisePropertyChanged("ATHIGA_InventoryGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHIGA_InventoryGroupName
        {
            get
            {
                return this.ATHIGA_InventoryGroupNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHIGA_InventoryGroupNameField, value) != true))
                {
                    this.ATHIGA_InventoryGroupNameField = value;
                    this.RaisePropertyChanged("ATHIGA_InventoryGroupName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHIGA_InventoryId
        {
            get
            {
                return this.ATHIGA_InventoryIdField;
            }
            set
            {
                if ((this.ATHIGA_InventoryIdField.Equals(value) != true))
                {
                    this.ATHIGA_InventoryIdField = value;
                    this.RaisePropertyChanged("ATHIGA_InventoryId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public InventoryData_DTO INV_InvDataObj
        {
            get
            {
                return this.INV_InvDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.INV_InvDataObjField, value) != true))
                {
                    this.INV_InvDataObjField = value;
                    this.RaisePropertyChanged("INV_InvDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name = "AuthPartyGroupAssociationData_DTO", Namespace = "http://schemas.datacontract.org/2004/07/")]
    [System.SerializableAttribute()]
    internal partial class AuthPartyGroupAssociationData_DTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged
    {

        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHPGA_PartyGroupIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ATHPGA_PartyGroupNameField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ATHPGA_PartyIdField;

        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private PartyData_DTO PTY_PartyDataObjField;

        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHPGA_PartyGroupId
        {
            get
            {
                return this.ATHPGA_PartyGroupIdField;
            }
            set
            {
                if ((this.ATHPGA_PartyGroupIdField.Equals(value) != true))
                {
                    this.ATHPGA_PartyGroupIdField = value;
                    this.RaisePropertyChanged("ATHPGA_PartyGroupId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ATHPGA_PartyGroupName
        {
            get
            {
                return this.ATHPGA_PartyGroupNameField;
            }
            set
            {
                if ((object.ReferenceEquals(this.ATHPGA_PartyGroupNameField, value) != true))
                {
                    this.ATHPGA_PartyGroupNameField = value;
                    this.RaisePropertyChanged("ATHPGA_PartyGroupName");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ATHPGA_PartyId
        {
            get
            {
                return this.ATHPGA_PartyIdField;
            }
            set
            {
                if ((this.ATHPGA_PartyIdField.Equals(value) != true))
                {
                    this.ATHPGA_PartyIdField = value;
                    this.RaisePropertyChanged("ATHPGA_PartyId");
                }
            }
        }

        [System.Runtime.Serialization.DataMemberAttribute()]
        public PartyData_DTO PTY_PartyDataObj
        {
            get
            {
                return this.PTY_PartyDataObjField;
            }
            set
            {
                if ((object.ReferenceEquals(this.PTY_PartyDataObjField, value) != true))
                {
                    this.PTY_PartyDataObjField = value;
                    this.RaisePropertyChanged("PTY_PartyDataObj");
                }
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthorizationRule", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthorizationRuleRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationData_DTO authorizationData_DTO;

        public AddAuthorizationRuleRequest()
        {
        }

        public AddAuthorizationRuleRequest(AuthorizationData_DTO authorizationData_DTO)
        {
            this.authorizationData_DTO = authorizationData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthorizationRuleResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthorizationRuleResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool AddAuthorizationRuleResult;

        public AddAuthorizationRuleResponse()
        {
        }

        public AddAuthorizationRuleResponse(bool AddAuthorizationRuleResult)
        {
            this.AddAuthorizationRuleResult = AddAuthorizationRuleResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateAuthorizationRule", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class UpdateAuthorizationRuleRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationData_DTO authorizationData_DTO;

        public UpdateAuthorizationRuleRequest()
        {
        }

        public UpdateAuthorizationRuleRequest(AuthorizationData_DTO authorizationData_DTO)
        {
            this.authorizationData_DTO = authorizationData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateAuthorizationRuleResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class UpdateAuthorizationRuleResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool UpdateAuthorizationRuleResult;

        public UpdateAuthorizationRuleResponse()
        {
        }

        public UpdateAuthorizationRuleResponse(bool UpdateAuthorizationRuleResult)
        {
            this.UpdateAuthorizationRuleResult = UpdateAuthorizationRuleResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthorizationRule", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthorizationRuleRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationData_DTO authorizationData_DTO;

        public DeleteAuthorizationRuleRequest()
        {
        }

        public DeleteAuthorizationRuleRequest(AuthorizationData_DTO authorizationData_DTO)
        {
            this.authorizationData_DTO = authorizationData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthorizationRuleResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthorizationRuleResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool DeleteAuthorizationRuleResult;

        public DeleteAuthorizationRuleResponse()
        {
        }

        public DeleteAuthorizationRuleResponse(bool DeleteAuthorizationRuleResult)
        {
            this.DeleteAuthorizationRuleResult = DeleteAuthorizationRuleResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthorizationRulesList", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthorizationRulesListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public int vendorId;

        public GetAuthorizationRulesListRequest()
        {
        }

        public GetAuthorizationRulesListRequest(int vendorId)
        {
            this.vendorId = vendorId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthorizationRulesListResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthorizationRulesListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationRulesSearch_DTO[] GetAuthorizationRulesListResult;

        public GetAuthorizationRulesListResponse()
        {
        }

        public GetAuthorizationRulesListResponse(AuthorizationRulesSearch_DTO[] GetAuthorizationRulesListResult)
        {
            this.GetAuthorizationRulesListResult = GetAuthorizationRulesListResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthorizationRuleById", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthorizationRuleByIdRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public int AuthorizationId;

        public GetAuthorizationRuleByIdRequest()
        {
        }

        public GetAuthorizationRuleByIdRequest(int AuthorizationId)
        {
            this.AuthorizationId = AuthorizationId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthorizationRuleByIdResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthorizationRuleByIdResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationRulesSearch_DTO GetAuthorizationRuleByIdResult;

        public GetAuthorizationRuleByIdResponse()
        {
        }

        public GetAuthorizationRuleByIdResponse(AuthorizationRulesSearch_DTO GetAuthorizationRuleByIdResult)
        {
            this.GetAuthorizationRuleByIdResult = GetAuthorizationRuleByIdResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthInventoryGroup", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthInventoryGroupRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationInventoryGroupsData_DTO authorizationInventoryGroupsData_DTO;

        public AddAuthInventoryGroupRequest()
        {
        }

        public AddAuthInventoryGroupRequest(AuthorizationInventoryGroupsData_DTO authorizationInventoryGroupsData_DTO)
        {
            this.authorizationInventoryGroupsData_DTO = authorizationInventoryGroupsData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthInventoryGroupResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthInventoryGroupResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool AddAuthInventoryGroupResult;

        public AddAuthInventoryGroupResponse()
        {
        }

        public AddAuthInventoryGroupResponse(bool AddAuthInventoryGroupResult)
        {
            this.AddAuthInventoryGroupResult = AddAuthInventoryGroupResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateAuthInventoryGroup", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class UpdateAuthInventoryGroupRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationInventoryGroupsData_DTO authorizationInventoryGroupsData_DTO;

        public UpdateAuthInventoryGroupRequest()
        {
        }

        public UpdateAuthInventoryGroupRequest(AuthorizationInventoryGroupsData_DTO authorizationInventoryGroupsData_DTO)
        {
            this.authorizationInventoryGroupsData_DTO = authorizationInventoryGroupsData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateAuthInventoryGroupResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class UpdateAuthInventoryGroupResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool UpdateAuthInventoryGroupResult;

        public UpdateAuthInventoryGroupResponse()
        {
        }

        public UpdateAuthInventoryGroupResponse(bool UpdateAuthInventoryGroupResult)
        {
            this.UpdateAuthInventoryGroupResult = UpdateAuthInventoryGroupResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthInventoryGroup", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthInventoryGroupRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationInventoryGroupsData_DTO authorizationInventoryGroupsData_DTO;

        public DeleteAuthInventoryGroupRequest()
        {
        }

        public DeleteAuthInventoryGroupRequest(AuthorizationInventoryGroupsData_DTO authorizationInventoryGroupsData_DTO)
        {
            this.authorizationInventoryGroupsData_DTO = authorizationInventoryGroupsData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthInventoryGroupResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthInventoryGroupResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool DeleteAuthInventoryGroupResult;

        public DeleteAuthInventoryGroupResponse()
        {
        }

        public DeleteAuthInventoryGroupResponse(bool DeleteAuthInventoryGroupResult)
        {
            this.DeleteAuthInventoryGroupResult = DeleteAuthInventoryGroupResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthInventoryGroupsList", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthInventoryGroupsListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public int vendorId;

        public GetAuthInventoryGroupsListRequest()
        {
        }

        public GetAuthInventoryGroupsListRequest(int vendorId)
        {
            this.vendorId = vendorId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthInventoryGroupsListResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthInventoryGroupsListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationInventoryGroupsData_DTO[] GetAuthInventoryGroupsListResult;

        public GetAuthInventoryGroupsListResponse()
        {
        }

        public GetAuthInventoryGroupsListResponse(AuthorizationInventoryGroupsData_DTO[] GetAuthInventoryGroupsListResult)
        {
            this.GetAuthInventoryGroupsListResult = GetAuthInventoryGroupsListResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthPartyGroup", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthPartyGroupRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationPartyGroupsData_DTO authorizationPartyGroupsData_DTO;

        public AddAuthPartyGroupRequest()
        {
        }

        public AddAuthPartyGroupRequest(AuthorizationPartyGroupsData_DTO authorizationPartyGroupsData_DTO)
        {
            this.authorizationPartyGroupsData_DTO = authorizationPartyGroupsData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthPartyGroupResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthPartyGroupResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool AddAuthPartyGroupResult;

        public AddAuthPartyGroupResponse()
        {
        }

        public AddAuthPartyGroupResponse(bool AddAuthPartyGroupResult)
        {
            this.AddAuthPartyGroupResult = AddAuthPartyGroupResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateAuthPartyGroup", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class UpdateAuthPartyGroupRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationPartyGroupsData_DTO authorizationPartyGroupsData_DTO;

        public UpdateAuthPartyGroupRequest()
        {
        }

        public UpdateAuthPartyGroupRequest(AuthorizationPartyGroupsData_DTO authorizationPartyGroupsData_DTO)
        {
            this.authorizationPartyGroupsData_DTO = authorizationPartyGroupsData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "UpdateAuthPartyGroupResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class UpdateAuthPartyGroupResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool UpdateAuthPartyGroupResult;

        public UpdateAuthPartyGroupResponse()
        {
        }

        public UpdateAuthPartyGroupResponse(bool UpdateAuthPartyGroupResult)
        {
            this.UpdateAuthPartyGroupResult = UpdateAuthPartyGroupResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthPartyGroup", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthPartyGroupRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationPartyGroupsData_DTO authorizationPartyGroupsData_DTO;

        public DeleteAuthPartyGroupRequest()
        {
        }

        public DeleteAuthPartyGroupRequest(AuthorizationPartyGroupsData_DTO authorizationPartyGroupsData_DTO)
        {
            this.authorizationPartyGroupsData_DTO = authorizationPartyGroupsData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthPartyGroupResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthPartyGroupResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool DeleteAuthPartyGroupResult;

        public DeleteAuthPartyGroupResponse()
        {
        }

        public DeleteAuthPartyGroupResponse(bool DeleteAuthPartyGroupResult)
        {
            this.DeleteAuthPartyGroupResult = DeleteAuthPartyGroupResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthPartyGroupsList", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthPartyGroupsListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public int vendorId;

        public GetAuthPartyGroupsListRequest()
        {
        }

        public GetAuthPartyGroupsListRequest(int vendorId)
        {
            this.vendorId = vendorId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthPartyGroupsListResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthPartyGroupsListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthorizationPartyGroupsData_DTO[] GetAuthPartyGroupsListResult;

        public GetAuthPartyGroupsListResponse()
        {
        }

        public GetAuthPartyGroupsListResponse(AuthorizationPartyGroupsData_DTO[] GetAuthPartyGroupsListResult)
        {
            this.GetAuthPartyGroupsListResult = GetAuthPartyGroupsListResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthInventoryGroupAssociation", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthInventoryGroupAssociationRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthInventoryGroupAssociationData_DTO authInventoryGroupAssociationData_DTO;

        public AddAuthInventoryGroupAssociationRequest()
        {
        }

        public AddAuthInventoryGroupAssociationRequest(AuthInventoryGroupAssociationData_DTO authInventoryGroupAssociationData_DTO)
        {
            this.authInventoryGroupAssociationData_DTO = authInventoryGroupAssociationData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthInventoryGroupAssociationResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthInventoryGroupAssociationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool AddAuthInventoryGroupAssociationResult;

        public AddAuthInventoryGroupAssociationResponse()
        {
        }

        public AddAuthInventoryGroupAssociationResponse(bool AddAuthInventoryGroupAssociationResult)
        {
            this.AddAuthInventoryGroupAssociationResult = AddAuthInventoryGroupAssociationResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthInventoryGroupAssociation", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthInventoryGroupAssociationRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthInventoryGroupAssociationData_DTO authInventoryGroupAssociationData_DTO;

        public DeleteAuthInventoryGroupAssociationRequest()
        {
        }

        public DeleteAuthInventoryGroupAssociationRequest(AuthInventoryGroupAssociationData_DTO authInventoryGroupAssociationData_DTO)
        {
            this.authInventoryGroupAssociationData_DTO = authInventoryGroupAssociationData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthInventoryGroupAssociationResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthInventoryGroupAssociationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool DeleteAuthInventoryGroupAssociationResult;

        public DeleteAuthInventoryGroupAssociationResponse()
        {
        }

        public DeleteAuthInventoryGroupAssociationResponse(bool DeleteAuthInventoryGroupAssociationResult)
        {
            this.DeleteAuthInventoryGroupAssociationResult = DeleteAuthInventoryGroupAssociationResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthInventoryGroupAssocationList", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthInventoryGroupAssocationListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public int inventoryGroupId;

        public GetAuthInventoryGroupAssocationListRequest()
        {
        }

        public GetAuthInventoryGroupAssocationListRequest(int inventoryGroupId)
        {
            this.inventoryGroupId = inventoryGroupId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthInventoryGroupAssocationListResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthInventoryGroupAssocationListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthInventoryGroupAssociationData_DTO[] GetAuthInventoryGroupAssocationListResult;

        public GetAuthInventoryGroupAssocationListResponse()
        {
        }

        public GetAuthInventoryGroupAssocationListResponse(AuthInventoryGroupAssociationData_DTO[] GetAuthInventoryGroupAssocationListResult)
        {
            this.GetAuthInventoryGroupAssocationListResult = GetAuthInventoryGroupAssocationListResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthPartyGroupAssociation", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthPartyGroupAssociationRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthPartyGroupAssociationData_DTO authPartyGroupAssociationData_DTO;

        public AddAuthPartyGroupAssociationRequest()
        {
        }

        public AddAuthPartyGroupAssociationRequest(AuthPartyGroupAssociationData_DTO authPartyGroupAssociationData_DTO)
        {
            this.authPartyGroupAssociationData_DTO = authPartyGroupAssociationData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "AddAuthPartyGroupAssociationResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class AddAuthPartyGroupAssociationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool AddAuthPartyGroupAssociationResult;

        public AddAuthPartyGroupAssociationResponse()
        {
        }

        public AddAuthPartyGroupAssociationResponse(bool AddAuthPartyGroupAssociationResult)
        {
            this.AddAuthPartyGroupAssociationResult = AddAuthPartyGroupAssociationResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthPartyGroupAssociation", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthPartyGroupAssociationRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthPartyGroupAssociationData_DTO authPartyGroupAssociationData_DTO;

        public DeleteAuthPartyGroupAssociationRequest()
        {
        }

        public DeleteAuthPartyGroupAssociationRequest(AuthPartyGroupAssociationData_DTO authPartyGroupAssociationData_DTO)
        {
            this.authPartyGroupAssociationData_DTO = authPartyGroupAssociationData_DTO;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "DeleteAuthPartyGroupAssociationResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class DeleteAuthPartyGroupAssociationResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public bool DeleteAuthPartyGroupAssociationResult;

        public DeleteAuthPartyGroupAssociationResponse()
        {
        }

        public DeleteAuthPartyGroupAssociationResponse(bool DeleteAuthPartyGroupAssociationResult)
        {
            this.DeleteAuthPartyGroupAssociationResult = DeleteAuthPartyGroupAssociationResult;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthPartyGroupAssocationList", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthPartyGroupAssocationListRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public int partyGroupId;

        public GetAuthPartyGroupAssocationListRequest()
        {
        }

        public GetAuthPartyGroupAssocationListRequest(int partyGroupId)
        {
            this.partyGroupId = partyGroupId;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "GetAuthPartyGroupAssocationListResponse", WrapperNamespace = "http://ContosoDataAccessService.com/", IsWrapped = true)]
    internal partial class GetAuthPartyGroupAssocationListResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://ContosoDataAccessService.com/", Order = 0)]
        public AuthPartyGroupAssociationData_DTO[] GetAuthPartyGroupAssocationListResult;

        public GetAuthPartyGroupAssocationListResponse()
        {
        }

        public GetAuthPartyGroupAssocationListResponse(AuthPartyGroupAssociationData_DTO[] GetAuthPartyGroupAssocationListResult)
        {
            this.GetAuthPartyGroupAssocationListResult = GetAuthPartyGroupAssocationListResult;
        }
    }

}
